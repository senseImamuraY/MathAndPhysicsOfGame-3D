using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
  Vector3 pos;
  // Start is called before the first frame update
  void Start()
  {
    pos = GameObject.Find("Bar").transform.position;
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKey(KeyCode.RightArrow))
    {
      if (pos.x <= 20)
      {
        this.transform.Translate(0.5f, 0.0f, 0.0f);
      }
    }
    if (Input.GetKey(KeyCode.LeftArrow))
    {
      if (pos.x >= -20)
      {
        this.transform.Translate(-0.5f, 0.0f, 0.0f);
      }
    }
  }
}
