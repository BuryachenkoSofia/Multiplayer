using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class GameManeger : MonoBehaviourPunCallbacks
{
  public void Leave()
  {
    PlayerPrefs.SetFloat("HP", 100);
    PhotonNetwork.LeaveRoom();
  }
  public override void OnLeftRoom()
  {
    // base.OnLeftRoom();
    SceneManager.LoadScene(0);
  }
}
