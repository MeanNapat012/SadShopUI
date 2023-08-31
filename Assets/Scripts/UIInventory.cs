using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Toem.InventorySystem
{
    public class UIInventory : MonoBehaviour
    {
        [Header("Category")]
        [SerializeField] Image categoryIconIamge;
        [SerializeField] Text categoryText;

        void Start()
        {
        
        }

        public void SetCategory(CategoryInfo info)
        {
            categoryIconIamge.sprite = info.icon;
            categoryText.text = info.name;
        }
    }

    [Serializable]
    public class CategoryInfo
    {
        public string name;
        public Sprite icon;
    }
}
