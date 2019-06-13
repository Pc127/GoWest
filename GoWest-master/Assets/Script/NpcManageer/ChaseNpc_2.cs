using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseNpc_2 : MonoBehaviour
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
    private bool open = false;
    private bool toRight = true;

    void Start()
    {
        this.rect = this.GetComponent<RectTransform>();
        this.origin = this.rect.anchoredPosition3D.x;
        //StartCoroutine(Movement());
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!GamePersist.GetInstance().hero.isHide)
        {
            Invoke("Opennpc", 1f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(open)
        {
            transform.Find("boxcollider").gameObject.SetActive(true);
            if (this.rect.anchoredPosition3D.x < origin || this.rect.anchoredPosition3D.x >= origin + area)
                toRight = false;
            else if (this.rect.anchoredPosition3D.x < origin + area)
                toRight = true;

            // 进行移动
            if (toRight)
                this.rect.anchoredPosition3D += new Vector3(speed, 0, 0);
            else
                this.rect.anchoredPosition3D += new Vector3(0, 0, 0);
        } 
    }
    void Opennpc()
    {
        open = true;
    }
    /*IEnumerator Movement()
    {
        if(open)
        {
            transform.Find("boxcollider").gameObject.SetActive(true);
            while (true)
            {
                if (this.rect.anchoredPosition3D.x < origin || this.rect.anchoredPosition3D.x >= origin + area)
                    toRight = false;
                else if (this.rect.anchoredPosition3D.x < origin + area)
                    toRight = true;

                // 进行移动
                if (toRight)
                    this.rect.anchoredPosition3D += new Vector3(speed, 0, 0);
                else
                    this.rect.anchoredPosition3D += new Vector3(0, 0, 0);

                yield return new WaitForSeconds(0.1f);
            }

        }*/
 }
