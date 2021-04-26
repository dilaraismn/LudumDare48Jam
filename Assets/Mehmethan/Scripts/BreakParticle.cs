using UnityEngine;

namespace Mehmethan.Scripts
{
    public class BreakParticle : MonoBehaviour
    {
        [SerializeField] private GameObject breakParticle;
        [SerializeField] private bool destroyBreak;
        
        public void OnDeath()
        {
            if (!destroyBreak)
            {
                Instantiate(breakParticle, transform.position,Quaternion.identity); 
            }
            else if (destroyBreak)
            {
                Instantiate(breakParticle, transform.position,Quaternion.identity); 
                //Destroy(gameObject,3f);
            }
        }
    }
}
