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
        [SerializeField] private Button ButtonRestart;
        [SerializeField] private Button ButtonQuit;
        private void Awake()
        {
            ButtonRestart.onClick.AddListener(ReLoadLevel);
            ButtonQuit.onClick.AddListener(QuitGame);
        }
        public void PlayerDied()
        {
            gameObject.SetActive(true);
        }

        private void ReLoadLevel()
        {
            SceneManager.LoadScene(1);
        }

        private void QuitGame()
        {
            Application.Quit();
            Debug.Log("Quitting Application");
        }

    }
}