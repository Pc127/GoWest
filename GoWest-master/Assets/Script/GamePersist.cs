using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePersist
{
    // 构造函数
    private GamePersist()
    {
        // 添加道具 1加速药水 2隐身药水 3障碍清除 4开门道具
        propMap = new Dictionary<string, Item>();
        propMap = new Dictionary<string, Item>();
        propMap.Add("移速道具-云头靴", new SpeedDrug());
        propMap.Add("移速道具-仙女飘", new SpeedDrug());
        propMap.Add("移速道具-飞莲", new SpeedDrug());
        propMap.Add("隐身道具-神隐水", new InvisibleDrug());
        propMap.Add("隐身道具-符纸隐", new InvisibleDrug());
        propMap.Add("隐身道具-斗篷", new InvisibleDrug());
        propMap.Add("障碍清除道具-山斧", new ClearAway());
        propMap.Add("障碍清除道具-炸药", new ClearAway());
        propMap.Add("障碍清除道具-轰天雷", new ClearAway());
        propMap.Add("开门道具-佛像", new OpenDoor());
        propMap.Add("传送道具-符纸门", new AheadDoor());
        propMap.Add("传送道具-飞钩", new TopDoor());
        propMap.Add("探路道具-兔子灯", new Rabbit());
        myProps = new List<string>();
        // myProps.Add("SpeedDrug");
        this.isPause = false;

        levelState = new List<bool>();

        // 初始化关卡状态
        for(int i = 0; i<=4; i++)
        {
            levelState.Add(false);
            // levelState[i] = false;
        }
        // 把第一关设置为当前关卡
        currentLevel = 0;

    }

    // 设计为单例模式
    private static GamePersist gamePersist = null;

    // 获取单例
    public static GamePersist GetInstance()
    {
        if (GamePersist.gamePersist == null)
            GamePersist.gamePersist = new GamePersist();
        return GamePersist.gamePersist;
    }

    // 玩家
    public Hero hero;

    // 音频文件
    public AudioController audio;

    // 字幕
    public string subtitle;

    // 保存现有的道具名称 用于使用与展示
    public List<string> myProps;

    // 各种道具的map
    public Dictionary<string, Item> propMap;

    // 暂停设置
    public bool isPause;

    // 关卡状态 0：未开启 1:通关 2：当前 
    public List<bool> levelState;

    // 当前关卡
    public int currentLevel;
}
