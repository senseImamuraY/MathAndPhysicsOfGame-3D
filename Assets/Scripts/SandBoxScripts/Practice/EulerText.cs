using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EulerText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    // y軸を軸にして5度、x軸を軸にして5度、回転させるQuaternionを作成（変数をrotとする）
    Quaternion rot = Quaternion.Euler(0, 1, 1);
    // 現在の自信の回転の情報を取得する。
    Quaternion q = this.transform.rotation;
    // 合成して、自身に設定
    this.transform.rotation = q * rot;
  }
}
