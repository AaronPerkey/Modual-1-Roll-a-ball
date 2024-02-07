using UnityEngine;

public class Respawner : MonoBehaviour
{
    // This method is automatically called when a collision occurs with the GameObject
    void OnCollisionEnter(Collision col)
    {
        // Check if the GameObject collided with has the tag "Player"
        if (col.gameObject.CompareTag("Player"))
        {
            // If the GameObject collided with has the tag "Player", reset the position of the current GameObject to the specified Vector3 position (0, 0, 0)
            Respawn();
        }
    }

    // Method to respawn the GameObject to the specified position
    void Respawn()
    {
        // Reset the position of the current GameObject to the specified Vector3 position (0, 0, 0)
        this.transform.position = new Vector3(0, 0, 0);
    }
}
