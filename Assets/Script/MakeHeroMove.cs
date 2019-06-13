using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeHeroMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 碰撞
    void OnTriggerEnter2D(Collider2D other)
    {
        GamePersist.GetInstance().hero.heroMove = true;
    }
}
