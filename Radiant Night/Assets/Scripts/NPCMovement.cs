using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    [SerializeField] private float newPosition;

    private void Update()
    {
        if (this.transform.position.y != newPosition)
        {

        }
    }
}
