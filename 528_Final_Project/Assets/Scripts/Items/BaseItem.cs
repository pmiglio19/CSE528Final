using System;
using UnityEngine;

namespace Items
{
    public class BaseItem : MonoBehaviour
    {
        public string itemName;
        public int damageMultiplier;
        public string itemType;
        public Sprite sprite;

        //Animations
        protected SpriteRenderer spriteRenderer;
        internal Animator animator;

        //Other components
        public Collider2D collider2d;
        public Rigidbody2D rigidBody;

        public BaseItem(string _itemName, int _damageMultiplier, string _itemType, Sprite _sprite)
        {
            itemName = _itemName;
            damageMultiplier = _damageMultiplier;
            itemType = _itemType;
            sprite = _sprite;
            //sprite = spriteRenderer.sprite;
        }

        private void Awake()
        {
            animator = GetComponent<Animator>();
            spriteRenderer = GetComponent<SpriteRenderer>();

            collider2d = GetComponent<Collider2D>();
            rigidBody = GetComponent<Rigidbody2D>();

            rigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
        }

        public Sprite GetSprite()
        {
            return sprite;
        }
    }
}
