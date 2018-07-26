using UnityEngine;

public class playerObject : MonoBehaviour
{
    public Transform player;
    //private float rot;

    void Start()
    {
        Screen.lockCursor = true;
    }

    void Update()
    {
        if (Input.GetKeyDown("t")) Screen.lockCursor = false;
        if (Input.GetKeyUp("t")) Screen.lockCursor = true;

        transform.position = player.position;

        //rot = player.eulerAngles.y;

        transform.eulerAngles += new Vector3(0, Input.GetAxis("Mouse X")*2, 0);

    }
}