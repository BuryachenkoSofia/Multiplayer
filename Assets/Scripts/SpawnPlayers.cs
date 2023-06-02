using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject player;
    public float minX, minY, maxX, maxY;
    void Start()
    {
        Vector2 position = new Vector2 (Random.Range (minX, maxX), Random.Range(minY, maxY));
        PhotonNetwork.Instantiate (player.name, position, Quaternion.identity);
    }

}
