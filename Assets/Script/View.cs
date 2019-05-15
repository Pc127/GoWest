using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View : MonoBehaviour
{
    private RectTransform rect;

    void Start()
    {
        rect = GetComponent<RectTransform>();
        
    }
    void Update()
    {
        if (GamePersist.GetInstance().hero.faceRight)
            rect.localPosition = new Vector3(10, 0, 0);
        else
            rect.localPosition = new Vector3(-10, 0, 0);
    }
}
