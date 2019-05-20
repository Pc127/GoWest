using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Prop : MonoBehaviour
{
    public List<GameObject> choosed;

    // 保存六个道具的图片
    public List<Image> items;

    // 显示图片
    public GameObject show;

    // 当前指向的道具
    int index;
    
    void Start()
    {
        index = 1;
        // 调用输入检测迭代器
        StartCoroutine(DectorInput());
    }
    
    void Update()
    {
        // 被选中的效果
        foreach(GameObject obj in choosed)
        {
            obj.SetActive(false);
        }

        choosed[index - 1].SetActive(true);

        // 更新道具贴图
        for(int i = 0; i<GamePersist.GetInstance().myProps.Count; ++i)
        {
            items[i].sprite = Resources.Load<Sprite>(GamePersist.GetInstance().myProps[i]);
        }
    }

    void Escape()
    {
        GamePersist.GetInstance().hero.inputEnable = true;
        index = 1;
        this.show.SetActive(false);
    }

    IEnumerator DectorInput()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.12f);
            if (this.show.activeSelf == false)
                continue;

            if (Input.GetKey("a"))
            {
                if (index == 1)
                    index = 6;
                else
                    --index;
            }
            else if (Input.GetKey("d"))
            {
                if (index == 6)
                    index = 1;
                else
                    ++index;
            }
            else if (Input.GetKey(KeyCode.E))
            {
                if(index <= GamePersist.GetInstance().myProps.Count)
                {
                    string propName = GamePersist.GetInstance().myProps[index - 1];
                    GamePersist.GetInstance().propMap[propName].Invoke();
                    Escape();
                }
            }
            else if (Input.GetKey(KeyCode.Escape))
            {
                Escape();
            }
        }
    }
}
