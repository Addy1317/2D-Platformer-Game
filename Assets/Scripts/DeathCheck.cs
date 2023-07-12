using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Outscal
{
    public class DeathCheck : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.GetComponent<PlayerController>() != null) ;
            {
               
                Debug.Log("Player is Dead");
                SceneManager.LoadScene(1);
            }
        }
    }
}

