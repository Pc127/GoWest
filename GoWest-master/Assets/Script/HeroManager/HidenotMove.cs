using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidenotMove : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D other)
    {
        if (!GamePersist.GetInstance().hero.isHide && Input.GetKey("e"))
        {
            GamePersist.GetInstance().hero.isHide = true;
            GamePersist.GetInstance().hero.speed = 0;
            GamePersist.GetInstance().subtitle = "你藏起来了";
            GamePersist.GetInstance().hero.heroRect.Translate(new Vector3(0, 0, 3));
        }
        StartCoroutine(Delay.DelayToInvokeDo(() =>

        {

            if (GamePersist.GetInstance().hero.isHide && Input.GetKey("e"))
            {
                GamePersist.GetInstance().hero.isHide = false;
                GamePersist.GetInstance().hero.speed = 3;
                GamePersist.GetInstance().subtitle = "你出来了";
                GamePersist.GetInstance().hero.heroRect.Translate(new Vector3(0, 0, -3));
            }

        }, 0.5f));
        
    }
}
