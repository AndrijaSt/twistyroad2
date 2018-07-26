using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    public float Rotation = 2.0f;
    public int length = 100;
    public float width = 0.5f;
    public float Slope = 0.3f;
    public float Step = 0.4f;
    private float rot;
    private Vector3 step;
    private Vector3 slope;
    private Vector3 left;
    private Vector3 right;
    private Vector3 cor;
    private float rotation;

    private float Rand()
    {

        rotation += Random.Range(-Rotation, Rotation);
        return rotation;
    }

	void Start ()
    {
        var mf = GetComponent<MeshFilter>();
        var mc = GetComponent<MeshCollider>();
        var mesh = new Mesh();
        mf.mesh = mesh;

        var vertices = new Vector3[length];

        step = new Vector3(0.0f, 0.0f, Step);
        slope = new Vector3(0.0f, -Slope, 0.0f);
        right = new Vector3(width/2, 0.0f, 0.0f);
        left = new Vector3(-width / 2, 0.0f, 0.0f);

        vertices[0] = step + slope + right;
        vertices[1] = step + slope + left;

        for(int i=2; i<length; i+=2)
        {
            rot = Rand();
            step = Quaternion.AngleAxis(rot, Vector3.up) * step;
            left = Quaternion.AngleAxis(rot, Vector3.up) * left;
            right = Quaternion.AngleAxis(rot, Vector3.up) * right;
            cor += step + slope;
            vertices[i]   = cor + right;
            vertices[i+1] = cor + left;
        }

        mesh.vertices = vertices;

        var tri = new int[3 * length];

        int j = 0;
        for(int i=3; i< length; i+=2)
        {
            tri[j++] = i - 3;
            tri[j++] = i - 2;
            tri[j++] = i;
            tri[j++] = i - 3;
            tri[j++] = i;
            tri[j++] = i - 1;
        }

        mesh.triangles = tri;

        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
        mesh.RecalculateTangents();

        mc.sharedMesh = mesh;
    }

    void Update ()
    {
		
	}
}
