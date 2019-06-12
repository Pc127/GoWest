using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public List<AudioClip> myAudio;

    private Dictionary<string, AudioClip> myDic;

    private AudioSource audioSource;

    void Start()
    {
        // 注册自己
        GamePersist.GetInstance().audio = this;

        // 获取组件
        audioSource = GetComponent<AudioSource>();

        myDic = new Dictionary<string, AudioClip>();

        foreach (AudioClip ac in myAudio)
        {
            // Debug.Log("音频文件名" + ac.name);
            // 加载到map中
            myDic.Add(ac.name, ac);
        }

        // PlayAudioClip("木门");
        
    }

    public void PlayAudioClip(string acName)
    {
        // 播放音频
        audioSource.PlayOneShot(myDic[acName]);
    }
}
