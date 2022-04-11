using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class InventoryButton : MonoBehaviour
    {
        Image spriteImage;

        private void Awake()
        {
            spriteImage = GetComponent<Image>();
            //Debug.Log("Image name: "+ spriteImage.sprite.name);
        }

        public void ChangeSprite(Sprite newSprite)
        {
            spriteImage.sprite = newSprite;
        }
    }
}
