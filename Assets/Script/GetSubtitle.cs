using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSubtitle : MonoBehaviour
{
    public string mystr;
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("getSubtile碰撞");
        GamePersist.GetInstance().subtitle = mystr;
    }
}
