using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop : MonoBehaviour
{
    public List<GameObject> choosed;

    int index;
    
    void Start()
    {
        index = 1;
        // 调用输入检测迭代器
        StartCoroutine(DectorInput());
    }
    
    void Update()
    {
        foreach(GameObject obj in choosed)
        {
            obj.SetActive(false);
        }

        choosed[index - 1].SetActive(true);

        if (Input.GetKey(KeyCode.Escape))
        {
            this.gameObject.SetActive(false);
            GamePersist.GetInstance().hero.inputEnable = true;
        }
    }

    IEnumerator DectorInput()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.2f);
            if (Input.GetKey("a"))
            {
                if (index == 1)
                    index = 6;
                else
                    --index;
            }else if (Input.GetKey("d"))
            {
                if (index == 6)
                    index = 1;
                else
                    ++index;
            }
        }
    }
}
