﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hero : MonoBehaviour {
    // 速度
    [System.NonSerialized]
    public float speed;

    // 场景 利用场景反向移动
    public GameObject scene;

    // image组件
    private Image image;

    private Rigidbody2D body;

    // 场景的rect
    [System.NonSerialized]
    public RectTransform sceneRect;

    // 主角的rect
    [System.NonSerialized]
    public RectTransform heroRect;

    // 道具栏
    public GameObject prop;

    // 英雄朝向
    [System.NonSerialized]
    public bool faceRight;

    // 是否可以输入
    [System.NonSerialized]
    public bool inputEnable;

    [System.NonSerialized]
    public bool isHide;

    private void Start()
    {
        // 向全局信息注册
        GamePersist.GetInstance().hero = this;
        this.image = this.GetComponent<Image>();
        this.sceneRect = this.scene.GetComponent<RectTransform>();
        this.body = this.GetComponent<Rigidbody2D>();
        this.heroRect = this.GetComponent<RectTransform>();
        // 输入
        inputEnable = true;
        speed = 3;
        // 可以被侦察
        this.isHide = false;
    }

    void Update()
    {
        if (inputEnable == false)
            return;

        // 进行移动
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey("d"))
        {
            this.sceneRect.Translate(new Vector3(-speed, 0, 0));
            this.faceRight = true;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey("a"))
        {
            this.sceneRect.Translate(new Vector3(speed, 0, 0));
            this.faceRight = false;
        }
            

        // 开启 道具栏
        if (Input.GetKey(KeyCode.Tab))
        {
            this.prop.SetActive(true);
            this.inputEnable = false;
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            // 结束游戏
            StartCoroutine(EndGame());
        }
    }


    IEnumerator EndGame()
    {
        GamePersist.GetInstance().subtitle = "游戏即将结束";
        yield return new WaitForSeconds(2.0f);
        Application.Quit();
    }
}
