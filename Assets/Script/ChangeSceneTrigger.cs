using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSceneTrigger : MonoBehaviour
{
    public int sceneIndex;

    public float delay;

    void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(ChangeScene());
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(delay);
        // 加载场景
        Application.LoadLevel(sceneIndex);
    }
}
