using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float jumpHeight;
    public Rigidbody2D rigidBody;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask ground;

    private bool secondJump;

    public float throwForce;
    public float forceAccl;
    
    public Transform firePoint;
    public GameObject ninjaStar;

    private bool facingRight;
    private float distToGround;
    private bool grounded;


    // Use this for initialization
    void Start () {
        this.rigidBody = gameObject.GetComponent<Rigidbody2D>();
        throwForce = 0.2F;
        forceAccl = 0.2F;
        facingRight = true;
        distToGround = gameObject.GetComponent<CircleCollider2D>().bounds.extents.y;
        //.bounds.extents.y;
    }

    void FixedUpdate()
    {

        
    }

    // Update is called once per frame
    void Update () {
        

        //isOnGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, ground);
        grounded = Physics2D.Raycast(transform.position - new Vector3(0, 0.85F*transform.localScale.y, 0), -Vector3.up, 0.05F);
        Debug.DrawRay(transform.position - new Vector3(0, transform.localScale.y, 0), -Vector3.up, Color.magenta);




        if (Input.GetKey(KeyCode.W) && grounded)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpHeight);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rigidBody.velocity = new Vector2(-moveSpeed, rigidBody.velocity.y);
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rigidBody.velocity = new Vector2(moveSpeed, rigidBody.velocity.y);
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (throwForce < 10)
            {
                throwForce += forceAccl;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            Quaternion rotation = Quaternion.Euler(0.0F, 0.0F, Mathf.Atan2(throwForce, throwForce / 2) * Mathf.Rad2Deg);
         
            if (!facingRight) {
                throwForce = 0 - throwForce;
            }
            GameObject newBox = (GameObject)Instantiate(ninjaStar, firePoint.position, firePoint.rotation);
            newBox.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(throwForce, Mathf.Abs(throwForce / 2.5F));
            newBox.gameObject.GetComponent<Rigidbody2D>().AddTorque(-1.5F*throwForce);
      
            //newBox.transform.Rotate(Vector3(0, speed, 0));
            
            throwForce = 0.1F;
        }


    }
}
