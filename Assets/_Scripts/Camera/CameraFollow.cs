using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float speed;
    public float threshold;
    public Transform Player;

    void Update()
    {
        if (Mathf.Abs(transform.position.y - Player.position.y) > threshold)
        {
            transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, Player.position.y, Time.deltaTime * speed), transform.position.z);
        }
    }
}
