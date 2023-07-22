using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Outscal
{    
    public class SoundManager : MonoBehaviour
    {
        [Header("Singleton")]
        private static SoundManager instance;
        public static SoundManager Instance { get { return instance; } }

        [Header("Audio Reference")]
        public AudioSource soundEffect;
        public AudioSource soundMusic;
        public SoundType[] Sounds;

        public bool IsMute = false;
        public float Volume = 1f;

        private void Awake()
        {
            if (instance == null)
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
            SetVolume(0.5f);
            PlayMusic(GameSounds.Music);
        }

        public void Mute(bool status)
        {
            IsMute = status;
        }

        public void SetVolume(float volume)
        {
            Volume = volume;
            soundEffect.volume = volume;
            soundMusic.volume = volume;
        }
        public void PlayMusic(GameSounds sound)
        {
            if (IsMute)
                return;

            AudioClip clip = getSoundClip(sound);
            if(clip != null)
            {
                soundMusic.clip = clip;
                soundMusic.Play();
            }
            else
            {
                Debug.LogError("Clip not found : " + sound);
            }
        }

        public void Play(GameSounds sound)
        {
            if (IsMute)
                return;
            
            AudioClip clip = getSoundClip(sound);
            if(clip != null)
            {
                soundEffect.PlayOneShot(clip);
            }
            else
            {
                Debug.LogError("clip not found : " + sound);
            }
        }

        private AudioClip getSoundClip(GameSounds sound)
        {
           SoundType item =  Array.Find(Sounds, i => i.soundType == sound);
            if(item != null)
            {
                return item.soundClip;
            }
            return null;
        }
    }

    [Serializable]
    public class SoundType
    {
        public GameSounds soundType;
        public AudioClip soundClip;
    }

    public enum GameSounds
    {
        Music,
        ButtonClick,
        PlayerMove,
        PlayerDeath,
        EnemyDeath,
        BombBlast
    }
}