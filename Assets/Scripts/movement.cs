using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public Transform po;
    public Rigidbody rb;
    public float brzina = 0.6f;

	void FixedUpdate ()
    {
        rb.rotation.SetLookRotation(rb.velocity);
        if (Input.GetKey("w")) rb.AddForce(Quaternion.AngleAxis(po.rotation.eulerAngles.y, po.up) * new Vector3(0.0f, 0.0f,  brzina), ForceMode.VelocityChange);
        if (Input.GetKey("s")) rb.AddForce(Quaternion.AngleAxis(po.rotation.eulerAngles.y, po.up) * new Vector3(0.0f, 0.0f, -brzina), ForceMode.VelocityChange);
        if (Input.GetKey("d")) rb.AddForce(Quaternion.AngleAxis(po.rotation.eulerAngles.y, po.up) * new Vector3( brzina, 0.0f, 0.0f), ForceMode.VelocityChange);
        if (Input.GetKey("a")) rb.AddForce(Quaternion.AngleAxis(po.rotation.eulerAngles.y, po.up) * new Vector3(-brzina, 0.0f, 0.0f), ForceMode.VelocityChange);
    }
}
