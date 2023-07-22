using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Outscal
{
    public class ParticleController : MonoBehaviour
    {
        public ParticleSystem particleSystem;

        public void PlayEffect()
        {
            gameObject.SetActive(true);
        }
    }
}