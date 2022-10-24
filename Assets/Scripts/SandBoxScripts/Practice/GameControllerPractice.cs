using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerPractice : MonoBehaviour
{
  public GameObject ClearUI;
  // Start is called before the first frame update
  void Start()
  {
    
  }

  // Update is called once per frame
  void Update()
  {
    int count = GameObject.FindGameObjectsWithTag("Block").Length;

    if( count ==  0)
    {
      ClearUI.SetActive(true);
    }
  }
}
