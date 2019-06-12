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
        propMap.Add("移速道具-云头靴", new SpeedDrug());
        propMap.Add("隐身道具-神隐水", new InvisibleDrug());
        propMap.Add("隐身道具-斗篷", new InvisibleDrug());
        propMap.Add("障碍清除道具-山斧", new ClearAway());
        propMap.Add("开门道具-佛像", new OpenDoor());

        myProps = new List<string>();
        // myProps.Add("SpeedDrug");
        this.isPause = false;
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

    public bool isPause;
}
