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

    // sprite组件
    private SpriteRenderer spirte;

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

    [System.NonSerialized]
    public bool isVisible;

    // 障碍物
    [System.NonSerialized]
    public GameObject obstacle;

    // 门
    [System.NonSerialized]
    public GameObject door;

    // 动画组件
    private Animator animator;

    // 移动范围
    public int begin;

    public int end;

    private void Start()
    {
        // 向全局信息注册
        GamePersist.GetInstance().hero = this;
        this.spirte= this.GetComponent<SpriteRenderer>();
        this.sceneRect = this.scene.GetComponent<RectTransform>();
        this.body = this.GetComponent<Rigidbody2D>();
        this.heroRect = this.GetComponent<RectTransform>();
        this.animator = this.GetComponent<Animator>();
        // 输入
        inputEnable = true;
        speed = 3;
        // 可以被侦察
        this.isHide = false;
        this.isVisible = true;
        // 障碍物
        this.obstacle = null;
        this.door = null;
    }

    void Update()
    {
        if (inputEnable == false)
            return;

        // 进行移动
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey("d"))
        {
            // 未碰到障碍物时前进
            if(obstacle == null && door == null && this.sceneRect.anchoredPosition.x > end)
            {
                this.animator.SetBool("faceRight", true);
                this.animator.SetBool("IsRunning", true);
                this.sceneRect.Translate(new Vector3(-speed, 0, 0));
                this.faceRight = true;
            }  
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey("a"))
        {
            if(this.sceneRect.anchoredPosition.x < begin)
            {
                this.animator.SetBool("faceRight", false);
                this.animator.SetBool("IsRunning", true);
                this.sceneRect.Translate(new Vector3(speed, 0, 0));
                this.faceRight = false;
            }
        }
        else
        {
            this.animator.SetBool("IsRunning", false);
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
            // StartCoroutine(EndGame());
        }
    }


    IEnumerator EndGame()
    {
        GamePersist.GetInstance().subtitle = "游戏即将结束";
        yield return new WaitForSeconds(2.0f);
        Application.Quit();
    }

    public void MakeInvisible()
    {
        Debug.Log("改变透明度");
        spirte.color = new Color(255, 255, 255, 0.1f);
        this.isVisible = false;
        StartCoroutine(MakeVisible());
    }

    IEnumerator MakeVisible()
    {
        yield return new WaitForSeconds(1.5f);
        spirte.color = new Color(255, 255, 255, 1);
        this.isVisible = true;
    }

    public void Hide()
    {
        this.spirte.sortingOrder = 5;
    }

    public void DisHide()
    {
        this.spirte.sortingOrder = 7;
    }
}
