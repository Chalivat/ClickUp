using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicFix : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Quaternion rot = transform.rotation;
        Vector3 newRot = rot.eulerAngles;
        newRot.y = 0;
        newRot.x = 0;
        rot = Quaternion.Euler(newRot);
        transform.rotation = rot;
    }
}
