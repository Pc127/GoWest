using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedDrug : Item
{
    public override bool Invoke()
    {
        Debug.Log("获得加速");
        GamePersist.GetInstance().hero.speed += 3;
        
        return true;
    }

    IEnumerator DisSpeed()
    {
        yield return new WaitForSeconds(3.0f);
        GamePersist.GetInstance().hero.speed -= 3;
    }
}
