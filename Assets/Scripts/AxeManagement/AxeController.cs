using UnityEngine;

public class AxeController : MonoBehaviour
{
    public Collider axeTipCollider;  // Drag the axe tip's collider here in the Unity Editor.

    public Rigidbody axeRb;
    private float breakThreshold = 8f; // Adjust based on your needs.

    private void Start()
    {
        axeRb = GetComponent<Rigidbody>();  // Get the Rigidbody of the current object (axe parent)
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the axe tip's collider
        if (collision.contacts[0].thisCollider == axeTipCollider && collision.gameObject.CompareTag("Tree"))
        {
            // Calculate the angle of impact
            float impactAngleFactor = Vector3.Dot(-axeTipCollider.transform.right, collision.contacts[0].normal);

            // Ensure angle factor is non-negative
            impactAngleFactor = Mathf.Abs(impactAngleFactor);

            // Calculate velocity of the axe's tip
            Vector3 tipVelocity = axeRb.GetPointVelocity(axeTipCollider.transform.position);

            // Modify the force based on the impact angle
            float modifiedForce = tipVelocity.magnitude * impactAngleFactor;

            // Check if the impact is strong enough to break the rock
            if (modifiedForce > breakThreshold)
            {
                Debug.Log("tree broken");
                collision.gameObject.transform.parent.GetComponent<TreeController>().BreakTree();
            }
        }
    }
}