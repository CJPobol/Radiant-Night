using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] float delay;
    private Vector2 velocity = Vector2.zero;

    private void Update()
    {
        Player player = FindObjectOfType<Player>();
        if (player == null) return;

        Vector2 targetPosition = player.transform.position + new Vector3(0,2,0);

        // Smoothly move the camera toward the target position in 2D
        Vector2 smoothedPosition = Vector2.SmoothDamp(transform.position, targetPosition, ref velocity, 0.3f);

        // Apply the smoothed position while keeping the camera’s Z position
        transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);
    }

}

