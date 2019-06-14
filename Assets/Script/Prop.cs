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
    public int index;
    
    void Start()
    {
        index = 1;
        // 调用输入检测迭代器
        StartCoroutine(DectorInput());
        GamePersist.GetInstance().prop = this;
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
        for(int i = 0; i <= 5; ++i)
        {
            // 更新道具
            if (i < GamePersist.GetInstance().myProps.Count)
                items[i].sprite = Resources.Load<Sprite>("道具PNG/" + GamePersist.GetInstance().myProps[i]);
            else
                items[i].sprite = null;
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
            if (this.show.activeSelf == false)
            {
                yield return new WaitForSeconds(0.1f);
                continue;
            }
                

            if (Input.GetKey("a"))
            {
                GamePersist.GetInstance().audio.PlayAudioClip("道具选择");
                if (index == 1)
                    index = 6;
                else
                    --index;
            }
            else if (Input.GetKey("d"))
            {
                GamePersist.GetInstance().audio.PlayAudioClip("道具选择");
                if (index == 6)
                    index = 1;
                else
                    ++index;
            }
            else if (Input.GetKey(KeyCode.E))
            {
                // 使用道具
                if(index <= GamePersist.GetInstance().myProps.Count)
                {
                    string propName = GamePersist.GetInstance().myProps[index - 1];
                    // 调用对应的道具功能
                    bool result = GamePersist.GetInstance().propMap[propName].Invoke();
                    // 消耗道具
                    if(result == true)
                    {
                        // 调用音频
                        GamePersist.GetInstance().audio.PlayAudioClip("使用道具");
                        GamePersist.GetInstance().myProps.Remove(propName);
                        Escape();
                        yield return new WaitForSeconds(0.12f);
                        continue;
                    }
                }
            }
            else if (Input.GetKey(KeyCode.Escape)||Input.GetKey(KeyCode.Q))
            {
                Escape();
                yield return new WaitForSeconds(0.12f);
            }

            yield return new WaitForSeconds(0.1f);
        }
    }
}
