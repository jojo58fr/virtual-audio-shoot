using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolarScript
{
    [SerializeField]
    //public Transform casque;
    //public Vector3 CibleRelativeCasque;
    private Vector3 cibleRelatifCasque;
    private Vector2 cordPolCible;

    public Vector3 CibleRelatifCasque
    {
        get
        {
            return cibleRelatifCasque;
        }
    }

    public Vector2 CordPolCible
    {
        get
        {
            return cordPolCible;
        }
    }

    public PolarScript(GameObject casque, GameObject cible)
    {
        cibleRelatifCasque = casque.transform.InverseTransformPoint(cible.transform.position);
        cordPolCible = CartesianToPolar(CibleRelatifCasque);
    }

    /// <summary>
    /// Conversion d'un Vecteur 3D à des coordonnées polaires
    /// X : latitude Y : Longitude
    /// </summary>
    /// <param name="point"> Un vecteur de 3 dimensions (X,Y,Z) </param>
    /// <returns> Coordonées polaires (X : Latitude Y: Longitude)</returns>
    public Vector2 CartesianToPolar(Vector3 point)
    {
        Vector2 polar;

        //calc longitude
        polar.y = Mathf.Atan2(point.x, point.z);

        //this is easier to write and read than sqrt(pow(x,2), pow(y,2))!
        float xzLen = new Vector2(point.x, point.z).magnitude;
        //atan2 does the magic
        polar.x = Mathf.Atan2(-point.y, xzLen);

        //convert to deg
        polar *= Mathf.Rad2Deg;

        return polar;
    }

    /// <summary>
    /// Conversion des coordonnées polaires à un Vecteur 3D 
    /// </summary>
    /// <param name="polar"> Coordonées polaires (X : Latitude Y: Longitude)</param>
    /// <returns> Un vecteur de 3 dimensions (X,Y,Z) </returns>
    public Vector3 PolarToCartesian(Vector2 polar)
    {

        //an origin vector, representing lat,lon of 0,0. 

        Vector3 origin = new Vector3(0, 0, 1);
        //build a quaternion using euler angles for lat,lon
        var rotation = Quaternion.Euler(polar.x, polar.y, 0);
        //transform our reference vector by the rotation. Easy-peasy!
        Vector3 point = rotation * origin;

        return point;
    }
}
