﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transform2_1 : MonoBehaviour {
    Vector3 v3Position;
    Matrix4x4 matTransform;
    public Renderer rend;
    public Color colorCube = Color.red;
    GameObject target; 

    // Use this for initialization
    void Start()
    {
        float fXAbs, fYAbs, fZAbs;

        rend = GetComponent<Renderer>();
        target = GameObject.Find("Sphere");

        v3Position = transform.position;

        fXAbs = Mathf.Abs(transform.position.x);
        fYAbs = Mathf.Abs(transform.position.y);
        fZAbs = Mathf.Abs(transform.position.z);

        if ((fXAbs > fYAbs) && (fXAbs > fZAbs))
        {
            colorCube = Color.magenta;
        }
        else
        {
            if (fYAbs > fZAbs)
            {
                colorCube = Color.cyan;
            }
            else
            {
                colorCube = Color.yellow;
            }
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 v3Side, v3Up, v3Forward;

        v3Forward = Vector3.Normalize( target.transform.position );
        v3Up = new Vector3(0.0f, 0.0f, 1.0f);
        v3Side = Vector3.Cross(v3Up, v3Forward);
        v3Side = Vector3.Normalize(v3Side);
        v3Up = Vector3.Cross(v3Forward, v3Side);

        matTransform = Matrix4x4.identity;                          // 単位行列
        // 回転の行列
        matTransform.m00 = v3Side.x; matTransform.m01 = v3Up.x; matTransform.m02 = v3Forward.x;
        matTransform.m10 = v3Side.y; matTransform.m11 = v3Up.y; matTransform.m12 = v3Forward.y;
        matTransform.m20 = v3Side.z; matTransform.m21 = v3Up.z; matTransform.m22 = v3Forward.z;
        transform.position = matTransform * v3Position;                   // 変換
        transform.LookAt(target.transform.position, new Vector3(0.0f, 0.0f, 1.0f));
        rend.material.color = colorCube;
    }
}
