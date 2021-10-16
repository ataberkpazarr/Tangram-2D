using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class subCollider : MonoBehaviour
{
    private bool notTakenYet=true;
    private bool mouseReleased=false;
    private bool ObjectSelected=false;
    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            mouseReleased = true;
            notTakenYet = true;
        }
        else if (Input.GetMouseButtonDown(0))
        {
            ObjectSelected = true;
            notTakenYet = false;
        }


    }
    



    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (notTakenYet && mouseReleased && collision.gameObject.tag != "GeneratedMesh" &&collision.gameObject.tag=="gridPoint")
        {
              Debug.Log(collision.gameObject.transform.position);
            mouseReleased = false;
              notTakenYet = false;
            

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!notTakenYet && ObjectSelected && collision.gameObject.tag != "GeneratedMesh" && collision.gameObject.tag == "gridPoint")
        {
            //notTakenYet = true;
            ObjectSelected = false;
        }
    }

}
