using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cook : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        //if (Input.GetKey("e"))
        //{
        GamePersist.GetInstance().subtitle = "你怎么会来这里，他们杀人不眨眼，你快逃吧，只有唯一一条路可以出去，我只知道在山上。";
        StartCoroutine(Delay.DelayToInvokeDo(() =>
        {
            GamePersist.GetInstance().subtitle = "拿着这个信物，找到 XXX，他会带你离开。";
        }, 1f)); 
        //}
    }
}
