using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class disclaimer : MonoBehaviour
{


    [SerializeField]
    private Text txt;

    [SerializeField]
    private Image img;

    private bool wait1 = false;
    private bool fadein = false;

    void Start()
    {
        StartCoroutine(FadeText());
    }

    void Update()
    {
        if(wait1)
        {
            if(!fadein)
                StartCoroutine(FadeImgIn());
        }

    }

    /// <summary>
    /// fait disparaitre le texte
    /// </summary>
    /// <returns></returns>
    IEnumerator FadeText()
    {
        yield return Attendre();
        for (float i = 2; i >= 0; i -= Time.deltaTime)
        {
            txt.color = new Color(1, 1, 1, i);
            yield return null;
        }
        wait1 = true;
    }

    /// <summary>
    /// fait apparaitre et disparaitre une image
    /// </summary>
    /// <returns></returns>
    IEnumerator FadeImgIn()
    {
        fadein = true;
        
        for (float i = 2; i >= 0; i -= Time.deltaTime)
        {
            img.color = new Color(1, 1, 1, i);
            yield return null;
        }
        SceneManager.LoadScene("Menu");
    }

    IEnumerator Attendre()
    {
        yield return new WaitForSeconds(5.0f);
       
    }
}

