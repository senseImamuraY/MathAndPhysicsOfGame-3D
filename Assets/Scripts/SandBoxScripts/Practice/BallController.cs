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

    // ����͖{�̂���]�����Ă��邽�߁A���ˊp�x�̒����͂ł��Ȃ��B
    //// y�������ɂ���5�x�Ax�������ɂ���5�x�A��]������Quaternion���쐬�i�ϐ���rot�Ƃ���j
    //Quaternion rot = Quaternion.Euler(0, 3, 3);
    //// ���݂̎��M�̉�]�̏����擾����B
    //Quaternion q = this.transform.rotation;
    //// �������āA���g�ɐݒ�
    //this.transform.rotation = q * rot;
    // �p�x�����W�A���ɕϊ�
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
// ���j
// �J�[�\���̓�����x y�̒l�𒲐�����
// �J�����̉�]�����p����
//�@