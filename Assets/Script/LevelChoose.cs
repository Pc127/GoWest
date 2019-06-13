using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChoose : MonoBehaviour
{
    public List<GameObject> levelChoose;

    public List<GameObject> levelStatePass;

    public List<GameObject> levelStateUnpass;

    // 仅仅开始的时候 更新一下状态
    void Start()
    {
        // 设置当前选择的关卡
        foreach(GameObject lc in levelChoose)
        {
            lc.SetActive(false);
        }

        levelChoose[GamePersist.GetInstance().currentLevel].SetActive(true);

        // 设置关卡的通关状态
        for(int i = 0; i<GamePersist.GetInstance().levelState.Count; ++i)
        {
            if (GamePersist.GetInstance().levelState[i])
            {
                levelStatePass[i].SetActive(true);
                levelStateUnpass[i].SetActive(false);
            }
            else
            {
                levelStatePass[i].SetActive(false);
                levelStateUnpass[i].SetActive(true);
            }
        }
    }

    public void LoadScene(int i)
    {
        // 加载场景编号
        Application.LoadLevel(i+1);
    }

}
