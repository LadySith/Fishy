using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFollowPlayer : MonoBehaviour
{
    //This is intended to be assigned to an invisible gameObject that will have the camera following it
    public Transform playerToFollow;
    public float speed = 2.0f;
    public float followDistance = 5.0f;

    private void Start()
    {
        this.transform.position = playerToFollow.transform.position;
    }

    private void Update()
    {
        transform.LookAt(playerToFollow.position);

        if((transform.position - playerToFollow.position).magnitude > followDistance)
        {
            transform.Translate(0.0f, 0.0f, speed * Time.deltaTime);
        }
    }
}
