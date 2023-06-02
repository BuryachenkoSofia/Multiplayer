using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class MenuManeger : MonoBehaviourPunCallbacks
{
  public InputField createInput, joinInput, nameInput;
  private void Start() {
    PhotonNetwork.ConnectUsingSettings();
    nameInput.text = PlayerPrefs.GetString("name");
    PhotonNetwork.NickName = nameInput.text;
  }
  public void CreateRoom()
  {
    RoomOptions roomOptions = new RoomOptions();
    roomOptions.MaxPlayers = 4;
    PhotonNetwork.CreateRoom(createInput.text, roomOptions);
  }
  public void JoinRoom()
  {
    PhotonNetwork.JoinRoom(joinInput.text);
  }
  public override void OnJoinedRoom()
  {
    PhotonNetwork.LoadLevel("Game");
  }
  public void SaveName(){
    PlayerPrefs.SetString("name", nameInput.text);
    PhotonNetwork.NickName = nameInput.text;
  }
}
