using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class Player : MonoBehaviour, IPunObservable {
  private float x, y;
  public float speed, HP;
  public bool fasing;
  public Text textName, textHP;
  private Rigidbody2D rb;
  private Joystick joystick;
  private PhotonView view;
  public GameObject gun;

  void Start()
  {
    gameObject.GetComponent<Gun>().enabled = true;
    rb = GetComponent<Rigidbody2D>();
    view = GetComponent<PhotonView>();
    HP = 100f;
    textName.text = view.Owner.NickName;
    joystick = GameObject.FindGameObjectWithTag("Joystick").GetComponent<Joystick>();
    if (view.Owner.IsLocal)
    {
      Camera.main.GetComponent<CameraFollow>().player = gameObject.transform;
    }
  }

  private void Update()
  {
    textHP.text = "" + HP;
    // float rotateZ = Mathf.Atan2(joystick.Vertical, joystick.Horizontal) * Mathf.Rad2Deg;
    x = joystick.Horizontal * speed;
    y = joystick.Vertical * speed;

    if (view.IsMine)
    {
      if (fasing){
        textName.transform.localEulerAngles = new Vector3(0, 180, 0);
        textHP.transform.localEulerAngles = new Vector3(0, 180, 0);
      }
      if (!fasing)
      {
        textName.transform.localEulerAngles = new Vector3(0, 0, 0);
        textHP.transform.localEulerAngles = new Vector3(0, 0, 0);
      }

      rb.velocity = new Vector2(x, y);

      Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
      Vector2 moveAmount = moveInput.normalized * speed * Time.deltaTime;
      transform.position += (Vector3)moveAmount;

      float h = Input.GetAxis("Horizontal") * speed * Time.fixedDeltaTime;

      if (h > 0 && fasing) { Flip(); }
      else if (h < 0 && !fasing) { Flip(); }

      if (x > 0 && fasing) { Flip(); }
      else if (x < 0 && !fasing) { Flip(); }
    }
  }


  private void Flip()
  {

      Vector3 theScaleGun = gun.transform.localScale;
      theScaleGun.x *= -1;
      gun.transform.localScale = theScaleGun;

    fasing = !fasing;
    Vector3 theScale = transform.localScale;
    theScale.x *= -1;
    transform.localScale = theScale;
  }
  private void OnCollisionEnter2D(Collision2D other) {
    if(view.IsMine){
      HP = HP - 5;
    }
  }

  public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
  {

    if(stream.IsWriting){
      stream.SendNext(HP);
    }
    else{
      HP = (float) stream.ReceiveNext();
    }
  }
}
