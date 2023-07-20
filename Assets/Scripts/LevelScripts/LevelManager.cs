using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Outscal
{
    public class LevelManager : MonoBehaviour
    {
        private static LevelManager instance;
        public static LevelManager Instance { get { return instance; } }

       // public string Level1;

        public string[] Levels;
        private void Awake()
        {
            if(instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            if(GetLevelStatus(Levels[0]) == LevelStatus.Locked)
            {
                SetLevelStatus(Levels[0], LevelStatus.Unlocked);
            }
        }

        public void MarkCurrentLevelCompleted()
        {
            Scene currentScene = SceneManager.GetActiveScene();

            Instance.SetLevelStatus(currentScene.name, LevelStatus.Completed);
            /*
            int nextsceneIndex = currentScene.buildIndex + 1;
            Scene nextScene = SceneManager.GetSceneByBuildIndex(nextsceneIndex);
            Debug.Log("Next Scene is Valid : " + nextScene.IsValid());
            Instance.SetLevelStatus(nextScene.name, LevelStatus.Unlocked);
            */

           int currentSceneIndex = Array.FindIndex(Levels, Levels => Levels == currentScene.name);
            int nextSceneIndex = currentSceneIndex + 1;
            if(nextSceneIndex < Levels.Length)
            {
                SetLevelStatus(Levels[nextSceneIndex], LevelStatus.Unlocked);
            }
        }

        public LevelStatus GetLevelStatus(string level)
        {
           LevelStatus levelStatus = (LevelStatus) PlayerPrefs.GetInt(level, 0);
            return levelStatus;
        }

        public void SetLevelStatus(string level, LevelStatus levelStatus)
        {
            PlayerPrefs.SetInt(level, (int)levelStatus);
            Debug.Log("Setting Level : " + level + "| Status : " + levelStatus);                
        }
    }
}