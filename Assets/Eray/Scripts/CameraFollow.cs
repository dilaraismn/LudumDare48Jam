using UnityEngine;

namespace Eray.Scripts
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform target;

        [SerializeField] private float distance = 10.0f;

        [SerializeField] private float rotationDamping;


        void LateUpdate()
        {
            if (!target)
                return;

            var wantedRotationAngle = target.eulerAngles.y;

            var currentRotationAngle = transform.eulerAngles.y;
            var currentHeight = transform.position.y;
            

            currentRotationAngle =
                Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);

            var currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

            transform.position = target.position;
            transform.position -= currentRotation * Vector3.forward * distance;

            transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);

            transform.LookAt(target);
        }
    }
}