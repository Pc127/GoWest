using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour
{
    public string departure = "ground";
    public string destination = "PurpleDoor_2_1";
    private string temp;
    private bool ismoving = false;
    void OnTriggerStay2D(Collider2D other)
    {

        if (Input.GetKey("e") && !ismoving)
        {
            ismoving = true;
            float speedtemp = GamePersist.GetInstance().hero.speed;
            GamePersist.GetInstance().hero.speed = 0;
            Vector3 startposition = GamePersist.GetInstance().hero.sceneRect.position;
            Vector3 endposition = new Vector3
                    (GamePersist.GetInstance().hero.sceneRect.position.x ,
                    GamePersist.GetInstance().hero.sceneRect.position.y +
                    (GameObject.Find(departure).transform.position.y - GameObject.Find(destination).transform.position.y),
                    GamePersist.GetInstance().hero.sceneRect.position.z);
           if(this.transform.position.x - GameObject.Find(destination).transform.position.x>0)
            {
                endposition.x += 10;
            }
            else
            {
                endposition.x -= 10;
            }
            StartCoroutine(Delay.DelayToInvokeDo(() =>
            {
                GamePersist.GetInstance().hero.sceneRect.position = endposition;
                //GamePersist.GetInstance().hero.isVisible = true;
                GamePersist.GetInstance().hero.speed = speedtemp;
                ismoving = false;
            }, 0.5f));
            temp = departure;
            departure = destination;
            destination = temp;
        }
    }
    void Update()
    {
        //Debug.Log(this.transform.position);
        //Debug.Log(GameObject.Find(destination).transform.position);
        Debug.Log(GamePersist.GetInstance().hero.sceneRect.position.x);
        //Debug.Log(this.transform.position.x - GameObject.Find(destination).transform.position.x);
    }
    /*
    private bool ismove = false;
    public float index;
    void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKey("e")&&!ismove)
        {
            ismove = false;
            //transform.position = Vector3.MoveTowards(start.position, end.position, speed * Time.deltaTime);
            if (this.transform.rotation.z>0&& this.transform.position.y > GamePersist.GetInstance().hero.transform.position.y)
            {
                GamePersist.GetInstance().hero.sceneRect.Translate(new Vector3(0,-GamePersist.GetInstance().hero.speed*index, 0));
                GamePersist.GetInstance().hero.faceRight = true;
            }
            else if (this.transform.rotation.z<0&& this.transform.position.y > GamePersist.GetInstance().hero.transform.position.y) 
            {
                GamePersist.GetInstance().hero.sceneRect.Translate(new Vector3(0,-GamePersist.GetInstance().hero.speed* index, 0));
                GamePersist.GetInstance().hero.faceRight = false;
            }
            else if (this.transform.rotation.z > 0&&this.transform.position.y <= GamePersist.GetInstance().hero.transform.position.y)
            {
                GamePersist.GetInstance().hero.sceneRect.Translate(new Vector3(0, GamePersist.GetInstance().hero.speed* index, 0));
                GamePersist.GetInstance().hero.faceRight = false;
            }
            else if (this.transform.rotation.z < 0 && this.transform.position.y > GamePersist.GetInstance().hero.transform.position.y)
            {
                GamePersist.GetInstance().hero.sceneRect.Translate(new Vector3(0, GamePersist.GetInstance().hero.speed* index, 0));
                GamePersist.GetInstance().hero.faceRight = true;
            }
        }
    }*/
}
