using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
  public float speed = 700;
  public float Angle;
  //public float aChanger;
  // public GameObject ball;
  
  // Start is called before the first frame update
  void Start()
  {
    //aChanger = 4.0f;
    Rigidbody rb = GetComponent<Rigidbody>();
    //Debug.LogFormat("fAngle"+ fAngle + "Cos" + Mathf.Cos(fAngle / aChanger)+ "Sin" + Mathf.Sin(fAngle / aChanger));
    //Debug.LogFormat("fAngle"+ fAngle + "Cos" + Mathf.Cos(Mathf.PI)+ "Sin" + Mathf.Sin(1));

    // これは本体を回転させているため、発射角度の調整はできない。
    //// y軸を軸にして5度、x軸を軸にして5度、回転させるQuaternionを作成（変数をrotとする）
    //Quaternion rot = Quaternion.Euler(0, 3, 3);
    //// 現在の自信の回転の情報を取得する。
    //Quaternion q = this.transform.rotation;
    //// 合成して、自身に設定
    //this.transform.rotation = q * rot;
    // 角度をラジアンに変換
    float rad = Angle * Mathf.Deg2Rad;
    Vector3 force = new Vector3(Mathf.Cos(rad), Mathf.Sin(rad), 0) * speed;
    //Vector3 force = new Vector3(Mathf.Sin(1.0f / 2.0f * Mathf.PI), Mathf.Cos(Mathf.Sqrt(3) / 2.0f), 0) * speed;
    //Vector3 force = new Vector3(Mathf.Cos(Mathf.Sqrt(3) / 2.0f), Mathf.Sin(1.0f / 2.0f * Mathf.PI), 0) * speed;
    //Vector3 force = new Vector3(Mathf.Cos(fAngle / aChanger), Mathf.Sin(fAngle / aChanger), 0) * speed;s
    Debug.Log(force);

    rb.AddForce(force);
  }

  // Update is called once per frame
  void Update()
  {
     
  }
}
// 方針
// カーソルの動きでx yの値を調整する
// カメラの回転を応用する
//　