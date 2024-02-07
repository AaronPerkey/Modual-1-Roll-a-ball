using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public Material[] material;
    Renderer rend;
    public bool hit;
    //bool hit;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
        //hit = false;
    }

    void OnCollisionEnter(Collision other)
    {
        // Check if the object the player collided with has the "Snowball" tag.!hit &&
        if (other.gameObject.CompareTag("Ball"))
        {
            //Change color if hit
            rend.sharedMaterial = material[1];

            //set object to hit
            hit = true;
        }
    }
}
