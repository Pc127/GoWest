using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleDoor : MonoBehaviour
{
    public string destination = "PurpleDoor_2_1";
    private bool ismoving = false;
    void OnTriggerStay2D(Collider2D other)
    {
        
        if (Input.GetKey("e")&&!ismoving)
        {
            ismoving = true;
            float temp = GamePersist.GetInstance().hero.speed;
            GamePersist.GetInstance().hero.speed = 0;
            GamePersist.GetInstance().hero.MakeInvisible();
            StartCoroutine(Delay.DelayToInvokeDo(() =>
            {
                GamePersist.GetInstance().hero.sceneRect.position = new Vector3(
                    (GamePersist.GetInstance().hero.sceneRect.position.x + 
                    (this.transform.position.x - GameObject.Find(destination).transform.position.x)), 
                    GamePersist.GetInstance().hero.sceneRect.position.y +
                    (this.transform.position.y - GameObject.Find(destination).transform.position.y),
                    GamePersist.GetInstance().hero.sceneRect.position.z);
                //GamePersist.GetInstance().hero.isVisible = true;
                GamePersist.GetInstance().hero.speed = temp;
                ismoving = false;
            }, 1.5f));
        }
    }
    void Update()
    {
        //Debug.Log(this.transform.position);
        //Debug.Log(GameObject.Find(destination).transform.position);
        Debug.Log(GamePersist.GetInstance().hero.sceneRect.position.x);
        //Debug.Log(this.transform.position.x - GameObject.Find(destination).transform.position.x);
    }
}
