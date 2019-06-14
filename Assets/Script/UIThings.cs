using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity;

public class UIThings : MonoBehaviour
{
    public GameObject prop;

    public GameObject clue;

    [System.NonSerialized]
    // 线索当前的关键对话
    public GameObject clueThings;

    public GameObject operation;

    public GameObject level;

    public GameObject setup;

    public GameObject video;

    // 暂停与继续按钮
    public GameObject pauseBtn;

    public GameObject continueBtn;
    
    void Start()
    {
        clueThings = null;
    }
    
    void Update()
    {
        
    }

    public void NewGame()
    {
        video.SetActive(true);
        StartCoroutine(WaitForVideo());
    }

    IEnumerator WaitForVideo()
    {
        yield return new WaitForSeconds(28);
        LoadScene(1);
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
        if(this.clueThings != null)
            this.clueThings.SetActive(true);
    }

    // 展示操作设置
    public void OperationBtn()
    {
        this.operation.SetActive(true);
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
        GamePersist.GetInstance().subtitle = "想不到吧，我们还没做呢！";
    }

    public void LevelBtn()
    {

    }

    public void PauseBtn()
    {
        // 设置状态
        GamePersist.GetInstance().hero.inputEnable = false;
        GamePersist.GetInstance().isPause = true;
        // 按钮状态
        this.pauseBtn.SetActive(false);
        this.continueBtn.SetActive(true);
    }

    public void ContinueBtn()
    {
        // 设置状态
        GamePersist.GetInstance().hero.inputEnable = true;
        GamePersist.GetInstance().isPause = false;
        // 按钮状态
        this.pauseBtn.SetActive(true);
        this.continueBtn.SetActive(false);
    }

    public void LoadScene(int i)
    {
        // 加载场景编号
        Application.LoadLevel(i + 1);
    }

}
