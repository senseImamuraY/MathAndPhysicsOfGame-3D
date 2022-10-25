using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerPractice : MonoBehaviour
{ 
  public GameObject ClearUI;
  public GameObject GameOverUI;

  public void Update()
  {
    int count = GameObject.FindGameObjectsWithTag("Block").Length;
    int count1 = GameObject.FindGameObjectsWithTag("Player").Length;

    if (count == 0)
    {
      // ClearUI���A�N�e�B�u�ɂ���
      ClearUI.SetActive(true);
      GameObject player = GameObject.Find("Ball");
      Destroy(player);
    }
    if (count1 == 0 && count != 0)
    {
      //GameOverUI���A�N�e�B�u�ɂ���
      GameOverUI.SetActive(true);
    }
  }
}
