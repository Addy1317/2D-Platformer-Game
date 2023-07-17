using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Outscal
{
    public class GameOverController : MonoBehaviour
    {
        [Header("Restart Button")]
        public Button ButtonRestart;

        private void Awake()
        {
            ButtonRestart.onClick.AddListener(ReLoadLevel);
        }
        public void PlayerDied()
        {
            gameObject.SetActive(true);
        }

        private void ReLoadLevel()
        {
            SceneManager.LoadScene(1);
        }


    }
}