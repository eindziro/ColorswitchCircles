using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Rotator : MonoBehaviour
    {
        public float speed = 100f;
        private void Update()
        {
            transform.Rotate(0f,0f,speed * Time.deltaTime);
        }
    }
}