using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomPlaneCollider : MonoBehaviour
{
    private Renderer rend;
    public Color colorNoHit = Color.cyan;
    public Color colorHit = Color.red;
    private Material material;
    private Mesh polygon;
    private const float fFloorSize = 10.0f;
    // X��
    private Vector3 v3Vec1 = new Vector3(fFloorSize / 2.0f, 0.0f, 0.0f);
    // Z��
    private Vector3 v3Vec2 = new Vector3(0.0f, 0.0f, fFloorSize / 2.0f);
    private Vector3 v3GroundNormal = new Vector3(0.0f, 1.0f, 0.0f);
    private const float fVelocity = 0.1f;

    // �����͊֌W�Ȃ��H
    private Vector3 halfHeight = new Vector3(0 ,1.0f, 0);
    private Vector3 capsulePosition;
    // ���_
    float X, Y, Z;
    public Vector3[] positions = new Vector3[]{
        new Vector3(-fFloorSize / 2.0f, 1.0f, fFloorSize / 2.0f),
        new Vector3( fFloorSize / 2.0f, 1.0f, fFloorSize / 2.0f),
        new Vector3(-fFloorSize / 2.0f, 1.0f,-fFloorSize / 2.0f),
        new Vector3( fFloorSize / 2.0f, 1.0f,-fFloorSize / 2.0f),
    };

    // �@���x�N�g��
    private Vector3[] normals = new Vector3[]{
        new Vector3(0.0f, 1.0f, 0.0f),
        new Vector3(0.0f, 1.0f, 0.0f),
        new Vector3(0.0f, 1.0f, 0.0f),
        new Vector3(0.0f, 1.0f, 0.0f),
    };

    // ���_�C���f�b�N�X�i�|���S���f�[�^�j
    private int[] indices = new int[] { 0, 1, 2, 1, 3, 2 };

    // Use this for initialization
    void Start()
    {
        Debug.Log("transform.position = " + transform.position);
        capsulePosition = this.transform.position - halfHeight;
        Debug.Log("capsulePosition(Start) = " + capsulePosition);
        rend = GetComponent<Renderer>();
        material = GetComponent<Renderer>().material;
        material.color = new Color(0.0f, 0.0f, 1.0f);
        polygon = new Mesh();

        polygon.vertices = positions;
        polygon.normals = normals;
        polygon.triangles = indices;

        //transform.position = new Vector3(0.0f, 1.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        positions[0] = -v3Vec1 + v3Vec2;
        positions[1] = v3Vec1 + v3Vec2;
        positions[2] = -v3Vec1 - v3Vec2;
        positions[3] = v3Vec1 - v3Vec2;
        for (int i = 0; i < 4; i++) normals[i] = v3GroundNormal;
        polygon.vertices = positions;
        polygon.normals = normals;
        Graphics.DrawMesh(polygon, Vector3.zero, Quaternion.identity, material, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log("capsulePosition = " + capsulePosition);
        //capsulePosition = capsulePosition - halfHeight;
        // �n�ʂ̌X�ΕύX
        //v3Vec1 = new Vector3(fFloorSize / 2.0f,
        //                     2.0f * Mathf.Sin(Time.time * 2.0f * Mathf.PI / 5.0f),
        //                     3.0f * Mathf.Sin(Time.time * 2.0f * Mathf.PI / 10.0f));
        //v3Vec2 = new Vector3(5.0f * Mathf.Sin(Time.time * 2.0f * Mathf.PI / 12.0f),
        //                     0.8f * Mathf.Sin(Time.time * 2.0f * Mathf.PI / 7.0f) + 0.7f,
        //                     fFloorSize / 2.0f);        
        v3Vec1 = new Vector3(fFloorSize / 2.0f,
                             1.0f,
                             0.0f);
        v3Vec2 = new Vector3(0.0f,
                             1.0f,
                             fFloorSize / 2.0f);
        //capsulePosition = transform.position - halfHeight;
        // ���x�N�g���v�Z
        float bx = capsulePosition.x + Input.GetAxis("Horizontal") * fVelocity;
        float by = capsulePosition.y + Input.GetAxis("Vertical") * fVelocity;
        float bz = 0;
        Vector3 v3Normal = Vector3.Cross(v3Vec1, v3Vec2);

        float dot = v3Normal.x * capsulePosition.x + v3Normal.y * capsulePosition.y + v3Normal.z * capsulePosition.z;
        //float d = dot;
        float d = -dot;
        Debug.Log("d = "+d);
        if(v3Normal.x < 0.01f)
        {
            X = 0.01f;
        }
        else
        {
            X = v3Normal.x;
        }        
        if(v3Normal.y < 0.01f)
        {
            Y = 0.01f;
        }
        else
        {
            Y = v3Normal.x;
        }        
        if(v3Normal.z < 0.01f)
        {
            Z = 0.01f;
        }
        else
        {
            Z = v3Normal.x;
        }
        //Vector3 p1 = new Vector3(0, 0, 0);
        Vector3 p1 = new Vector3(-d / (3 * X), -d / (3 * Y), -d / (3 * Z));
        //Vector3 p1 = new Vector3(-d/(3 * v3Normal.x), -d /(3 * v3Normal.y), -d/(3 * v3Normal.z));
        Debug.Log("p1 = " + p1);

        Vector3 V = (capsulePosition) - p1;
        Debug.Log("V = " + V);
        float e = Vector3.Dot(v3Normal, V);
        //float by = (-v3Normal.x * bx - v3Normal.z * bz + d) / v3Normal.y + 0.5f;
        //transform.position = new Vector3(bx, Mathf.Round(by), bz);
        //Debug.Log(transform.position);

        Debug.Log( "e = " + e);
        // �덷�����e����
        float epsilon = 1f; // �덷�͈̔͂�ݒ�
        if (Mathf.Abs(capsulePosition.y - by) < epsilon)
        {
            capsulePosition = new Vector3(bx, by, bz);
            transform.position = capsulePosition;
        }
        if (e <= 0.0f)
        {                       // �Q��̂܂ܔ�r
            rend.material.color = colorHit;
        }
        else
        {
            rend.material.color = colorNoHit;
        }
    }
}
