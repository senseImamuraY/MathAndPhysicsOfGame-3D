using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationAround : MonoBehaviour
{

  //// 中心点
  //[SerializeField] private Vector3 _center = Vector3.zero;

  //// 回転軸
  //[SerializeField] private Vector3 _axis = Vector3.up;

  //// 円運動周期
  //[SerializeField] private float _period = 2;
 
  //// 向きを更新するかどうか
  //[SerializeField] private bool _updateRotation = true;

  //private void Update()
  //{
  //  var tr = transform;
  //  // 回転のクォータニオン作成
  //  var angleAxis = Quaternion.AngleAxis(360 / _period * Time.deltaTime, _axis);

  //  // 円運動の位置計算
  //  var pos = tr.position;

  //  pos -= _center;
  //  pos = angleAxis * pos;
  //  pos += _center;

  //  tr.position = pos;

  //  // 向き更新
  //  if (_updateRotation)
  //  {
  //    tr.rotation = tr.rotation * angleAxis;
  //  }
  //}
  Quaternion objectRot;
  float Xsensityvity = 30f;

  void Start()
  {
    objectRot = this.transform.localRotation;

  }

  void Update()
  {
    //float xRot = Input.GetAxis("Mouse X") * Ysensityvity;

    float yRot = Input.GetAxis("Mouse Y") * Xsensityvity;



    objectRot *= Quaternion.Euler(0, 0,yRot);

    //chacterRot *= Quaternion.Euler(0, xRot, 0);



    //cameraRot = ClampRotation(cameraRot);



    //cam.transform.localRotation = cameraRot;

    transform.localRotation = objectRot;


  }
}