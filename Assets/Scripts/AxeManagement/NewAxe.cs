using UnityEngine;
using System.Collections;

public class TreeFall : MonoBehaviour
{
    public GameObject objectToDeactivate; // Assign in Inspector
    public GameObject objectToActivate;   // Assign in Inspector
    public int requiredHits = 4;          // Number of axe hits needed
    private int hitCount = 0;             // Counter for axe hits
    private bool hasFallen = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Axe") && !hasFallen)
        {
            hitCount++;  // Count each hit
            Debug.Log("Tree hit count: " + hitCount);

            if (hitCount >= requiredHits)
            {
                hasFallen = true;
                StartCoroutine(FallTree());
            }
        }
    }

    IEnumerator FallTree()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;  // Enable physics

        float elapsedTime = 0;
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = Quaternion.Euler(90, 0, 0) * startRotation;

        while (elapsedTime < 1f)
        {
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, elapsedTime * 2f);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        rb.isKinematic = true;  // Stop movement

        // Activate & Deactivate GameObjects
        if (objectToDeactivate != null) objectToDeactivate.SetActive(false);
        if (objectToActivate != null) objectToActivate.SetActive(true);
    }
}
