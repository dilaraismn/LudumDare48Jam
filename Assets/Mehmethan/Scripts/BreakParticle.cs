using UnityEngine;

namespace Mehmethan.Scripts
{
    public class BreakParticle : MonoBehaviour
    {
        [SerializeField] private GameObject breakParticle;
        [SerializeField] private bool destroyBreak;
        
        void Update()
        {   
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!destroyBreak)
                {
                    Instantiate(breakParticle, transform); 
                }
                else if (destroyBreak)
                {
                    Instantiate(breakParticle, transform); 
                    Destroy(gameObject,3f);
                }
            } 
        }
    }
}
