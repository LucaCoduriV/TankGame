using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayerController2D : MonoBehaviour
{

    Rigidbody2D player;

    public float cannonRotationVelocity = 50;
    public float tankVelocity = 10;
    public float acceleration = 10;

    private Vector2 speedTarget;
    private Vector2 currentVelocity = Vector2.zero;

    private float movementSmoothing = .00005f;
    private float maxCannonAngle = 70;
    private float minCannonAngle = -10;

    private GameObject cannonPivot;
    private GameObject bulletController;
    public bool facingRight = true;
    private bool onGround = true;


    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        cannonPivot = GameObject.Find("Tank/cannonPivot");
        bulletController = GameObject.Find("BulletController");



    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if(transform.eulerAngles.z < 0)
        {
           // Debug.Log(cannonPivot.transform.eulerAngles.z + transform.eulerAngles.z);
        }
        else
        {
           // Debug.Log(cannonPivot.transform.eulerAngles.z - transform.eulerAngles.z);
        }
        
    }


    public void GoRight()
    {
        if (!facingRight) Flip();
        if (onGround)
        {
            speedTarget = new Vector2(tankVelocity, player.velocity.y);
            player.AddForce(Vector2.right * tankVelocity);
        } 
    }

    public void GoLeft()
    {
        if (facingRight) Flip();
        if (onGround)
        {
            speedTarget = new Vector2(-tankVelocity, player.velocity.y);
            player.AddForce(Vector2.left * tankVelocity);
        }
    }

    public void CannonUp()
    {
        //verifier si le cannon a atteint la hauteur maximale
        if (cannonPivot.transform.eulerAngles.z - transform.eulerAngles.z <= maxCannonAngle)
        {
            cannonPivot.transform.Rotate(new Vector3(0, 0, cannonRotationVelocity * Time.deltaTime));
        }
        
    }

    public void CannonDown()
    {
        //verifier si le cannon a atteint la hauteur minimale
        if (cannonPivot.transform.eulerAngles.z - transform.eulerAngles.z >= minCannonAngle)
        {
            cannonPivot.transform.Rotate(new Vector3(0, 0, -cannonRotationVelocity * Time.deltaTime));
        }
        
    }

    public void shoot()
    {
        bulletController.GetComponent<BulletController>().BulletSelector(cannonPivot);
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        //on check si les roues sont en contacte
        if(collision.otherCollider is CircleCollider2D)
        {
            onGround = true;
            
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //on check si les roues ne sont pas en contacte
        if (collision.otherCollider is CircleCollider2D)
        {
            onGround = false;
        }
    }
}
