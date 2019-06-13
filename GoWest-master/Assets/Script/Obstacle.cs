using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        // 设置人物的障碍物
        GamePersist.GetInstance().hero.obstacle = this.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GamePersist.GetInstance().hero.obstacle = null;
    }
}
