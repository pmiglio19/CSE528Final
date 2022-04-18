using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class InventoryPanel : MonoBehaviour
    {
        static List<Button> buttons;
        public Sprite uiSprite;

        public InventoryPanel()
        {
            buttons = new List<Button>();
        }

        private void Start()
        {
            buttons = GetComponent<GridLayoutGroup>().GetComponentsInChildren<Button>().ToList();
        }

        public void AddToInventoryPanel(Sprite newSprite)
        {
            try
            {
                int slotsTaken = 0;

                //Check if slots are full already
                for (int i = 0; i < buttons.Count; i++)
                {
                    if (buttons[i].GetComponent<Image>().sprite.name != "UISprite")
                    {
                        slotsTaken++;
                    }
                }

                if (slotsTaken == 3)
                {
                    return;
                }

                if (slotsTaken > 3)
                {
                    throw new Exception();
                }

                //Change button sprite to new thing
                for (int i = 0; i < buttons.Count; i++)
                {
                    if(buttons[i].GetComponent<Image>().sprite.name == "UISprite")
                    {
                        buttons[i].GetComponent<Image>().sprite = newSprite;
                        return;
                    }
                }

                return;
            }

            catch (Exception ex)
            {
                Debug.Log(ex.Message);
            }
        }

        public void RemoveFromInventoryPanel(string itemName)
        {
            for (int i = 0; i < buttons.Count; i++)
            {
                if (buttons[i].GetComponent<Image>().sprite.name == itemName)
                {
                    buttons[i].GetComponent<Image>().sprite = uiSprite;
                    return;
                }
            }
        }
    }
}
