using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : Item
{
    // 清除障碍物
    public override bool Invoke()
    {
        if (GamePersist.GetInstance().hero.door == null)
            return false;
        // 把门直接设置为false
        GamePersist.GetInstance().hero.obstacle.SetActive(false);
        GamePersist.GetInstance().hero.door = null;
        return true;
    }
}