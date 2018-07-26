using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    public float rotation = 0.5f;
    public int length = 100;
    public float width = 0.5f;
    public float slope = 0.3f;
    public float step = 0.5f;
    private  float beta;
    private Vector3 normala = new Vector3(0.0f, 1.0f, 0.0f);

    private Vector3 Norm(Vector3 vec)
    {
        return Quaternion.AngleAxis(90, normala) * vec;
    }

    private Vector3 Rand (Vector3 vec)
    {
        float angle = Random.Range(-57.3f * beta, 57.3f * beta);

        normala = Quaternion.AngleAxis(angle/2, Vector3.up) * normala;
        return Quaternion.AngleAxis(angle, normala) * vec;
    }

	void Start ()
    {
        beta = 2 * Mathf.Asin(step / width) * rotation;

        var mf = GetComponent<MeshFilter>();
        var mc = GetComponent<MeshCollider>();
        var mesh = new Mesh();
        mf.mesh = mesh;

        var vertices = new Vector3[length];

        Vector3 vec = new Vector3(0, -slope, step);
        Vector3 cor = new Vector3(0, 0, 0);
        vertices[0] = cor + new Vector3( width/2, 0f, 0f);
        vertices[1] = cor + new Vector3(-width/2, 0f, 0f);

        for(int i=2; i<length; i+=2)
        {
            Vector3 v = Rand(vec);
            Vector3 tac = (Norm(v) + Norm(vec)).normalized * width / 2;

            cor += vec;
            vertices[i]   = cor + tac;
            vertices[i+1] = cor - tac;

            vec = v;
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

        /*
        for (int i = 3; i < vertices.Length; i += 2)
        {
            tri[j++] = i - 3;
            tri[j++] = i;
            tri[j++] = i - 2;
            tri[j++] = i - 3;
            tri[j++] = i - 1;
            tri[j++] = i;
        }
        */

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
