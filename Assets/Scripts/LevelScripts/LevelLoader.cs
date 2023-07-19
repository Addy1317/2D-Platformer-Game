using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Outscal
{
    [RequireComponent(typeof(Button))]
    public class LevelLoader : MonoBehaviour
    {
        [Header("Button")]
        [SerializeField] private string _LevelName;
        private Button _levelButton;

        private void Awake()
        {
            _levelButton = GetComponent<Button>();
            _levelButton.onClick.AddListener(onClick);
        }

        private void onClick()
        {
            SceneManager.LoadScene(_LevelName);

        }
    }
}