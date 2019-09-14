using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroScript : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(IntroCoroutine());
        StartCoroutine(ChangeImage() );
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    /// <summary>
    /// gestion de la rotatio des images pour l'intro
    /// </summary>
    /// <returns></returns>
    IEnumerator IntroCoroutine()
    {
        yield return new WaitForSeconds(5f);
        transform.Find("Intro").GetComponent<AudioSource>().Play();
    }
    /// <summary>
    /// Fonction pour le chargement de l'image du tuto
    /// </summary>
    /// <returns></returns>
    IEnumerator ChangeImage()
    {
        while(true)
        {
            yield return new WaitForSeconds(10f);

            if (GameObject.Find("TutorialImage").GetComponent<Image>().sprite.name == "Tutorial VirtualAudioShoot")
            {
                GameObject.Find("TutorialImage").GetComponent<Image>().sprite = Resources.Load<Sprite>("sprites/Title VirtualAudioShoot");
            }
            else
            {
                GameObject.Find("TutorialImage").GetComponent<Image>().sprite = Resources.Load<Sprite>("sprites/Tutorial VirtualAudioShoot");
            }
        }

    }
}
