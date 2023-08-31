using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Toem.ShopSystem
{
    public class UIShop : MonoBehaviour
    {
        [Header("Item List")]
        [SerializeField] UIItemShop itemPrefeb;
        [SerializeField] List<UIItemShop> itemUIList = new List<UIItemShop>();

        [Header("Category")]
        [SerializeField] Image categoryIconIamge;
        [SerializeField] Text categoryText;

        void Start()
        {
            itemPrefeb.gameObject.SetActive(false);
        }

        public void SetItemList(UIItemData[] uIItemDatas)
        {
            ClearAllItemUI();
            foreach(var uIItem_Data in uIItemDatas)
            {
                var newItemUI = Instantiate(itemPrefeb, itemPrefeb.transform.parent, false);
                newItemUI.gameObject.SetActive(true);
                itemUIList.Add(newItemUI);
                newItemUI.SetData(uIItem_Data);
            }
        }

        public void SetCategory(CategoryInfo info)
        {
            categoryIconIamge.sprite = info.icon;
            categoryText.text = info.name;
        }

        public void ClearAllItemUI()
        {
            foreach(UIItemShop uIItemShop in itemUIList) Destroy(uIItemShop.gameObject);
            itemUIList.Clear();
        }

    }

    [Serializable]
    public class CategoryInfo
    {
        public string name;
        public Sprite icon;
    }
}
