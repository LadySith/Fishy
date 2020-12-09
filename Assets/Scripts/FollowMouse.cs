using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    public float speed;
    public float stopping_distance;
    //public float rotationOffset;
    private Vector3 targetPosition;

    public LayerMask interactiveLayer;

    // Start is called before the first frame update
    void Start()
    {
        //Sets target position to current game position on game start
        targetPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Ray castPoint = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(castPoint, out hit, Mathf.Infinity, interactiveLayer) && (Vector3.Distance(new Vector3(hit.point.x, hit.point.y, hit.point.z), transform.position)) > stopping_distance)
        {
            targetPosition = new Vector3(hit.point.x, hit.point.y, hit.point.z);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }

        targetPosition = new Vector3(hit.point.x, hit.point.y, hit.point.z);
        transform.LookAt(targetPosition);
    }
}
