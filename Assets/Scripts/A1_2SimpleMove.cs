using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A1_2SimpleMove : MonoBehaviour
{
  private Vector3 v3Position = new Vector3(0.0f, 0.5f, 0.0f);
  private float fVelocity = 1.0f;
  // Start is called before the first frame update
  void Start()
  {
    transform.position = v3Position;
  }

  // Update is called once per frame
  void FixedUpdate()
  {
    Vector3 v3Velocity = new Vector3(0.0f, 0.0f, 0.0f);
    v3Velocity.x = Input.GetAxis("Horizontal") * fVelocity;
    //v3Velocity.x = Input.GetAxis("Horizontal");
    v3Velocity.z = Input.GetAxis("Vertical") * fVelocity;

    v3Position += v3Velocity;

    transform.position = v3Position;
    if(transform.position.x > 5.0f)
    {
      transform.position = new Vector3(5.0f, transform.position.y, transform.position.z);
    }
    if (transform.position.x < -5.0f)
    {
      transform.position = new Vector3(-5.0f, transform.position.y, transform.position.z);
    }
  }
}
