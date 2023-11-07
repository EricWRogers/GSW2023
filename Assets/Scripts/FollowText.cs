using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowText : MonoBehaviour
{
    public Transform player;

    public float yOffset = 1.0f;

    void Update()
    {
        // Update the position of the empty GameObject to follow the fighter
        transform.position = player.position + new Vector3(0, yOffset, 0); // Adjust yOffset as needed
    }
}
