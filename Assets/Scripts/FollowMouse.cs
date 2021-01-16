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
    private int valueNUI; //1 = Touch, 2 = Eye-Tracking

    public LayerMask interactiveLayer;

    // Start is called before the first frame update
    void Start()
    {
        //Sets target position to current game position on game start
        targetPosition = transform.position;
        valueNUI = NUIManager.Instance.typeOfNUI;
    }

    // Update is called once per frame
    void Update()
    {
        Ray castPoint = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        //Add if for NUI Manager (value NUI). If Touch NUI manager is touch, make target go to that position on mousedown, else use Tobii Gaze position consistently

        if (Physics.Raycast(castPoint, out hit, Mathf.Infinity, interactiveLayer) && (Vector3.Distance(new Vector3(hit.point.x, hit.point.y, hit.point.z), transform.position)) > stopping_distance)
        {
            targetPosition = new Vector3(hit.point.x, hit.point.y, hit.point.z);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }

        targetPosition = new Vector3(hit.point.x, hit.point.y, hit.point.z);
        transform.LookAt(targetPosition);
    }
}
