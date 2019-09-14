using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets
{
    public class Target : MonoBehaviour
    {
        AudioSource audiosource;
        private bool bouge,changeDirection;
        [SerializeField]
        private int directionx, directionz, speed;
        private float delaySound;
        [SerializeField]
        private float delaySoundMax;
	    // Use this for initialization
	    void Start ()
        {
            audiosource = GetComponent<AudioSource>();

            if (Random.Range(0, 100) > 50)
            {
                bouge = true;

                if (Random.Range(0, 100) > 50)
                {
                    directionx = 1;
                    Debug.Log(directionx);
                }
                else
                {
                    directionz = 1;
                }

            }

	    }

        // Update is called once per frame
        void Update()
        {
            if(delaySound >= 3f)
            {
                if (!audiosource.isPlaying)
                {
                    audiosource.clip = Resources.Load("Sound/SFX01_Grow") as AudioClip;
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
                transform.Translate(new Vector3(directionx * speed, 0, directionz * speed) * Time.deltaTime);
                if (!changeDirection)
                {
                    StartCoroutine(WaitToChangeDirection(3f));
                    changeDirection = true;
                }
            }
	    }

        IEnumerator WaitToChangeDirection(float timewait)
        {
            //action
            yield return new WaitForSeconds(timewait);
            //action 2
            directionx = -directionx;
            directionz = -directionz;
            changeDirection = false;
        }
    }
}