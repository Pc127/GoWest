using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour
{

    void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (!GamePersist.GetInstance().hero.isHide)
            {
                // 藏起来
                GamePersist.GetInstance().hero.isHide = true;
                GamePersist.GetInstance().subtitle = "你藏起来了";
                GamePersist.GetInstance().hero.Hide();
            }
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (GamePersist.GetInstance().hero.isHide)
        {
            // 出来
            GamePersist.GetInstance().hero.isHide = false;
            GamePersist.GetInstance().hero.DisHide();
        }
    }
}
