using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowText : MonoBehaviour
{
    public Transform player;

    [SerializeField]
    private float roof = 5.0f;

    public float yOffset = 1.0f;

    void Update()
    {
        // Update the position of the empty GameObject to follow the fighter
        transform.position = player.position + new Vector3(0, yOffset, 0);

        if (transform.position.y > roof)
        {
            transform.position = new Vector3(transform.position.x, roof - 1, 0f);
        }
    }
}
