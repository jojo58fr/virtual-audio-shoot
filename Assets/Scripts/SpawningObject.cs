using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningObject : MonoBehaviour
{

    [SerializeField]
    private float Range;

    private float spawnX;

    private float spawnY;

    private float spawnZ;

    [SerializeField]
    private VRTK.Example.Gun instance;

    // Use this for initialization
    void Start () {
        spawnX = transform.position.x;
        spawnY = transform.position.y;
        spawnZ = transform.position.z;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!GameManager.Instance.Spawned && GameManager.Instance.StartWave && GameManager.Instance.EnemyWaves < GameManager.Instance.EnemyWavesMax)
        {

            /* var position = new Vector3(Random.Range(spawnX - Range, spawnX + Range), Random.Range(spawnY, spawnY + Range), Random.Range(spawnZ - Range, spawnZ + Range));
             GameObject Instance = Instantiate(cible, position, Quaternion.identity);
             //StartCoroutine(gestionItem(Instance, 3));
             spawned = true;*/

            StartCoroutine(spawnTarget());

            GameManager.Instance.Spawned = true;
        }
    }



    IEnumerator spawnTarget()
    {
        instance.setNbTir(0);
        var position = new Vector3(0, 0, 0);

        if (GameManager.Instance.LockYAxis == true)
        {
            position = new Vector3(Random.Range(spawnX - Range, spawnX + Range), 41f, Random.Range(spawnZ - Range, spawnZ + Range));
        }
        else
        {
            position = new Vector3(Random.Range(spawnX - Range, spawnX + Range), Random.Range(spawnY, spawnY + Range), Random.Range(spawnZ - Range, spawnZ + Range));
        }

        //avant cible
        GameObject Instance = Instantiate(Resources.Load<GameObject>("Prefabs/Target"), position, Quaternion.identity);
        GameObject.FindWithTag("Cible").GetComponent<MeshRenderer>().enabled = GameManager.Instance.ShowPrefabs;
        GameManager.Instance.EnemyWaves++;

        /*if(enemyWaves == EnemyWavesMax)
        {
            startWave = false;
        }*/

        yield return null;
    }
}
