using UnityEngine;
using Photon.Pun;

public class Gun : MonoBehaviour
{
  public float startTime;
  private float time;
  public GameObject bullet;
  public Transform point;
  private Joystick Joystick;
  private PhotonView view;

private void Awake() {
    view = GetComponent<PhotonView>();
    Joystick = GameObject.FindGameObjectWithTag("AttackJoystick").GetComponent<Joystick>();
    Debug.Log(GameObject.FindGameObjectWithTag("AttackJoystick").GetComponent<Joystick>());
}
  void Update()
  {
    if (view.IsMine){
      Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
      float rotateZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
      // Joystick = GameObject.FindGameObjectWithTag(" Joystick").GetComponent<Joystick>();
      // float rotateZ = Mathf.Atan2(Joystick.Vertical, Joystick.Horizontal) * Mathf.Rad2Deg;
// 
      transform.rotation = Quaternion.Euler(0f, 0f, rotateZ);

      if (time <= 0f)
      {
        if (Input.GetMouseButtonDown(0) || Joystick.Horizontal > 0 || Joystick.Horizontal < 0 || Joystick.Vertical > 0 || Joystick.Vertical < 0)
        {
          Instantiate(bullet, point.position, transform.rotation);
          time = startTime;
        }
      }
      else
      {
        time -= Time.deltaTime;
      }
    }
  }
  public void Rotate()
  {
    Vector3 theScale = transform.localScale;
    theScale.x *= -1;
    transform.localScale = theScale;
  }
}
