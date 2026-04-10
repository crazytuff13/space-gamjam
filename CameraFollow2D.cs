using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    public Transform target;          // Player transform
    public float smoothSpeed = 5f;    // Higher = snappier, lower = smoother
    public Vector3 offset;            // Optional offset

    void LateUpdate()
    {
        if (target == null) return;

        // Desired camera position
        Vector3 desiredPos = target.position + offset;

        // Lock Z axis to -10 for 2D camera
        desiredPos.z = -10f;

        // Smooth movement
        Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed * Time.deltaTime);

        // Apply the position
        transform.position = smoothedPos;
    }
}
