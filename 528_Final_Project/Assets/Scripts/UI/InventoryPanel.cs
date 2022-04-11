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

        public InventoryPanel()
        {
            buttons = new List<Button>();
        }

        private void Start()
        {
            buttons = GetComponent<GridLayoutGroup>().GetComponentsInChildren<Button>().ToList();

            Debug.Log("Name: " + name);

            for (int i = 0; i < buttons.Count; i++)
            {
                Debug.Log("Sprite Names: " + buttons[i].GetComponent<Image>().sprite.name);
            }

            Debug.Log("buttons.Count in print: " + buttons.Count);
        }

        public void AddToInventoryPanel(Sprite newSprite)
        {
            Debug.Log("newSprite name: "+newSprite.name);
            try
            {
                int slotsTaken = 0;

                Debug.Log("This is slots taken: " + slotsTaken.ToString());
                Debug.Log("buttons.Count in add: " + buttons.Count);
                //Check if slots are full already
                for (int i = 0; i < buttons.Count; i++)
                {
                    Debug.Log("In for loop: "+ buttons[i].GetComponent<Image>().sprite.name);
                    if (buttons[i].GetComponent<Image>().sprite.name != "UISprite")
                    {
                        Debug.Log("In if statement");
                        slotsTaken++;
                    }
                }

                Debug.Log("This is slots taken: " + slotsTaken.ToString());

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
                        Debug.Log("Iteration: " + i.ToString());
                        Debug.Log("NEW SPRITE IMAGE AT: "+buttons[i].GetComponent<Image>().sprite.name);

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
    }
}
