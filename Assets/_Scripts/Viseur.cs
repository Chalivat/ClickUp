using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Viseur : MonoBehaviour
{
    public float AimingSpeed;

    void Aim()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(x,y,0);
        
        //dir = newRot.eulerAngles;
        print(dir);
        if (dir.magnitude >= .1f)
        {
            transform.rotation = Quaternion.LookRotation(dir, -Vector3.forward) * Quaternion.FromToRotation(Vector3.up, Vector3.forward);
        }
    }

    void Update()
    {
        Aim();
    }
}
