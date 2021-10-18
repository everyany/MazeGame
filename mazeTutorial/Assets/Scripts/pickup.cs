using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
    [SerializeField]
    private GameObject frontOfPlayer;
    private GameObject item;
    private bool pickedUp = false;
    private bool nearby;
 
    void Update()
    {
        if(nearby == true && Input.GetKeyDown(KeyCode.V))
        {
            item.transform.parent = frontOfPlayer.transform;
            pickedUp = true;
        }

        if (Input.GetKeyDown(KeyCode.V) && pickedUp == true)
        {
            item.transform.parent = null;
            pickedUp = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "pickup")
        {
            nearby = true;
            item = collider.gameObject;
        }
    }

    /*void OnTriggerExit2D(Collider2D collider)
    {
        nearby = false;
        Debug.Log(nearby + " " + pickedUp);
    }*/
}
