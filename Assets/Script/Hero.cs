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

    private RectTransform rect;

    // 道具栏
    public GameObject prop;

    // 英雄朝向
    [System.NonSerialized]
    public bool faceRight;

    // 是否可以输入
    [System.NonSerialized]
    public bool inputEnable;

    private void Start()
    {
        // 向全局信息注册
        GamePersist.GetInstance().hero = this;
        this.image = this.GetComponent<Image>();
        this.rect = this.scene.GetComponent<RectTransform>();
        this.body = this.GetComponent<Rigidbody2D>();
        // 输入
        inputEnable = true;
        speed = 5;
    }

    void Update()
    {
        if (inputEnable == false)
            return;

        // 进行移动
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey("d"))
        {
            this.rect.Translate(new Vector3(-speed, 0, 0));
            this.faceRight = true;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey("a"))
        {
            this.rect.Translate(new Vector3(speed, 0, 0));
            this.faceRight = false;
        }
            

        // 开启 道具栏
        if (Input.GetKey(KeyCode.Tab))
        {
            this.prop.SetActive(true);
            this.inputEnable = false;
        }
    }
}
