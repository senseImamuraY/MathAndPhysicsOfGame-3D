﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transform3_1 : MonoBehaviour
{
    private Material material;
    private Mesh polygon;
    private const float fFloorSize = 10.0f;
    private Vector3 v3Vec1 = new Vector3(fFloorSize / 2.0f, 0.0f, 0.0f);
    private Vector3 v3Vec2 = new Vector3(0.0f, 0.0f, fFloorSize / 2.0f);
    private Vector3 v3GroundNormal = new Vector3(0.0f, 1.0f, 0.0f);
    private float fAngle = Mathf.PI / 2.0f;

    // 頂点
    public Vector3[] positions = new Vector3[]{
        new Vector3(-fFloorSize / 2.0f, 0.0f, fFloorSize / 2.0f),
        new Vector3( fFloorSize / 2.0f, 0.0f, fFloorSize / 2.0f),
        new Vector3(-fFloorSize / 2.0f, 0.0f,-fFloorSize / 2.0f),
        new Vector3( fFloorSize / 2.0f, 0.0f,-fFloorSize / 2.0f),
    };

    // 法線ベクトル
    private Vector3[] normals = new Vector3[]{
        new Vector3(0.0f, 1.0f, 0.0f),
        new Vector3(0.0f, 1.0f, 0.0f),
        new Vector3(0.0f, 1.0f, 0.0f),
        new Vector3(0.0f, 1.0f, 0.0f),
    };

    // 頂点インデックス（ポリゴンデータ）
    private int[] indices = new int[] { 0, 1, 2, 1, 3, 2 };

    // Use this for initialization
    void Start()
    {
        material = GetComponent<Renderer>().material;
        material.color = new Color(0.0f, 0.0f, 1.0f);
        polygon = new Mesh();

        polygon.vertices = positions;
        polygon.normals = normals;
        polygon.triangles = indices;

        transform.position = new Vector3(0.0f, 0.5f, 0.0f);
        transform.localScale = new Vector3(2.0f, 1.0f, 6.0f);
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
        // 地面の傾斜変更
        v3Vec1 = new Vector3(fFloorSize / 2.0f, 2.0f * Mathf.Sin(Time.time * 2.0f * Mathf.PI / 5.0f), 0.0f);
        v3Vec2 = new Vector3(0.0f, 0.8f * Mathf.Sin(Time.time * 2.0f * Mathf.PI / 7.0f) + 0.7f, fFloorSize / 2.0f);
        // 基底ベクトル計算
        fAngle += Input.GetAxis("Horizontal") * 0.1f;                   // 角度
        Vector3 v3Up = Vector3.Cross(v3Vec2, v3Vec1);
        Vector3 v3Forward = new Vector3(Mathf.Cos(fAngle), 0.0f, Mathf.Sin(fAngle));
        Vector3 v3Side = Vector3.Cross(v3Up, v3Forward);
        v3Forward = Vector3.Cross(v3Side, v3Up);
        transform.LookAt(v3Forward, v3Up);
    }
}
