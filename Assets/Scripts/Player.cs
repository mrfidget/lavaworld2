using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    GameObject player;
    CharacterController characterController;
    
    public float translateSpeed = 2.0f;
    public float rotateSpeed = 3.5f;
    private float jumpHeight = 10.0f;
    private float gravity = 20.0f;
    
    private Vector3 moveDirection = Vector3.zero;
    private Vector3 rotation = Vector3.zero;

    public bool isDead;
    private int currentHealth = 1;
    // Start is called before the first frame update
    void Start()
    {
        player = this.gameObject;
        characterController = player.GetComponent<CharacterController>();
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        //checkDeathStatus();
        if (!isDead) {
            movePlayer();
        }
        
    }
    private void checkDeathStatus()
    {
        if (isDead) { return; }
        //if(currentHealth == 0)
        //{
        //    isDead = true;
        //    //player.SetActive(false);
        //    //GetComponent<FirstPersonController>().enabled = false;
        //}

    }
    private void movePlayer()
    {
        if (characterController.isGrounded)
        {
            moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
            moveDirection = player.transform.TransformDirection(moveDirection);
            moveDirection *= translateSpeed;
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpHeight;
            }
        }
        else
        {
            //Debug.Log("not grounded");
        }
        moveDirection.y -= gravity * Time.deltaTime;
        characterController.Move(moveDirection * Time.deltaTime);

        rotation = new Vector3(0, Input.GetAxisRaw("Horizontal") * rotateSpeed * Time.deltaTime, 0);
        rotation = transform.TransformDirection(rotation);
        player.transform.Rotate(rotation);

    }
}
