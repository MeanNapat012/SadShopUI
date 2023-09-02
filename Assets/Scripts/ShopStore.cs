using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

namespace Toem.ShopSystem
{
    public class ShopStore : MonoBehaviour
    {
        public ItemData[] ItemArray => itemList.ToArray();
        [SerializeField] List<ItemData> itemList = new List<ItemData>();

        public ItemData[] GetItemsByType(ItemType targetType)
        {
            var resultList = new List<ItemData>();
            foreach(var itemData in itemList)
            {
                if(itemData.Type == targetType) resultList.Add(itemData);
            }
            return resultList.ToArray();
        }
        
    }

    [Serializable]
    public class ItemData
    {
        public string itemName;
        public string description;
        public Sprite itemShop;
        public ItemType Type;
        public int purchase;
    }

    public enum ItemType
    {
        one,
        two,
        three
    }
}