using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private float currentSpeed = 0f;
    public float standardSpeed = 20f;
    public float maxSpeed = 25f;
    public float rotateSpeed = 16f;
    float rotateAngle;

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
        float direction = Input.GetAxis("Vertical");
        moveDir = new Vector3(0, 0, 0);

        if (direction > 0)
        {
            if(currentSpeed < standardSpeed)
            {
                currentSpeed += standardSpeed*Time.deltaTime;
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
        rotateDir = new Vector3(0, Input.GetAxis("Horizontal"), 0).normalized;
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
