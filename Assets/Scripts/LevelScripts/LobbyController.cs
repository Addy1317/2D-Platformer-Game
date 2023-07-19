using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Outscal
{

    public class LobbyController : MonoBehaviour
    {
        [Header("Buttons")]
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _quitButton;

        [Header("Level Selection Popup")]
        [SerializeField] private GameObject _levelSelection;
        private void Awake()
        {
            _playButton.onClick.AddListener(PlayGame);
            _quitButton.onClick.AddListener(QuitGame);
        }

        private void PlayGame()
        {
            //SceneManager.LoadScene(1);
            _levelSelection.SetActive(true);
        }

        private void QuitGame()
        {
            Application.Quit();
            Debug.Log("Application Closed");
        }
    }
}