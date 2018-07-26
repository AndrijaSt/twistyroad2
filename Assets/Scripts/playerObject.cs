using UnityEngine;

public class playerObject : MonoBehaviour
{
    public Rigidbody player;
    private Transform t;

    void Start()
    {
        t = GetComponent<Transform>();
    }

    void LateUpdate()
    {
        t.position = player.position;
        t.rotation = Quaternion.AngleAxis(movement.alfa, Vector3.up) * t.rotation;
    }
}