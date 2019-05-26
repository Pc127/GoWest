using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour
{

    void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKey("e"))
        {
            if (!GamePersist.GetInstance().hero.isHide)
            {
                GamePersist.GetInstance().hero.isHide = true;
                GamePersist.GetInstance().subtitle = "你藏起来了";
                GamePersist.GetInstance().hero.heroRect.Translate(new Vector3(0, 0, 3));
            }
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (GamePersist.GetInstance().hero.isHide)
        {
            GamePersist.GetInstance().hero.isHide = false;
            GamePersist.GetInstance().hero.heroRect.Translate(new Vector3(0, 0, -3));
        }
    }
}
