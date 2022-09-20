using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private float currentSpeed = 0f;
    public float standardSpeed = 20f;
    public float maxSpeed = 25f;
    public float rotateSpeed = 16f;
    public bool canInput = true;
    float rotateAngle;
    float direction = 0f;
    float rdirection = 0f;
    float accelerate = 0f;

    Vector3 moveDir;
    Vector3 rotateDir;
    Vector3 moveAmount;
    Quaternion rotateAmount;

    Animator anim;
    Rigidbody rb;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Control the movement of the player
        if (canInput)
        {
            direction = Input.GetAxis("Vertical");
            rdirection = Input.GetAxis("Horizontal");
            accelerate = Input.GetAxis("Accelerate");
        }

        else
        {
            direction = 0;
            rdirection = 0;
        }
            
        moveDir = new Vector3(0, 0, 0);

        if (direction > 0)
        {
            if(currentSpeed < standardSpeed)
            {
                currentSpeed += standardSpeed*Time.deltaTime;
            }

            // acceleration operation
            if(accelerate > 0 && currentSpeed < maxSpeed)
            {
                currentSpeed += standardSpeed * Time.deltaTime;
            }
            else if(!(accelerate > 0) && currentSpeed > standardSpeed)
            {
                currentSpeed -= standardSpeed * Time.deltaTime * 0.5f;
            }
            
            rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            moveDir = transform.forward.normalized;
        }

        else if (direction < 0)
        {
            currentSpeed = standardSpeed;
            rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            moveDir = -transform.forward.normalized;
        }

        else
        {
            if (currentSpeed > 0) // Implement inertia as the character stop moving 
            {
                currentSpeed -= standardSpeed * Time.deltaTime*2.5f;
                moveDir = transform.forward.normalized;
            }
            else 
            {
                currentSpeed = 0;
                rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ |
                RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            } 
        }

        moveAmount = moveDir * currentSpeed * Time.deltaTime;
        rotateDir = new Vector3(0, rdirection, 0).normalized;
        rotateAngle += rotateDir.y*rotateSpeed* Time.deltaTime;
        //Debug.Log(rotateAngle);
        SwitchAnimation();

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveAmount);
        rotateAmount = Quaternion.Euler(0,  rotateAngle, 0);
        rb.MoveRotation(rotateAmount);
    }

    private void SwitchAnimation()
    {
        anim.SetFloat("Speed", currentSpeed/ maxSpeed );
    }

}
