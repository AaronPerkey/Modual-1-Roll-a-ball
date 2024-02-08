using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestorySnowball : MonoBehaviour
{
    public GameObject splat;

    //Respawn? snowball prefab and point on table like joejeffsnap ballSpawnLocation
    //public GameObject snowball;
    //public Transform spawnPoint;

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Splatproof")){
            
            Destroy(gameObject);
            gameObject.SetActive(false);
            Instantiate(splat, transform.position, transform.rotation);
            //Respawn?
            //Instantiate(snowball, new Vector3(spawnPoint.position, Quaternion.identity);
        }
    }

}