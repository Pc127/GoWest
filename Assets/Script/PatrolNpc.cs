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
    private float origin;

    void Start()
    {
        this.rect = this.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Movement()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.12f);
        }
    }
}
