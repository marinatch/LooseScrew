using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalls : MonoBehaviour
{
    private Rigidbody rigid;
    public float speed, jumpForce;

    private Vector3 moveDir;
    private GameObject currentWall;



    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDir = new Vector3(Input.GetAxis("Horizontal") * speed, moveDir.y, 0);

        rigid.MovePosition(rigid.position + moveDir * Time.deltaTime);

        if(Input.GetButtonDown("Jump"))
        {
            rigid.AddForce(Vector3.up * jumpForce);
            if(currentWall!=null)
            {
                rigid.AddForce(currentWall.transform.forward * jumpForce);
                currentWall = null;
            }
        }
    }
    private void OntriggerEnter(Collider other)
    {
        if(other.tag=="Wall")
        {
            currentWall = other.gameObject;
            Invoke("CancelWall",0.5f);
        }
    }
    void CancelWall()
    {
        currentWall = null;
    }
}
