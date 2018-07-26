using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class start : MonoBehaviour {

    public Rigidbody player;
    public movement mov;
    public Text tapText;

    void Start () {
        player.isKinematic = true;
        mov.inGame = false;
	}
	
	void Update () {
        if (mov.inGame) return;
		if (Input.GetKey(KeyCode.Space))
        {
            player.isKinematic = false;
            mov.inGame = true;
            tapText.gameObject.SetActive(false);
            mov.Start();
        }
	}
}
