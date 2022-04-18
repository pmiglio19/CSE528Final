using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class QuitButton : MonoBehaviour
    {
        private Button button;
        public InventoryPanel inventoryPanel;

        private void Start()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(TaskOnClick);
        }

        private void TaskOnClick()
        {
            SceneManager.LoadScene("TitleScene");
        }
    }
}
