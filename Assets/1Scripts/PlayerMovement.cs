using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public float gravity = -9.81f;
    public float jumpHeight = 5f;
    public Animator animatorBase;
    public Animator animatorV2;
    public Transform groundCheck;
    private float groundDistance = 0.2f;
    public LayerMask groundMask;
    Vector3 velocity;
    bool isGrounded;
    public bool isRolling =false;
    public bool leftRoll = false;
    public bool rightRoll = false;
    public bool forwardRoll = false;
    public bool backwardRoll = false;
    private float turnSmoothSpeed;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
       
        if (isRolling == false)
        {
            //groundmovement
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            float x = Input.GetAxisRaw("Horizontal");
            float z = Input.GetAxisRaw("Vertical");

            Vector3 lookDirection = new Vector3(x,0f,z).normalized;
            //rolling
            if (Input.GetKeyDown(KeyCode.C)&&x>0f && isGrounded || Input.GetKeyDown(KeyCode.V) && isGrounded)
            {
                animatorBase.SetFloat("Speed", 0f);
                animatorBase.SetTrigger("RollRight");
                animatorV2.SetFloat("Speed", 0f);
                animatorV2.SetTrigger("RollRight");
                isRolling = true;
                rightRoll = true;
            }
            else if (Input.GetKeyDown(KeyCode.C)&&x<0f&& isGrounded || Input.GetKeyDown(KeyCode.X) && isGrounded)
            {
                animatorBase.SetFloat("Speed", 0f);
                animatorBase.SetTrigger("RollLeft");
                animatorV2.SetFloat("Speed", 0f);
                animatorV2.SetTrigger("RollLeft");
                isRolling = true;
                leftRoll = true;
            }
            else if (Input.GetKeyDown(KeyCode.C)&& z>0f&& isGrounded)
            {
                animatorBase.SetFloat("Speed", 0f);
                animatorBase.SetTrigger("RollForward");
                animatorV2.SetFloat("Speed", 0f);
                animatorV2.SetTrigger("RollForward");
                isRolling = true;
                forwardRoll = true;
            }
                else if (Input.GetKeyDown(KeyCode.C)&& z<0f&& isGrounded)
            {
                animatorBase.SetFloat("Speed", 0f);
                animatorBase.SetTrigger("RollBackward");
                animatorV2.SetFloat("Speed", 0f);
                animatorV2.SetTrigger("RollBackward");
                isRolling = true;
                backwardRoll = true;
            }


            //walkanimation
            if (lookDirection.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(lookDirection.x, lookDirection.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothSpeed, 0.1f);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);
                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                controller.Move(moveDir.normalized * 6f * Time.deltaTime);
            }
            Vector3 horizontalVelocity = controller.velocity;
            horizontalVelocity = new Vector3(controller.velocity.x, 0, controller.velocity.z);
            float horizontalSpeed = horizontalVelocity.magnitude;

            if (horizontalSpeed > 0)
            {
                animatorBase.SetFloat("Speed", 5f);
                animatorV2.SetFloat("Speed", 5f);
            }
            else
            {
                animatorBase.SetFloat("Speed", 0f);
                animatorV2.SetFloat("Speed", 0f);
            }
            //jump
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                //animatorBase.SetFloat("Speed", 0f);
                //animatorV2.SetFloat("Speed", 0f);
                //velocity.y = Mathf.Sqrt(jumpHeight * 2f);
                animatorBase.SetTrigger("Jumped");
                animatorV2.SetTrigger("Jumped");
            }

            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);

            //attack
            if(Input.GetMouseButtonDown(0) && isGrounded)
            {
                animatorBase.SetTrigger("Attack");
                animatorV2.SetTrigger("Attack");
                isRolling = true;
            }

        }

        if (isRolling == true)
        {
            if (leftRoll==true)
            {
                controller.Move(-transform.right * 2f * Time.deltaTime);
            }
            else if (rightRoll==true)
            {
                controller.Move(transform.right * 2f * Time.deltaTime);
            }
            else if (forwardRoll==true)
            {
                controller.Move(transform.forward * 3f * Time.deltaTime);
            }
            else if (backwardRoll==true)
            {
                controller.Move(-transform.forward * 3f * Time.deltaTime);
            }
        }
        else 
        { 
            isRolling = false; 
        }
    }
}
