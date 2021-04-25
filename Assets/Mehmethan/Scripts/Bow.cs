using UnityEngine;

namespace Mehmethan.Scripts
{
    public class Bow : MonoBehaviour
    {
  

        [SerializeField] private float bowSpeed;
    
        void Update()
        {
            transform.Translate(Vector3.forward * bowSpeed * Time.deltaTime);
        }
    
    
    }
}
