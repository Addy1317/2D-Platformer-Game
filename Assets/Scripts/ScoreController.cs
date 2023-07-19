using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Outscal
{
    public class ScoreController : MonoBehaviour
    {
        [Header("Text Attriutes")]
        private TextMeshProUGUI _scoreText;
        private int _score = 0;

        private void Awake()
        {
            _scoreText = GetComponent<TextMeshProUGUI>();
        }
        private void Start()
        {
            RefreshUI();
        }
        public void IncrementScore( int increment)
        {
            _score += increment;
            RefreshUI();
        }

        private void RefreshUI()
        {
            _scoreText.text = "Score:" + _score;
        }

    }
}

