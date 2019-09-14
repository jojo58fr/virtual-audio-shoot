using System.Collections;
using UnityEngine;
using Target;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace VRTK.Example
{
    /// <summary>
    /// gestion de l'arme
    /// </summary>
    public class Gun : VRTK_InteractableObject
    {
        #region Gestion de la balle
        [SerializeField]
        private GameObject bullet;
        private float bulletSpeed = 1000f;//vitesse de la balle
        private float bulletLife = 1.5f;//temps de vie de la balle
        #endregion
        [SerializeField]
        private GameObject manette;

        [SerializeField]
        private GameObject casque;

        private GameObject cible;

        private bool resetBullet;//autorise ou non le joueur a tirer

        private Quaternion rotationBalle;//direction du tir

        private int NbTir = 0;
        private int NbTirMax = 5;
        

        public int getNbTir()
        {
            return NbTir;
        }
        public void setNbTir(int nb)
        {
            NbTir = nb;
        }

        public override void StartUsing(VRTK_InteractUse usingObject)
        {
            base.StartUsing(usingObject);
            manette = GameObject.Find("Sphere");
            casque = GameObject.Find("Camera (eye)");
            AppelTir();

        }

        protected void Start()
        {
        }
        /// <summary>
        /// gestion des tirs est de l'affichage des essais restant
        /// </summary>
        new void Update()
        {
            base.Update();

            if(FindObjectOfType<Bullet>() == null)
            {
                resetBullet = true;
            }
            else
            {
                resetBullet = false;
            }

            if(NbTir >= NbTirMax)
            {
                NbTir = 0;
                cible.GetComponent<ValueColliderTarget>().ResetSpawn();
            }

            GameObject.Find("NumberBullet").GetComponent<Text>().text = (NbTirMax - NbTir) + "/" + NbTirMax;


            if (GameObject.Find("Cube") != null)
            {

                GameObject instance = GameObject.Find("Cube");

                if (instance.transform.position.y <  0)
                {
                    Destroy(instance);
                }
                
               
            }

        }
        /// <summary>
        /// gestion du tir
        /// </summary>
        private void AppelTir()
        {

            if (!GameManager.Instance.StartWave)//si le test n'est pas lancé on le lance
            {
                GameManager.Instance.StartWave = true;
                gameObject.GetComponent<BoxCollider>().isTrigger = true;

                GameObject.Find("Cube").GetComponent<BoxCollider>().isTrigger = true;
            }
            else if (GameManager.Instance.StartWave && resetBullet && NbTir != NbTirMax + 1)
            {
                #region tir
                NbTir += 1;
                cible = GameObject.FindWithTag("Cible");
                Vector3 result = manette.transform.position - casque.transform.position;
                rotationBalle = Quaternion.FromToRotation(casque.transform.position, manette.transform.position);

                GameObject bulletClone = Instantiate(bullet, manette.transform.position, Quaternion.identity) as GameObject;

                bulletClone.SetActive(true);
                Rigidbody rb = bulletClone.GetComponent<Rigidbody>();
                rb.AddForce(result * bulletSpeed);
                
                bulletClone.GetComponent<Bullet>().StartCoroutine(DestroyBulletTime(bulletClone, bulletLife));
                #endregion
            }


        }
        /// <summary>
        /// destruction de la balle avec un delai
        /// </summary>
        /// <param name="bullet"></param>
        /// <param name="time">temps d'attente avbant de détruire la balle</param>
        /// <returns></returns>
        IEnumerator DestroyBulletTime(GameObject bullet, float time)
        {
            yield return new WaitForSeconds(time);
           
            DestroyBullet(false);
        }
        /// <summary>
        /// destruction de la balle
        /// </summary>
        /// <param name="reset"></param>
        public void DestroyBullet(bool reset)
        {
   
            cible = GameObject.FindWithTag("Cible");
            casque = GameObject.Find("Camera (eye)");

            //Gestion des coordonnées casque, cible
            PolarScript polarscript = new PolarScript(casque, cible);
            //Gestion des coordonnées casque balle
            PolarScript polarscript2 = new PolarScript(casque, FindObjectOfType<Bullet>().gameObject);

            //Sauvegarde
            if (NbTir != 0)
            {
                Save.Sauvegarde(NbTir, polarscript.CordPolCible, polarscript2.CordPolCible);
            }
            //reset du compteur
            if ( NbTir == NbTirMax)
            {
                cible.GetComponent<ValueColliderTarget>().ResetSpawn();
                NbTir = 0;

            }
            if (reset)
            {
                cible.GetComponent<ValueColliderTarget>().ResetSpawn();
                NbTir = 0;


                if(GameManager.Instance.EnemyWaves == GameManager.Instance.EnemyWavesMax)
                {

                    GameObject instance = FindObjectOfType<VRTK.Example.Gun>().gameObject;
                    instance.SetActive(false);
                    Destroy(instance);
                    SceneManager.LoadScene("Menu");
                }

            }
            Destroy(FindObjectOfType<Bullet>().gameObject);

        }

    }
}