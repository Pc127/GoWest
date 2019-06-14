using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnQuit : MonoBehaviour
{
    public GameObject sth;

    // Update is called once per frame
    public void Quit()
    {
        sth.SetActive(false);
        GamePersist.GetInstance().hero.inputEnable = true;
    }
}
