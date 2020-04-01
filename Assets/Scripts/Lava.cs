using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    private float translateSpeed = 0.1f;
    public Vector3 upperYBound = new Vector3(0,1.3f,0);
    public Vector3 lowerYBound = new Vector3(0, 0.1f, 0);
    private Vector3 moveDirection = Vector3.zero;

    private short flipYtransform = 1;

    GameObject lava;
    
    // Start is called before the first frame update
    void Start()
    {        
        lava = this.gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        moveLava();
    }

    void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if(player != null)
        {
            player.isDead = true;
        }
    }

    void moveLava()
    {
        if ((lava.transform.position.y >= upperYBound.y) || (lava.transform.position.y <= lowerYBound.y))
        {
            flipYtransform *= -1;
        }
        moveDirection = flipYtransform * new Vector3(0, (lava.transform.position.y + translateSpeed) * Time.deltaTime, 0);
        lava.transform.position = lava.transform.position + moveDirection;
    }
}
