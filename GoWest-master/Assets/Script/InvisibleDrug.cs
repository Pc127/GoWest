using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleDrug : Item
{
    public override bool Invoke()
    {
        Debug.Log("开始隐身");
        GamePersist.GetInstance().hero.MakeInvisible();
        return true;
    }
}