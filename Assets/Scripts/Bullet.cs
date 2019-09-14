using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets;
/// <summary>
/// Gestion des balles
/// </summary>
public class Bullet : MonoBehaviour {

    // Use this for initialization

    private GameObject Target;

    [SerializeField]
    private GameObject Player;
    #region Coordonnées joueur
    private float xP;

    private float zP;
    #endregion
    #region Coordonnée cible
    private float xT;

    private float zT;
    #endregion

    void Start () {
        Target = GameObject.FindGameObjectWithTag("Cible");
    }
	
	// Update is called once per frame
	void Update () {

        
       

    }
    /// <summary>
    /// destruction de la balle sur collision
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Mur")
        {
            Debug.Log("La balle est rentrée dans le mur. Effacement de la balle");

            //Avant on save ici
            FindObjectOfType<VRTK.Example.Gun>().DestroyBullet(false);
        }
    }


}
