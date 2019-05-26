using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerArea : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        GamePersist.GetInstance().subtitle = "被发现了，你输了";
    }
}
