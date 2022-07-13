using System;
using UnityEngine;

namespace MonoBe
{
    public class DestroyEffect: MonoBehaviour
    {
        public float time = 1f;
        private void Start()
        {
            Destroy(gameObject,time);
        }
    }
}