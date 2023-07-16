using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Side
    [SerializeField]
    public bool playerSide = false;

    // Move
    [SerializeField]
    public float moveSpeed = 1.0f;
    [SerializeField]
    public float minMoveSpeed = 0.1f;
    public float currentSpeed = 1.0f;
    [SerializeField]
    private Vector2 sensitivityThreshold = new Vector3(0.5f, 0.5f);

    // Interact system
    private GameObject slot = null;
    private GameObject inside = null;
    [SerializeField]
    private GameObject grabPoint;

    //Custom inputs
    private string interactButton = "Interact";
    private string hAxis = "Horizontal";
    private string vAxis = "Vertical";

    // Components
    private Rigidbody rigidBody = null;
    private Animator animator = null;

    // Start is called before the first frame update
    void Start()
    {
        if (playerSide)
        {
            interactButton += "_2";
            hAxis += "_2";
            vAxis += "_2";
        }

        rigidBody = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();

        currentSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Interact();
    }

    private void Move()
    {
        // Get imputs
        float moveY = Input.GetAxisRaw(hAxis);
        if (Mathf.Abs(moveY) < sensitivityThreshold.y)
            moveY = 0.0f;

        float moveX = Input.GetAxisRaw(vAxis);
        if (Mathf.Abs(moveX) < sensitivityThreshold.x)
            moveX = 0.0f;

        // Set animation
        if (animator != null)
            if(rigidBody.velocity != Vector3.zero)
                animator.SetBool("Run", true);
            else
                animator.SetBool("Run", false);

        // Move
        rigidBody.velocity = new Vector3(currentSpeed * moveX, 0.0f, currentSpeed * moveY);

        // Set forward
        if (rigidBody.velocity.magnitude > 0.1f)
        {
            gameObject.transform.forward = rigidBody.velocity;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Interactable")
        {
            inside = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Interactable")
        {
            inside = null;
        }
    }

    private void Interact()
    {
        if (Input.GetButton(interactButton))
        {
            // If Something
            if (inside == null)
                return;

            // If items
            Items item = inside.GetComponent<Items>();
            if (item == null)
                return;
            Debug.Log(item.name + " used");
            item.DoSomething(slot, playerSide);

            // If grabable
            Grabable grabable = inside.GetComponent<Grabable>();
            if (grabable != null)
            {
                FinalProduct fp = inside.GetComponent<FinalProduct>();
                if (fp != null)
                    if (fp.side != playerSide)
                        return;

                if (slot == null)
                {
                    inside.transform.parent = this.transform;
                    inside.transform.position = grabPoint.transform.position;

                    slot = inside;
                }
            }
            inside = null;
        }
    }
}