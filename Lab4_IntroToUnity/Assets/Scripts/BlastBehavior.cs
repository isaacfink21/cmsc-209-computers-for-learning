using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BlastBehavior : MonoBehaviour {
public float blastDelay = 3f;
    void Start () 
    {
        Destroy(this.gameObject, blastDelay);
    }
}