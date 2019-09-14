using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// gestionaire des variables et du deroulement du jeu 
/// </summary>
public class GameManager : MonoBehaviour
{
    #region Gestion singleton

    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            return instance;
        }

        set
        {
            instance = value;
        }
    }


    #endregion



    [SerializeField]
    private bool lockYAxis;//boolean utilisé pour verrouiller la hauteur de spawn des cibles(utilisé pour determiner la difficulté)

    private bool spawned;//indique si une cible est presente

    private bool startWave;//indique le deebur des test
    public bool StartWave
    {
        get
        {
            return startWave;
        }

        set
        {
            startWave = value;
        }
    }

    public bool Spawned
    {
        get
        {
            return spawned;
        }

        set
        {
            spawned = value;
        }
    }

    public int EnemyWaves//indique le numero de cible dans la wave
    {
        get
        {
            return enemyWaves;
        }

        set
        {
            enemyWaves = value;
        }
    }

    public bool LockYAxis
    {
        get
        {
            return lockYAxis;
        }

        set
        {
            lockYAxis = value;
        }
    }

    public string NameLevel//nom de l'environnement
    {
        get
        {
            return nameLevel;
        }

        set
        {
            nameLevel = value;
        }
    }

    public int EnemyWavesMax//nombre de cible par test
    {
        get
        {
            return enemyWavesMax;
        }

        set
        {
            enemyWavesMax = value;
        }
    }

    public bool ShowPrefabs//boolean pour choisir si les  cibles sont visibloes ou non
    {
        get
        {
            return showPrefabs;
        }

        set
        {
            showPrefabs = value;
        }
    }

    private int enemyWaves = 0;
    private int enemyWavesMax = 10;

    private string nameLevel;
    private bool showPrefabs = false;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start ()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        spawned = false;
    }
	

	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.G) && GameObject.FindGameObjectWithTag("Cible") != null)
        {

            showPrefabs = !showPrefabs;//lorsque l'utilisateur appuie sur g on change la visibilité de la cible
        }

        if(GameObject.FindGameObjectWithTag("Cible") != null)
        {
            GameObject.FindWithTag("Cible").GetComponent<MeshRenderer>().enabled = GameManager.Instance.ShowPrefabs;
        }

        if(enemyWaves > EnemyWavesMax)
        {
            GameObject instance = FindObjectOfType<VRTK.Example.Gun>().gameObject;
            instance.SetActive(false);
            DestroyImmediate(instance);
            startWave = false;
        }



    }


}
