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
            LevelStatus levelStatus = LevelManager.Instance.GetLevelStatus(_LevelName);
            switch (levelStatus)
            {
                case LevelStatus.Locked:
                    Debug.Log("Can't play yet");
                    break;
                case LevelStatus.Unlocked:
                    SceneManager.LoadScene(_LevelName);
                    break;
                case LevelStatus.Completed:
                    SceneManager.LoadScene(_LevelName);
                    break;
                default:
                    break;
            }
          
           // SceneManager.LoadScene(_LevelName);

        }
    }
}