using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetProp : MonoBehaviour
{
    public string propName;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("获得了道具" + propName);
        if(GamePersist.GetInstance().myProps.Count < 6)
        {
            if (Input.GetKey(KeyCode.E))
            {
                GamePersist.GetInstance().myProps.Add(propName);
                GamePersist.GetInstance().subtitle = "获得了道具" + propName;
                this.gameObject.SetActive(false);
            }
        }else
        {
            GamePersist.GetInstance().subtitle = "背包已经满了";
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.E))
        {
            GamePersist.GetInstance().myProps.Add(propName);
            GamePersist.GetInstance().subtitle = "获得了道具" + propName;
            this.gameObject.SetActive(false);
        }
    }
}
