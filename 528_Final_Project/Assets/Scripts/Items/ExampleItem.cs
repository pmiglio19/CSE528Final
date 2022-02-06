using System;

namespace Items
{
    public class ExampleItem : IItem
    {
        public string itemInfo { get; set; }

        public ExampleItem()
        {
            itemInfo = "This is information that explains what this example item does.";
        }

        //Add private methods in this class to help the itemEffect method do its thing
        public void ItemEffect()
        {
            //For example: take current PlayerController's health and add 10 or something
        }
    }
}
