using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalBehavior : MonoBehaviour
{
    public GameBehavior gameManager;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior>();
    }

    void OnCollisionEnter(Collision collision)
    {
       //Put collision code here
       if(collision.gameObject.name == "Marble")
       {
           Destroy(this.gameObject);
           Debug.Log("Goal Hit!");
           gameManager.Goals += 1;
        }
    }
}
