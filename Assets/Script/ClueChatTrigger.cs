using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueChatTrigger : MonoBehaviour
{
    public GameObject sth;

    public UIThings myUI;

    void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("按键E");
        if (Input.GetKey(KeyCode.E))
        {
            sth.SetActive(true);
            // 把关键对话赋给ui
            myUI.clueThings = sth;
        }
    }
}
