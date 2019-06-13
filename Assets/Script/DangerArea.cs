using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Internal;

public class DangerArea : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!GamePersist.GetInstance().hero.isHide && GamePersist.GetInstance().hero.isVisible)
        {
            GamePersist.GetInstance().subtitle = "被发现了，你输了";
            StartCoroutine(EndGame());
        }
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(1.0f);
        // 清空道具
        GamePersist.GetInstance().myProps.Clear();
        Application.LoadLevel(GamePersist.GetInstance().currentLevel + 2);
    }
}
