﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hero : MonoBehaviour {

    private Rigidbody2D rigidbody;

    private RectTransform rect;

    // 速度
    public float speed = 20.0f; //手机上420，电脑上140

    // image组件
    private Image image;

    private void Start()
    {
        this.rigidbody = this.GetComponent<Rigidbody2D>();
        // 向全局信息注册
        GamePersist.GetInstance().hero = this;
        image = this.GetComponent<Image>();
        rect = this.GetComponent<RectTransform>();
    }

    // 每帧进行移动
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow)||Input.GetKey("d"))
            this.rect.Translate(new Vector3(speed, 0, 0));
        else if (Input.GetKey(KeyCode.LeftArrow)||Input.GetKey("a"))
            this.rect.Translate(new Vector3(-speed, 0, 0));
    }
}
