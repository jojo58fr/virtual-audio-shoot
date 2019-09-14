using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// grestion du hud au desssus de la sphére 
/// </summary>
public class CanvaScript : MonoBehaviour {

    [SerializeField]
    private GameObject casque;

    [SerializeField]
    private float vitesse;

    [SerializeField]
    private Vector3 offset;
	void Start () {
		
	}
	
	// Update is called once per frame
    /// <summary>
    /// mise a jour de la position du hud
    /// </summary>
	void Update ()
    {
        GameObject instance = GameObject.Find("Gun");

        if (instance != null)
        {
            Vector3 res = instance.transform.Find("Sphere").position;
            transform.position = res + offset;

            float pas = vitesse * Time.deltaTime;
            Vector3 direction = gameObject.transform.position - casque.transform.position;
            gameObject.transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(gameObject.transform.forward, direction, pas, 0.0f));
        }
        else
        {
            GetComponent<Text>().text = "";
        }

	}
}
