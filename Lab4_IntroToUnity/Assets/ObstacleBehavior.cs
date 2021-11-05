using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ObstacleBehavior : MonoBehaviour
{
    public GameBehavior gameManager;
    public int obsHealth; 


    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior>();
        obsHealth = 100;
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Blast(Clone)")
        {
            //this.gameManager.ObstacleHealth -= 10;
            obsHealth -= 10;
            Debug.LogFormat("{0}", obsHealth);
            if(obsHealth <= 0)
            {
                Destroy(this.gameObject);
            }
        }

    }
}