using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIThings : MonoBehaviour
{
    public GameObject prop;

    public GameObject clue;

    public GameObject operation;

    public GameObject level;

    public GameObject setup;
    
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    // 开启道具栏
    public void PropBtn()
    {
        this.prop.SetActive(true);
        GamePersist.GetInstance().hero.inputEnable = false;
        GamePersist.GetInstance().audio.PlayAudioClip("打开行囊");
    }

    // 展示线索
    public void ClueBtn()
    {

    }

    // 展示操作设置
    public void OperationBtn()
    {

    }

    // 退出游戏
    public void QuitGame()
    {
        StartCoroutine(EndGame());
    }

    IEnumerator EndGame()
    {
        GamePersist.GetInstance().subtitle = "游戏即将结束";
        yield return new WaitForSeconds(2.0f);
        Application.Quit();
    }

    public void SetupBtn()
    {

    }

    public void LevelBtn()
    {

    }

    public void PauseBtn()
    {

    }

    public void LoadScene(int i)
    {
        // 加载场景编号
        Application.LoadLevel(i + 1);
    }
}
