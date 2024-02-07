using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerScript : MonoBehaviour
{
    public GameObject snowballPrefab;
    private GameObject spawnedSnowball; // Store reference to the spawned snowball

    // Update is called once per frame
    void Update()
    {
        // Check if the left mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            // Cast a ray from the mouse position into the scene
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if the ray hits any GameObject
            if (Physics.Raycast(ray, out hit))
            {
                // Check if the GameObject hit is the spawned snowball
                if (hit.collider.gameObject == spawnedSnowball)
                {
                    // Clicked on the snowball, store reference and start dragging
                    // Store reference to the snowball that was clicked
                    spawnedSnowball = hit.collider.gameObject;
                }
                else
                {
                    // Clicked on empty space, instantiate a new snowball
                    InstantiateSnowball(ray);
                }
            }
            else
            {
                // Clicked on empty space, instantiate a new snowball
                InstantiateSnowball(ray);
            }
        }

        // Check if the left mouse button is being held down (dragging)
        if (Input.GetMouseButton(0) && spawnedSnowball != null)
        {
            // Move the snowball along with the mouse
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float distanceToGround = 0;
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
            if (groundPlane.Raycast(ray, out distanceToGround))
            {
                Vector3 newPos = ray.GetPoint(distanceToGround);
                spawnedSnowball.transform.position = newPos;
            }
        }

        // Check if the left mouse button is released
        if (Input.GetMouseButtonUp(0))
        {
            // Reset the reference to the spawned snowball
            spawnedSnowball = null;
        }
    }

    // Instantiate a new snowball at the mouse position
    void InstantiateSnowball(Ray ray)
    {
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            // Instantiate the snowballPrefab at the hit point
            Instantiate(snowballPrefab, hit.point, Quaternion.identity);
        }
    }
}
