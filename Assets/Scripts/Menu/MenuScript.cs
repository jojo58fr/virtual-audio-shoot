using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    [SerializeField]
    private GameObject launchPanel, difficultyPanel, levelPanel;
    private bool selectedDifficulty = false, selectedLevel = false, selectedLaunch = false;

    /// <summary>
    /// Choix de l'environnement au joueur
    /// </summary>
    private string nameMap;

    /// <summary>
    /// Gestion de la difficulté au joueur
    /// </summary>
    private bool hard;

    // Use this for initialization
    void Start ()
    {

	}

    /// <summary>
    /// Passage du menu de selection d'environement a celui de selection de niveau de difficulté
    /// et enregistrement du choix du joueur pour la map
    /// </summary>
    /// <param name="nameMap"></param>
    public void ChooseLevel(string nameMap)
    {
        this.nameMap = nameMap;
        levelPanel.SetActive(false);
        difficultyPanel.SetActive(true);
    }

    /// <summary>
    /// Passagre de l'écran de selection de difficulté a celui de lancement
    /// et enregistrement de la difficulté choisis par le joueur
    /// </summary>
    /// <param name="diff"></param>
    public void difficulty(bool diff)
    {
        hard = diff;
        difficultyPanel.SetActive(false);
        launchPanel.SetActive(true);
    }
    /// <summary>
    /// lancement de la partie
    /// </summary>
    public void launchGame()
    {
        GameManager.Instance.LockYAxis = !hard;
        GameManager.Instance.NameLevel = nameMap;
        SceneManager.LoadScene(nameMap);
    }

    /// <summary>
    /// quitter le jeu
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }

}
