using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationAround : MonoBehaviour
{

  //// ���S�_
  //[SerializeField] private Vector3 _center = Vector3.zero;

  //// ��]��
  //[SerializeField] private Vector3 _axis = Vector3.up;

  //// �~�^������
  //[SerializeField] private float _period = 2;
 
  //// �������X�V���邩�ǂ���
  //[SerializeField] private bool _updateRotation = true;

  //private void Update()
  //{
  //  var tr = transform;
  //  // ��]�̃N�H�[�^�j�I���쐬
  //  var angleAxis = Quaternion.AngleAxis(360 / _period * Time.deltaTime, _axis);

  //  // �~�^���̈ʒu�v�Z
  //  var pos = tr.position;

  //  pos -= _center;
  //  pos = angleAxis * pos;
  //  pos += _center;

  //  tr.position = pos;

  //  // �����X�V
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