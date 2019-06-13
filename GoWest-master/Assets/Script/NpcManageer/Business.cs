using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Business : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        GamePersist.GetInstance().subtitle = "啊，你手里有 XX（伙夫赠送的道具），我相信你。";
        StartCoroutine(Delay.DelayToInvokeDo(() =>
        {
            GamePersist.GetInstance().subtitle = "我们从这里出去，到金城关前出关，我这里有文牒。";
        }, 1f));
        StartCoroutine(Delay.DelayToInvokeDo(() =>
        {
            GamePersist.GetInstance().subtitle = "你通关了";
        }, 3f));
    }
}
