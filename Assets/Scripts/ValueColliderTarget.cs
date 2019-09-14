using UnityEngine;
using VRTK.Example;

namespace Target
{
    public class ValueColliderTarget : MonoBehaviour
    {
       
        private Save savePoint;

        private bool saved;

        void Start()
        {
            saved = false;
        }

        public void ResetSpawn()
        {
            GameManager.Instance.Spawned = false;
            Destroy(this.gameObject);
            saved = false;
        }

        void OnTriggerExit(Collider collision)
        {
       

            if (collision.gameObject.tag == "Bullet" && !saved)
            {
                if(FindObjectOfType<Gun>() != null)
                    FindObjectOfType<Gun>().DestroyBullet(true);
                saved = true;
                Debug.Log("Saved");
            }

        }



    }
}
