using Assets.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.SceneLoaders
{
    public class InstructionScene : MonoBehaviour
    {
        private void Update()
        {

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
                //UnityEditor.EditorApplication.isPlaying = false;
            }

            if (Input.anyKey)
            {
                //GameObject.FindGameObjectWithTag("Music").GetComponent<MusicClass>().StopMusic();
                SceneManager.LoadScene("OverworldScene");
                Time.timeScale = 1;
            }
        }
    }
}
