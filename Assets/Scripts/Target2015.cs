using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets
{
    public class Target2015 : MonoBehaviour
    {
        AudioSource audiosource;

        [SerializeField]
        private bool bouge, changeDirection;

        [SerializeField]
        private int directionx, directiony, speed;

        private float delaySound;

        [SerializeField]
        private float delaySoundMax;

        private float startX;

        private float startY;

        private float startZ;

        [SerializeField]
        private float deplacementMax;

        private bool deplacementX;

        private bool deplacementY;

        private bool areaGround = false;
        // Use this for initialization
        void Start()
        {
            audiosource = GetComponent<AudioSource>();

            startX = transform.position.x;

            startY = transform.position.y;

            startZ = transform.position.z;

        }

        // Update is called once per frame
        void Update()
        {
            if (delaySound >= 3f)
            {
                if (!audiosource.isPlaying)
                {
                    if(GameManager.Instance.NameLevel == "LabRoom")
                        audiosource.clip = Resources.Load("Sound/SFX01_Grow") as AudioClip;
                    else if(GameManager.Instance.NameLevel == "Forest")
                        audiosource.clip = Resources.Load("Sound/SFX02_Grow") as AudioClip;
                    else if (GameManager.Instance.NameLevel == "City")
                        audiosource.clip = Resources.Load("Sound/SFX03_Grow") as AudioClip;

                    audiosource.Play();
                }
                delaySound = 0;
            }
            else
            {
                delaySound += Time.deltaTime;
            }

            if (bouge)
            {
                transform.Translate(new Vector3(directionx * speed, 0, directiony * speed) * Time.deltaTime);
                //GetComponent<Rigidbody>().velocity = new Vector3(directionx * speed, 0, directiony * speed) * Time.deltaTime;
                //if (!changeDirection).
                if(deplacementX == true)
                {
                    if (transform.position.x >= startX + deplacementMax || transform.position.x <= startX - deplacementMax)
                    {
                        directionx = -directionx;
                    }
                }


                if (deplacementY == true)
                {
                    if (transform.position.y >= startY + deplacementMax || transform.position.y <= startY - deplacementMax)
                    {
                        directiony = -directiony;
                    }
                }
            }
        }

        void OnCollisionEnter(Collision coll)
        {
            foreach (ContactPoint contact in coll.contacts)
            {
                if(contact.thisCollider.transform.tag == "Ground")
                {
                    areaGround = true;
                    directionx = -directionx;
                    directiony = -directiony;
                }
            }
        }

        void OnCollisionExit(Collision collisionInfo)
        {
            areaGround = false;
        }

        IEnumerator WaitToChangeDirection(float timewait)
        {
            //action
            yield return new WaitForSeconds(timewait);
            //action 2
            directionx = -directionx;
            //directionz = -directionz;
            changeDirection = false;
            Debug.Log(directionx);
        }
    }
}

