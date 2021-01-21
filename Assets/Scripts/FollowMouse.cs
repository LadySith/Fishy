using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Tobii.Gaming;

public class FollowMouse : MonoBehaviour
{
    public float speed;
    public float stopping_distance;
    //public float rotationOffset;
    private Vector3 targetPosition;
    private int valueNUI; //1 = Touch, 2 = Eye-Tracking
    Vector2 filteredpoint;

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

        if (valueNUI == 1)
        {

            if (Input.GetMouseButtonDown(0))
            {
                //TODO: If raycast hits fish, tween fish
                if (Physics.Raycast(castPoint, out hit, Mathf.Infinity, interactiveLayer) && (Vector3.Distance(new Vector3(hit.point.x, hit.point.y, hit.point.z), transform.position)) > stopping_distance)
                {
                    //TODO: add water ripple
                    targetPosition = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                }
            }
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            transform.LookAt(targetPosition);
        }
        else
        {
            if (TobiiAPI.IsConnected)
            {
                Debug.Log("Tobii eyetracker detected");
                Vector2 gazePoint = TobiiAPI.GetGazePoint().Screen;
                filteredpoint = Vector2.Lerp(filteredpoint, gazePoint, 0.5f);

                Ray castPointTobii = Camera.main.ScreenPointToRay(new Vector3(filteredpoint.x,filteredpoint.y,0));
                RaycastHit hitTobii;
                if (TobiiAPI.GetGazePoint().IsRecent())
                {
                    //Here we use the eyetracking point to move the cursor
                    if (Physics.Raycast(castPointTobii, out hitTobii, Mathf.Infinity, interactiveLayer) && (Vector3.Distance(new Vector3(hitTobii.point.x, hitTobii.point.y, hitTobii.point.z), transform.position)) > stopping_distance)
                    {
                        targetPosition = new Vector3(hitTobii.point.x, hitTobii.point.y, hitTobii.point.z);
                        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                    }
                    transform.LookAt(targetPosition);
                }
            }
            else
            {
                Debug.Log("Eyetracker not connected");
                if (Physics.Raycast(castPoint, out hit, Mathf.Infinity, interactiveLayer) && (Vector3.Distance(new Vector3(hit.point.x, hit.point.y, hit.point.z), transform.position)) > stopping_distance)
                {
                    targetPosition = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                    transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                }
                transform.LookAt(targetPosition);
            }
            
        }

    }
}
