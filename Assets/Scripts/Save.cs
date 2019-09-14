using System;
using System.IO;
using UnityEngine;

public class Save
{
    int nbCible = 0;
    bool upToDate = false;

    //formatage et ecriture de la sauvegarde
    public static void Sauvegarde(int NbBalle, Vector2 positionCible, Vector2 positionTir)
    {
        if (GameManager.Instance.EnemyWaves == 1 && NbBalle == 1)
        {
            date();
        }

        if(NbBalle == 1)
        {
            
            save("\n Cible n° : " + GameManager.Instance.EnemyWaves + "\n");
        }

        save("\t Tire n° : " + NbBalle + "\n");
        save("\t\t Angle de la cible: \n");
        save("\t\t\t Latitude: " + positionCible.x + " °");
        save("\t\t\t Longitude: " + positionCible.y + " °");

        save("\t\tAngle du tir: \n");
        save("\t\t\t Latitude: " + positionTir.x + " °");
        save("\t\t\t Longitude: " + positionTir .y + " °");

        save("\t\tDifférence: \n");
        save("\t\t\t Latitude: " + (positionTir.x-positionCible.x) + " °");
        save("\t\t\t Longitude: " + (positionTir.y-positionCible.y) + " °");


    }
    /// <summary>
    /// ecriture dans un fichier
    /// </summary>
    /// <param name="s"></param>
    static void save(String s)
    {
        if(!File.Exists(Environment.CurrentDirectory + "/Data"))
        {
            Directory.CreateDirectory(Environment.CurrentDirectory + "/Data");
        }

        string path = Environment.CurrentDirectory + "/Data/Log.txt";
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine(s);
        writer.Close();

    }
    /// <summary>
    /// datage du test
    /// </summary>
    static void date()
    {
        DateTime localDate = DateTime.Now;
        string s = "Début du teste: le " + localDate;
        save(s);

    }

}

