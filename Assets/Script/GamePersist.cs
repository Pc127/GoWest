using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePersist
{
    // 构造函数
    private GamePersist()
    {
        // 添加道具加速药水
        propMap = new Dictionary<string, Item>();
        propMap.Add("SpeedDrug", new SpeedDrug());

        myProps = new List<string>();
        // myProps.Add("SpeedDrug");
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

    // 字幕
    public string subtitle;

    // 保存现有的道具名称 用于使用与展示
    public List<string> myProps;

    // 各种道具的map
    public Dictionary<string, Item> propMap;
}
