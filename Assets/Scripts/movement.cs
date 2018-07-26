using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    static public float timeLeft;
    static public float alfa;
    public float brzina = 2.0f;
    public float osetljivost = 2.0f;
    public float time = 5.0f;
    private Vector3 v;
    private Rigidbody rb;

    void OnCollisionEnter()
    {
        timeLeft = time;
    }

    public void Start()
    {
        timeLeft = time;
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0.0f, 0.0f, brzina);
    }

    void Update ()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0.0f) Menu.PlayGame();

        alfa = 0.0f;
        if (Input.GetKey(KeyCode.LeftArrow)) alfa = -osetljivost;
        if (Input.GetKey(KeyCode.RightArrow)) alfa = osetljivost;
        rb.velocity = Quaternion.AngleAxis(alfa, Vector3.up) * rb.velocity; 
    }
}
