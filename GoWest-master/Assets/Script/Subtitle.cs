using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Subtitle : MonoBehaviour
{
    // text组件
    private Text text;

    // 当前显示的str
    private string mystr;

    void Start()
    {
        mystr = GamePersist.GetInstance().subtitle;
        text = this.GetComponent<Text>();
        StartCoroutine(ShowSubtitle());
    }

    IEnumerator ShowSubtitle()
    {
        while (true)
        {
            text.text = "";
            for(int i = 15; i > 0; --i)
            {
                // 检测到变化时候 更新
                if (mystr != GamePersist.GetInstance().subtitle)
                {
                    mystr = GamePersist.GetInstance().subtitle;
                    text.text = mystr;
                    // 刷新时间
                    i = 10;
                }

                yield return new WaitForSeconds(0.1f);
            }  
        }
    }
}
