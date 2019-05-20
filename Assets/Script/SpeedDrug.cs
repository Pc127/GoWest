using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedDrug : Item
{
    public override void Invoke()
    {
        Debug.Log("获得加速");
        GamePersist.GetInstance().hero.speed += 10;
    }
}
