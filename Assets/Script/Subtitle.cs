using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Subtitle : MonoBehaviour
{
    private Text text;

    private string mystr;
    void Start()
    {
        mystr = GamePersist.GetInstance().subtitle;
        text = this.GetComponent<Text>();
        StartCoroutine(ShowSubtitle());
    }

    IEnumerator ShowSubtitle()
    {
        while (true)
        {
            text.text = "";
            if(mystr != GamePersist.GetInstance().subtitle)
            {
                mystr = GamePersist.GetInstance().subtitle;
                text.text = mystr;
                yield return new WaitForSeconds(1.0f);
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
