using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressTrigger : MonoBehaviour
{
    public GameObject sth;

    void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("按键E");
        if (Input.GetKey(KeyCode.E))
        {
            sth.SetActive(true);
            //this.gameObject.SetActive(false);
        }
    }
}
