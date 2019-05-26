using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Internal;

public class DangerArea : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!GamePersist.GetInstance().hero.isHide)
        {
            GamePersist.GetInstance().subtitle = "被发现了，你输了";
            StartCoroutine(EndGame());
        }
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(1.0f);
        Application.LoadLevel(0);
       
    }
}
