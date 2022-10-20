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
    rb = this.GetComponent<Rigidbody>();  // rigidbody‚ğæ“¾
    Vector3 force = new Vector3(10.0f, 10.0f, 0.0f) * speed;    // —Í‚ğİ’è
    rb.AddForce(force);  // —Í‚ğ‰Á‚¦‚é
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
