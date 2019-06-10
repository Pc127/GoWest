using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 道具的基类
public abstract class Item
{
    // 只有一个方法 被调用时候执行
    abstract public bool Invoke();
}
