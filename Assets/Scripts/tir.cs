using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordoneesPolaires : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    double distanceTirCible(GameObject casque, GameObject manette, GameObject cible)
    {

        double distance; //distance entre le tir et la cible

        double rayon; //distance entre le casque et la cible

        //trinôme du second degré pour trouver les deux points d'intersection avec la sphère
        double a;
        double b;
        double c;
        double d;

        //point d'intersection 1
        double t1;
        double xInter1;
        double yInter1;
        double zInter1;
        double distance1;

        //point d'intersection 2
        double t2;
        double xInter2;
        double yInter2;
        double zInter2;
        double distance2;

        double xCM = manette.transform.position.x - casque.transform.position.x;
        double yCM = manette.transform.position.y - casque.transform.position.y;
        double zCM = manette.transform.position.z - casque.transform.position.z;

        rayon = Math.Sqrt((cible.transform.position.x - casque.transform.position.x) * (cible.transform.position.x - casque.transform.position.x) +
        (cible.transform.position.y - casque.transform.position.y) * (cible.transform.position.y - casque.transform.position.y) +
        (cible.transform.position.z - casque.transform.position.z) * (cible.transform.position.z - casque.transform.position.z));

        a = xCM * xCM + yCM * yCM + zCM * zCM;
        b = 2 * (manette.transform.position.x + manette.transform.position.y + manette.transform.position.z);
        c = manette.transform.position.x * manette.transform.position.x + manette.transform.position.y * manette.transform.position.y + manette.transform.position.z * manette.transform.position.z - rayon * rayon;

        d = b * b - 4 * a * c;

        t1 = (-b - Math.Sqrt(d)) / (2 * a);
        t2 = (-b + Math.Sqrt(d)) / (2 * a);

        xInter1 = xCM * t1 + manette.transform.position.x;
        yInter1 = yCM * t1 + manette.transform.position.y;
        zInter1 = zCM * t1 + manette.transform.position.z;

        xInter2 = xCM * t2 + manette.transform.position.x;
        yInter2 = yCM * t2 + manette.transform.position.y;
        zInter2 = zCM * t2 + manette.transform.position.z;

        distance1 = Math.Sqrt((cible.transform.position.x - xInter1) * (cible.transform.position.x - xInter1) +
        (cible.transform.position.y - yInter1) * (cible.transform.position.y - yInter1) +
        (cible.transform.position.z - zInter1) * (cible.transform.position.z - zInter1));

        distance2 = Math.Sqrt((cible.transform.position.x - xInter2) * (cible.transform.position.x - xInter2) +
        (cible.transform.position.y - yInter2) * (cible.transform.position.y - yInter2) +
        (cible.transform.position.z - zInter2) * (cible.transform.position.z - zInter2));

        if (distance1 < distance2)
        {
            distance = distance1;
            //creerObjet(xInter1, yInter1, zInter1);
        }
        else
        {
            distance = distance2;
            //creerObjet(xInter2, yInter2, zInter2);
        }

        return distance;

    }


}