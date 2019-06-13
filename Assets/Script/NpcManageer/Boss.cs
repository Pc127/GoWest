using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        GamePersist.GetInstance().subtitle = "啊，官逼民反啊。";
        StartCoroutine(Delay.DelayToInvokeDo(() =>
        {
            if (!GamePersist.GetInstance().hero.isHide)
            {
                GamePersist.GetInstance().subtitle = "你死了";
                StartCoroutine(EndGame());
            }
        }, 1f));
       
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(2.0f);
        Application.LoadLevel(0);

    }
}
