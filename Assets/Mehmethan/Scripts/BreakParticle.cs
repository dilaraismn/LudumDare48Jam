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
                Instantiate(breakParticle, transform); 
            }
            else if (destroyBreak)
            {
                Instantiate(breakParticle, transform); 
                //Destroy(gameObject,3f);
            }
        }
    }
}
