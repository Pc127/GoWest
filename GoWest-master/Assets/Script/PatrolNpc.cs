using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolNpc : MonoBehaviour
{
    // 获得rect transform用来进行移动
    private RectTransform rect;

    // 移动速度
    public float speed;

    // 移动范围
    public float area;

    // 记录初始位置
    // y位置
    private float origin;

    // 碰撞体
    private BoxCollider2D box;

    // sp
    private SpriteRenderer sp;

    void Start()
    {
        this.rect = this.GetComponent<RectTransform>();
        this.origin = this.rect.anchoredPosition3D.x;
        this.box = this.GetComponent<BoxCollider2D>();
        this.sp = this.GetComponent<SpriteRenderer>();
        StartCoroutine(Movement());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Movement()
    {
        bool toRight = true;

        while (true)
        {
            if (this.rect.anchoredPosition3D.x > origin + area)
                toRight = false;
            else if (this.rect.anchoredPosition3D.x < origin - area)
                toRight = true;

            // 进行移动
            if (toRight)
            {
                this.box.offset = new Vector2(5, 0);
                this.rect.anchoredPosition3D += new Vector3(speed, 0, 0);
                this.sp.flipX = true;
            }

            else
            {
                this.rect.anchoredPosition3D += new Vector3(-speed, 0, 0);
                this.box.offset = new Vector2(-5, 0);
                this.sp.flipX = false;
            }
                

            yield return new WaitForSeconds(0.1f);
        }
    }
}
