using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movement : MonoBehaviour
{
    static public float timeLeft;
    static public float alfa;
    public float brzina = 2.0f;
    public float osetljivost = 2.0f;
    public float time = 5.0f;
    private Vector3 v;
    private Rigidbody rb;

    public bool inGame = false;

    void OnCollisionStay()
    {
        timeLeft = time;
    }

    internal void start()
    {
        throw new NotImplementedException();
    }

    public void Start()
    {
        timeLeft = time;
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0.0f, 0.0f, brzina);
    }

    void Update ()
    {
        if (!inGame) return;

        timeLeft -= Time.deltaTime;
        if (timeLeft < 0.0f) SceneManager.LoadScene("Game");

        alfa = 0.0f;
        if (Input.GetKey(KeyCode.LeftArrow)) alfa = -osetljivost;
        if (Input.GetKey(KeyCode.RightArrow)) alfa = osetljivost;
        rb.velocity = Quaternion.AngleAxis(alfa, Vector3.up) * rb.velocity; 
    }
}
