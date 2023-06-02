using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    private Vector3 playerVector;
    public int speed;
    private void Start() {
    player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void FixedUpdate()
    {
        playerVector = player.position;
        playerVector.z = -10;
        transform.position = Vector3.Lerp(transform.position, playerVector, speed * Time.deltaTime);
    }
}
