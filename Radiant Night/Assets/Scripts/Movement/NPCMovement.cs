using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    [SerializeField] public string NPCName;
    [SerializeField] private Sprite sprite;
    [SerializeField] private Transform startingPosition;

    public GameObject[] waypoints;  // Array of waypoints for the NPC to follow
    private int currentWaypointIndex = 0;  // Keeps track of the current waypoint
    public float speed = 2f;  // Movement speed of the NPC
    public bool isWaiting;

    public bool stepBased; //allows for moving here, something happens, then moving there.
    public bool looping; //allows for repeating movement patterns

    void Start()
    {
        if (startingPosition)
        {
            transform.position = startingPosition.position;
        }
        // Fallback if no starting position: Ensure the NPC is at the first waypoint at the start
        else if (waypoints.Length > 0)
        {
            transform.position = waypoints[0].transform.position;
        }
        isWaiting = stepBased;  // Start waiting if step-based is enabled

        if (!stepBased)
        {
            StartCoroutine(MoveAlongWaypoints());  // Start movement immediately if not step-based
        }
    }

    public void StartMoving()
    {
        StartCoroutine(MoveAlongWaypoints());
    }

    private IEnumerator MoveAlongWaypoints()
    {
        // Loop through each waypoint
        while (currentWaypointIndex < waypoints.Length)
        {
            if (isWaiting) yield break;
            else
            {
                Transform targetWaypoint = waypoints[currentWaypointIndex].transform;
                Vector3 startPosition = transform.position;
                float journeyLength = Vector3.Distance(startPosition, targetWaypoint.position);
                float journeyTime = journeyLength / speed; // Ensures constant speed
                float elapsedTime = 0f;

                Debug.Log("Moving to waypoint: " + currentWaypointIndex + " | Distance: " + journeyLength);

                while (elapsedTime < journeyTime)
                {
                    transform.position = Vector3.Lerp(startPosition, targetWaypoint.position, elapsedTime / journeyTime);
                    elapsedTime += Time.deltaTime;
                    yield return null;
                }

                transform.position = targetWaypoint.position; // Snap to exact position
                currentWaypointIndex++;
                if (stepBased)
                {
                    WaitAtWaypoint(); // stop and wait for a next waypoint tag in dialogue
                    yield break;
                }
            }

        }
        
    }

    // Set the NPC to stop and wait for the player (when dialogue starts)
    public void WaitAtWaypoint()
    {
        isWaiting = true;
    }

    // Set the NPC to stop waiting and resume movement
    public void StopWaiting()
    {
        isWaiting = false;
        StopCoroutine(MoveAlongWaypoints());
        StartCoroutine(MoveAlongWaypoints());
    }

}
