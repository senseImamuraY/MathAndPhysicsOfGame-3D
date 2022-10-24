using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
  public float speed = 700;
  private float fAngle = 2.0f * Mathf.PI;
  public float aChanger;
  // public GameObject ball;
  
  // Start is called before the first frame update
  void Start()
  {
    aChanger = 4.0f;
    Rigidbody rb = GetComponent<Rigidbody>();
    Debug.LogFormat("fAngle"+ fAngle + "Cos" + Mathf.Cos(fAngle / aChanger)+ "Sin" + Mathf.Sin(fAngle / aChanger));
    Debug.LogFormat("fAngle"+ fAngle + "Cos" + Mathf.Cos(Mathf.PI)+ "Sin" + Mathf.Sin(1));
    
    Vector3 force = new Vector3(Mathf.Sin(1.0f / 2.0f * Mathf.PI), Mathf.Cos(Mathf.Sqrt(3) / 2.0f), 0) * speed;
    //Vector3 force = new Vector3(Mathf.Cos(Mathf.Sqrt(3) / 2.0f), Mathf.Sin(1.0f / 2.0f * Mathf.PI), 0) * speed;
    //Vector3 force = new Vector3(Mathf.Cos(fAngle / aChanger), Mathf.Sin(fAngle / aChanger), 0) * speed;
    rb.AddForce(force);
  }

  // Update is called once per frame
  void Update()
  {
     
  }
}
