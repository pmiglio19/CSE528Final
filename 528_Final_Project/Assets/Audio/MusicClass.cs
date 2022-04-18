using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Audio
{
    public class MusicClass : MonoBehaviour
    {
        private AudioSource _audioSource;
        private void Awake()
        {
            DontDestroyOnLoad(transform.gameObject);
            _audioSource = GetComponent<AudioSource>();
        }

        public void PlayMusic()
        {
            if (_audioSource.isPlaying) return;
            _audioSource.Play();
        }

        public void StopMusic()
        {
            _audioSource.Stop();
        }
    }
}
