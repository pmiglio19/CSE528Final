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
    public class TitleScene : MonoBehaviour
    {
        private void Update()
        {
            if (Input.anyKey)
            {
                //GameObject.FindGameObjectWithTag("Music").GetComponent<MusicClass>().PlayMusic();
                SceneManager.LoadScene("InstructionScene");
                Time.timeScale = 1;
            }
        }
    }
}
