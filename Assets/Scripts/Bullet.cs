using Photon.Pun;
using UnityEngine;

public class Bullet : MonoBehaviour
{
  public float speed, distance;
  public int damage = 5;
  public GameObject destroyEffect, bloodSplash;
  public LayerMask layerMask;
  private PhotonView view;

  private void Awake()
  {
    view = GetComponent<PhotonView>();
  }

  void Update()
  {
    transform.Translate(Vector3.right * speed * Time.deltaTime);

  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.tag == "Ground")
    {
      Destroy(gameObject);
    }
  }
  public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
  {
    if (stream.IsWriting)
    {
      stream.SendNext(gameObject.transform);
    }
  }
}