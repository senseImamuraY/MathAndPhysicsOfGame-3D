using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleBasic : MonoBehaviour {
    public Vector3 v3Direction;                 // 方向ベクトル
    public float fRadius;                       // 当たり半径
    private Quaternion qRot;
    public float rotationSpeed = 60.0f;         // 回転速度（度/秒）
    public Vector3 pivot;
    // Use this for initialization
    void Start () {
        qRot = Quaternion.AngleAxis(45.0f, new Vector3(1.0f, 1.0f, -1.0f));
        v3Direction = new Vector3(0.0f, 0.5f, 0.0f);
        v3Direction = qRot * v3Direction;
        transform.rotation = qRot;
        fRadius = 0.5f; 
        pivot = Vector3.zero;
    }
	
	// Update is called once per frame
	void Update () {
        // Get the axis of the current quaternion
        float angle;
        Vector3 axis;
        qRot.ToAngleAxis(out angle, out axis);

        // Rotate the object around the pivot point at a constant speed, independent of the frame rate
        float rotationAmount = rotationSpeed * Time.deltaTime;
        transform.RotateAround(pivot, axis, rotationAmount);
    }
}
