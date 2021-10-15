using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class subCollider : MonoBehaviour
{
    private bool notTakenYet=true;
    private bool mouseReleased=false;
    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            mouseReleased = true;
        }


    }
    



    private void OnTriggerStay2D(Collider2D collision)
    {
        if (notTakenYet && mouseReleased)
        {
              Debug.Log(collision.gameObject.transform.position);
            mouseReleased = false;
              notTakenYet = false;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!notTakenYet)
        {
            notTakenYet = true;
        }
    }

}
