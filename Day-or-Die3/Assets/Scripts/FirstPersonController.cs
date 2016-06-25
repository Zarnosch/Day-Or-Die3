using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class FirstPersonController : MonoBehaviour {

	[Header("Movement")]
	public float speed = 6.0F;
    public float maxRunningSpeed = 9F;
    float speedtmp;
	public float jumpSpeed = 13.0F;
    float jumpSpeedtmp;
	public float gravity = 60.0F;

	[Header("Camera View")]
	public float minimumY = -60F;
	public float maximumY = 60F;
	public float sensitivityX = 5F;
	public float sensitivityY = 1F;
    public int upgrades = 0;


	private Vector3 moveDirection = Vector3.zero;

	public CharacterController charaCtrl;

	private float rotationY;
    private bool doubleJump;

	// Use this for initialization
	void Start () {
        speedtmp = speed;
        jumpSpeedtmp = jumpSpeed;
        charaCtrl = GetComponent<CharacterController> ();
	}

    public void upgrade()
    {
        upgrades++;
    }

    public void switchSpeed(int type)
    {
        if(type == 0)
        {
            speed = 0;
            jumpSpeed = 0;
        }
        if (type == 1)
        {
            speed = speedtmp;
            jumpSpeed = jumpSpeedtmp;
        }
    }
	
	// Update is called once per frame
	void Update () {
		if (charaCtrl.isGrounded) {
            if (Input.GetKey(KeyCode.LeftShift)){
                if(speed < maxRunningSpeed)
                {
                    speed *= 1.1f;
                }
            }
            else
            {
                speed = 6F;
            }
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
            if (moveDirection.magnitude != 0)
            {
                gameObject.GetComponent<Stats>().reduceAusdauer(200);
                gameObject.GetComponent<Stats>().setRegTimer(500);
            }
            if (upgrades > 0)
            {
                if (Input.GetButton("Jump"))
                {
                    moveDirection.y = jumpSpeed;
                    gameObject.GetComponent<Stats>().reduceAusdauer(1000);
                    gameObject.GetComponent<Stats>().setRegTimer(1000);
                }
            }
		}
        else
        {
            float tempY = moveDirection.y;       
            moveDirection = new Vector3(Input.GetAxis("Horizontal")*0.75f, 0, Input.GetAxis("Vertical")*0.75f);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            moveDirection.y = tempY;
        }
        moveDirection.y -= gravity * Time.deltaTime;
		charaCtrl.Move(moveDirection * Time.deltaTime);

		float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

		rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
		rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);

		transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);

		Camera.main.transform.position = transform.position;
		Camera.main.transform.localEulerAngles = transform.localEulerAngles;
	}
}
