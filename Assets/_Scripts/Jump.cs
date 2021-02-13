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

    public Image chargeBar;
    void DoJump()
    {
        //rb.AddForce(transform.up * clickIntensity,ForceMode.VelocityChange);
        rb.velocity = transform.up * clickIntensity * jumpForce;
    }

    void ChargeJump()
    {
        if (Input.GetAxis("Jump") > .2f && clickIntensity <=1)
        {
            clickIntensity += Time.deltaTime * chargingSpeed;
            clickIntensity = Mathf.Clamp01(clickIntensity);
            UpdateBar(clickIntensity);
            Bumper.localScale = new Vector3(1,Mathf.Lerp(1,0,clickIntensity),1);
        }
        else if (clickIntensity >=.1f)
        {
            DoJump();
            clickIntensity = 0;

            Bumper.localScale = new Vector3(1, 1, 1);
        }
    }

    void Update()
    {
        ChargeJump();
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Physics.gravity = Physics.gravity * 2;
        rb.centerOfMass = GravityCenter.localPosition;
    }

    void UpdateBar(float value)
    {
        chargeBar.fillAmount = value;
    }
}
