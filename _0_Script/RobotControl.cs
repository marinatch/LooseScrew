using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotControl : MonoBehaviour
{
    private Rigidbody rigid;
    private Vector3 moveDir;
    public float speed, speedRotation, jumpForce;
    public string codeInput;
    //public float shootForce;

    public LayerMask groundMask;
    private bool isGrounded;

    public Vector3 checkPoint;
    //public Transform shootPoint;
    //public GameObject bullet;

    //public int life;
    //public SpawnControl spawn;



    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }


    private void Awake()
    {
        checkPoint = transform.position;
    }
    void Update()
    {
        isGrounded = Physics.OverlapSphere(transform.position, 0.2f, groundMask).Length > 0;

        if (Input.GetButtonDown("Jump" + codeInput) && isGrounded)
        {
            rigid.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        /*if (Input.GetButtonDown("Fire1" + codeInput))
        {
            GameObject newBullet = Instantiate(bullet, shootPoint.position, shootPoint.rotation);
            newBullet.tag = "Bullet" + codeInput;
            Destroy(newBullet, 5);
            newBullet.GetComponent<Rigidbody>().AddForce(newBullet.transform.forward * shootForce);
        }*/
    }
    void FixedUpdate()
    {
        moveDir = new Vector3(0, 0, Input.GetAxis("Horizontal" + codeInput) * speed);
        moveDir = transform.TransformDirection(moveDir);
        //transform.Rotate(Vector3.up * speedRotation * Time.deltaTime * Input.GetAxis("Horizontal" + codeInput));
        rigid.MovePosition(rigid.position + moveDir * Time.deltaTime);
    }

    public void LoadCheckPoint()
    {
        transform.position = checkPoint;
    }

    //Jump Pad
    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "JumpPad") jumpForce = 20;
    }*/

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == (1 << 9)) //numero del layer
        {
            if (other.tag != "Bullet" + codeInput)
            {
                Destroy(other.gameObject);
                life--;
                if (life <= 0)
                {
                    transform.position = spawn.GetSpawnPoint(gameObject);
                    print("You died");
                }
            }
        }
    }*/
}
