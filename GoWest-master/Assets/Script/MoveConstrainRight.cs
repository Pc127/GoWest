using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveConstrainRight : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        // 设置人物的障碍物
        GamePersist.GetInstance().hero.movestrainright = this.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GamePersist.GetInstance().hero.movestrainright = null;
    }
}
