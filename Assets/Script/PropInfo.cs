using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PropInfo : MonoBehaviour
{
    // 文字的ui
    public GameObject bg;

    public Text text;

    void Update()
    {
        string name = null; 
        
        if(GamePersist.GetInstance().prop.index <= GamePersist.GetInstance().myProps.Count)
            name = GamePersist.GetInstance().myProps[GamePersist.GetInstance().prop.index - 1];

        // 输出名字
        Debug.Log(name);

        if (name != null)
        {
            text.text = GamePersist.GetInstance().propInfo[name];
            bg.SetActive(true);
        }
        else
            bg.SetActive(false);
    }
}
