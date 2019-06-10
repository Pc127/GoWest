using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearAway : Item
{
    // 清除障碍物
    public override bool Invoke()
    {
        if (GamePersist.GetInstance().hero.obstacle == null)
            return false;
        // 直接设为false
        GamePersist.GetInstance().hero.obstacle.SetActive(false);
        GamePersist.GetInstance().hero.obstacle = null;
        return true;
    }
}
