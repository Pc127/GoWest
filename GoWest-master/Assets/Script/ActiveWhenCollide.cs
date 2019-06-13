using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveWhenCollide : MonoBehaviour
{
    public GameObject sth;

    void OnTriggerEnter2D(Collider2D other)
    {
        sth.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
