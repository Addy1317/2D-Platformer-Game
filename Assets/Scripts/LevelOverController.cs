using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Outscal
{
    public class LevelOverController : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.GetComponent<PlayerController>() != null)
            {
                Debug.Log("Level Completed");
            }
        }
    }
}