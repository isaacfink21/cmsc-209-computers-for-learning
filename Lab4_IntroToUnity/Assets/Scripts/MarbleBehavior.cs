using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MarbleBehavior : MonoBehaviour
{
    public GameBehavior gameManager;
    public float moveSpeed = 0.01f;
    public float rotateSpeed = 0.05f;
    public float jumpVelocity = 5f;

    private float fbInput;
    private float lrInput;
    private bool jumped;
    public GameObject Blast;
    public float blastSpeed = 100f;
    private Rigidbody _rb;

    void Start()
    {
        //You'll need to add a rigidbody to the marble first
        _rb = GetComponent<Rigidbody>();
        jumped = false;
        gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        // Put code is for movement using the Sprite's native variables here
        fbInput = Input.GetAxis("Vertical") * moveSpeed;
        lrInput = Input.GetAxis("Horizontal") * rotateSpeed;
        this.transform.Translate(Vector3.forward * fbInput * Time.time);
        this.transform.Rotate(Vector3.up * lrInput * Time.time);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Ground")
        {
            jumped = false;
        }
        if(collision.gameObject.name == "Obstacle" || 
            collision.gameObject.name == "X Mover" ||
            collision.gameObject.name == "Z Mover")
        {
           gameManager._playerHP -= 5;
        }
        if(gameManager._playerHP <= 0)
                {
                    gameManager.showWinScreen = -100;
                }
        Debug.Log(collision.gameObject.name);
    }

    void FixedUpdate()
    {
        //Put code that moves the sprite using the RigidBody here
        if(Input.GetKeyDown(KeyCode.Space) && !jumped)
        {
            _rb.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
            jumped = true;
        }

        if (Input.GetMouseButtonDown(0))
        {
            GameObject newblast = Instantiate(Blast, this.transform.position +
              new Vector3(1, 0, 0), this.transform.rotation) as GameObject;
            Rigidbody blastRB = newblast.GetComponent<Rigidbody>();
            blastRB.velocity = this.transform.forward * blastSpeed;
        }
    }

}
