using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private SpriteRenderer spirte;
    void Start()
    {
        this.spirte = this.GetComponent<SpriteRenderer>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        this.spirte.sortingOrder = 10;
        //GamePersist.GetInstance().subtitle = "啊，官逼民反啊。";
        StartCoroutine(Delay.DelayToInvokeDo(() =>
        {
            if (!GamePersist.GetInstance().hero.isHide)
            {
                GamePersist.GetInstance().hero.heroMove = false;
               //GamePersist.GetInstance().subtitle = "你死了";
               StartCoroutine(EndGame());
            }
        }, 1.5f));
       
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(2.0f);
        GamePersist.GetInstance().myProps.Clear();
        Application.LoadLevel(GamePersist.GetInstance().currentLevel + 2);

    }
}
