using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jump : MonoBehaviour
{
    public float jumpForce;
    public float clickIntensity;
    private bool isClicking;
    public float chargingSpeed;

    private Rigidbody rb;
    public Transform GravityCenter;
    public Transform Bumper;
    public Transform Up, Down;
    public Transform Visor;

    void DoJump()
    {
        if (CheckGround())
        {
            rb.AddForce(Visor.up * clickIntensity * jumpForce,ForceMode.VelocityChange);
            //rb.velocity = Visor.up * clickIntensity * jumpForce;
        }
    }

    void ChargeJump()
    {
        if (Input.GetAxis("Jump") > .2f && clickIntensity <=1)
        {
            clickIntensity += Time.deltaTime * chargingSpeed;
            clickIntensity = Mathf.Clamp(clickIntensity,0.1f,1);
            Bumper.position = Vector3.Lerp(Down.position,Up.position,clickIntensity);
            //Bumper.localScale = new Vector3(1,Mathf.Lerp(1,0,clickIntensity),1);
        }
        else if (clickIntensity >=.1f)
        {
            DoJump();
            clickIntensity = 0;
            Bumper.position = Down.position;
            //Bumper.localScale = new Vector3(1, 1, 1);
        }
    }

    bool CheckGround()
    {
        if (Physics.Raycast(Bumper.position,-transform.up,Bumper.localScale.y + 0.1f))
        {
            return true;
        }
        else
        {
            //transform.LookAt(rb.velocity);
        }
        return false;
    }

    void Update()
    {

        Debug.DrawRay(Bumper.position, -transform.up * (Bumper.localScale.y - 0.1f));
        ChargeJump();
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Physics.gravity = Physics.gravity * 2;
        rb.centerOfMass = GravityCenter.localPosition;
        Bumper.position = Vector3.Lerp(Down.position, Up.position, clickIntensity);
    }
    
}
