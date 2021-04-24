using UnityEngine;

namespace Mehmethan.Scripts
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float speed = 1f;

        void Update()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            
            transform.Translate(horizontal * speed *Time.deltaTime, 0f,vertical * speed * Time.deltaTime);
        
        }
    }
}
