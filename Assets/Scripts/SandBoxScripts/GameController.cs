using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
  public GameObject ClearUI;
  public GameObject GameOverUI;

  // Update is called once per frame
  void Update()
  {
    int count = GameObject.FindGameObjectsWithTag("Block").Length;
    int count1 = GameObject.FindGameObjectsWithTag("Player").Length;

    if (count == 0)
    {
      ClearUI.SetActive(true);
    }

    if( count1 == 0)
    {
      GameOverUI.SetActive(true);
    }
  }
}
