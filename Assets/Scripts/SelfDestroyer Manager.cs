using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AJM
{
    public class SelfDestroyerManager : MonoBehaviour
    {
        public float destructionTime;

        void Start()
        {
            Destroy(this.gameObject, destructionTime);
        }
    }
}