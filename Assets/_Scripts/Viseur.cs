using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Viseur : MonoBehaviour
{
    public float AimingForce;
    private Rigidbody rb;
    public Transform Visor;
    public Animator anim;

    void Aim()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(x,y,0);
        
        print(dir);
        if (dir.magnitude >= .1f)
        {
            Visor.rotation = Quaternion.LookRotation(dir, -Vector3.forward) * Quaternion.FromToRotation(Vector3.up, Vector3.forward);
            anim.SetFloat("Bend",(x+1)/2);
        }
    }

    void FixedUpdate()
    {
        Aim();
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    

}
