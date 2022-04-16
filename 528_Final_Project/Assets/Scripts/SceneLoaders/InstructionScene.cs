﻿using System;
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
            if (Input.anyKey)
            {
                SceneManager.LoadScene("OverworldScene");
            }
        }
    }
}