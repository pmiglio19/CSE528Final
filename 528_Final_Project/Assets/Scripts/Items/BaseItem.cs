using System;
using UnityEngine;

namespace Items
{
    public class BaseItem : MonoBehaviour
    {
        private int itemId;
        public string itemName;

        //Animations
        SpriteRenderer spriteRenderer;
        internal Animator animator;

        //Other components
        public Collider2D collider2d;
        public Rigidbody2D rigidBody;

        public BaseItem(string _itemName)
        {
            itemName = _itemName;
        }

        private void Awake()
        {
            animator = GetComponent<Animator>();
            spriteRenderer = GetComponent<SpriteRenderer>();

            collider2d = GetComponent<Collider2D>();
            rigidBody = GetComponent<Rigidbody2D>();

            rigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
        }

        private void Update()
        {

        }

        private void FixedUpdate()
        {

        }
    }
}