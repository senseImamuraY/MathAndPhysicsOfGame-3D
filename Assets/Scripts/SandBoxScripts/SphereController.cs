using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{
  private Rigidbody rb;
  // Start is called before the first frame update
  private float speed = 100f;

  void Start()
  {
    rb = this.GetComponent<Rigidbody>();  // rigidbody���擾
    Vector3 force = new Vector3(10.0f, 10.0f, 0.0f) * speed;    // �͂�ݒ�
    rb.AddForce(force);  // �͂�������
  }

  // Update is called once per frame
  void Update()
  {
    //Debug.Log(rb);

  }

  void FixedUpdate()
  {

  }
}
