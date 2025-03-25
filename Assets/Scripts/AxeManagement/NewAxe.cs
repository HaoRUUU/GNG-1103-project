using UnityEngine;

public class NewAxe : MonoBehaviour
{
    private void OnTiggerEnter(Collider other)
    {
        // Check if the collided object has a specific tag
        if (other.CompareTag("Tree"))
        {
            Debug.Log("Collided with Tree!");
        }
    }
}
