using UnityEngine;
using System.Collections;

namespace CompleteProject
{
    public class SeguimientoCamara : MonoBehaviour
    {
        public Transform objetivo;            // The position that that camera will be following.
        public float suavizado = 5f;        // The speed with which the camera will be following.


        Vector3 offset;                     // The initial offset from the target.


        void Start ()
        {
            // Calculate the initial offset.
			offset = transform.position - objetivo.position;
        }


        void FixedUpdate ()
        {
            // Create a postion the camera is aiming for based on the offset from the target.
			Vector3 targetCamPos = objetivo.position + offset;

            // Smoothly interpolate between the camera's current position and it's target position.
			transform.position = Vector3.Lerp (transform.position, targetCamPos, suavizado * Time.deltaTime);
        }
    }
}