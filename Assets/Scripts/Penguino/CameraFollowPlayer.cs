using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;
    public Vector3 offset = new Vector3(0, 5, -5); // Offset to keep the camera behind and above the player

    void LateUpdate()
    {
        // Calculate the desired position based on the player's position and rotation
        Vector3 targetPosition = target.position + target.TransformDirection(offset);

        // Smoothly move the camera to the desired position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

        // Always look at the player
        transform.LookAt(target);
    }
}
