using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{

    public Transform playerOb;

    void Update ()
    {
        transform.LookAt(playerOb);
	}
}
