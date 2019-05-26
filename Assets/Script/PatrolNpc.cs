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

    void Start()
    {
        this.rect = this.GetComponent<RectTransform>();
        this.origin = this.rect.anchoredPosition3D.x;
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
                this.rect.anchoredPosition3D += new Vector3(speed, 0, 0);
            else
                this.rect.anchoredPosition3D += new Vector3(-speed, 0, 0);

            yield return new WaitForSeconds(0.1f);
        }
    }
}
