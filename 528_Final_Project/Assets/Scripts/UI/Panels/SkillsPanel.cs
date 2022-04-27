using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class SkillsPanel : MonoBehaviour
    {
        static List<Button> buttons;
        public Sprite uiSprite;

        public SkillsPanel()
        {
            buttons = new List<Button>();
        }

        private void Start()
        {
            buttons = GetComponent<GridLayoutGroup>().GetComponentsInChildren<Button>().ToList();
        }
    }
}
