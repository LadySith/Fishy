using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MouseManager : MonoBehaviour
{
    //Know what you can interact with
    public LayerMask interactiveLayer;

    //Swap cursors per object
    public Texture2D normal; //default layer
    public Texture2D interactive; //cursor for interactive objects

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        

        if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 50, interactiveLayer.value))
        {
            Cursor.SetCursor(interactive, Vector2.zero, CursorMode.Auto);
        }
        else
        {
            Cursor.SetCursor(normal, Vector2.zero, CursorMode.Auto);
        }
    }
}
