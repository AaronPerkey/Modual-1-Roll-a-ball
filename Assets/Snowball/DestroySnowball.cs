using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestorySnowball : MonoBehaviour
{
    public GameObject splat;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Splat")||collision.gameObject.CompareTag("Target"))
        {
            Destroy(gameObject);
            gameObject.SetActive(false);
            Instantiate(splat, transform.position, transform.rotation);
        }
    }

}