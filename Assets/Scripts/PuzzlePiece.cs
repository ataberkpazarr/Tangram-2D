using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{

    [SerializeField] private Transform point1;
    [SerializeField] private Transform point2;
    [SerializeField] private Transform point3;
    [SerializeField] private Transform point4;
    [SerializeField] private Rigidbody2D rb;
  


    private float startPosX;
    private float startPosY;
    private bool isBeingHeld = false; // if our mouse is holds the piece right now or not
    private Vector3 currentMousePos;
    private bool notTakenYet = true;

    private Mesh me;



    void Update()
    {
        if (isBeingHeld)
        {

            currentMousePos = Input.mousePosition;
            currentMousePos = Camera.main.ScreenToWorldPoint(currentMousePos); //converting the screen point of the mouse to the world point
            gameObject.transform.localPosition = new Vector3(currentMousePos.x-startPosX, currentMousePos.y-startPosY,0);
        }


    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0)) //0 is left mouse button, 1 is the right mouse button
        {
            currentMousePos = Input.mousePosition;
            currentMousePos = Camera.main.ScreenToWorldPoint(currentMousePos); //converting the screen point of the mouse to the world point

            startPosX = currentMousePos.x - transform.localPosition.x;
            startPosY = currentMousePos.y - transform.localPosition.y;
            isBeingHeld = true;
        }
    }

    private void OnMouseUp()
    {
        isBeingHeld = false;

    }
    
 
}
