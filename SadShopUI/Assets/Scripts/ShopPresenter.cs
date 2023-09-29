using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Toem.ShopSystem
{
    public class ShopPresenter : MonoBehaviour
    {
        int currentItemIndex;
        int currentCategoryIndex;

        int maxCategoryCount = 3;
        int maxShowItemCount;
        public int pageSize;

        [SerializeField] Pagesize currecntPageSize;
        [SerializeField] UIShop uiShop;
        [SerializeField] UIShop NewuiShop;
        [SerializeField] ShopStore shopstore;
        [SerializeField] PlayerCoin playerCoin;
        [SerializeField] List<CategoryInfo> categoryInfoList = new List<CategoryInfo>();

        void Start()
        {
            RefreshUI();
        }

        void Update()
        {
            if (pageSize != currecntPageSize.currentpagesize)
            {
                pageSize = currecntPageSize.currentpagesize;
                RefreshUI();
            }
            
            if(Input.GetKeyDown(KeyCode.A))
            {
                PrevItem();
            }
            else if(Input.GetKeyDown(KeyCode.D))
            {
                NextItem();
            }
            else if (Input.GetKeyDown(KeyCode.Q))
            {
                PrevCategory();
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                NextCategory();
            }
            else if(Input.GetKeyDown(KeyCode.Space))
            {
                Purchase();
            }
        }

        void PrevItem()
        {
            if(currentItemIndex <= 0)
            {
                return;
            }
            currentItemIndex--;
            RefreshUI();
        }

        void NextItem()
        {
            if(currentItemIndex >= maxShowItemCount - 1)
            {
                return;
            }
            currentItemIndex++;
            RefreshUI();
        }

        void PrevCategory()
        {
            if (currentCategoryIndex <= 0)
            {
                return;
            } 
            currentCategoryIndex--;
            currentItemIndex = 0;
            RefreshUI();
        }

        void NextCategory()
        {
            if (currentCategoryIndex >= maxCategoryCount - 1)
            {
                return;
            }
            currentCategoryIndex++;
            currentItemIndex = 0;
            RefreshUI();
        }

        void Purchase()
        {
            
        }

        

        public void RefreshUI()
        {
            var currentCategoryInfo = categoryInfoList[currentCategoryIndex];
            uiShop.SetCategory(currentCategoryInfo);
            NewuiShop.SetCategory(currentCategoryInfo);

            var currentCategory = (ItemType)currentCategoryIndex;
            var itemsToDisplay = shopstore.GetItemsByType(currentCategory);
            maxShowItemCount = itemsToDisplay.Length;

            if(maxShowItemCount <= 0){
                uiShop.ClearAllItemUI();
                NewuiShop.ClearAllItemUI();
                return;
            }
            var currentItem = itemsToDisplay[currentItemIndex];
            uiShop.SetCurrentItemInfo(currentItem);
            NewuiShop.SetCategory(currentCategoryInfo);

            var uiDataList = new List<UIItemData>();
            var currentPageIndex = currentItemIndex/pageSize;
            var startIdexToDisplay = currentPageIndex * pageSize;
            var endIndexToDisplay = startIdexToDisplay+pageSize;

            var i =0;
            foreach(var item in itemsToDisplay){
                if(i >= startIdexToDisplay && i < endIndexToDisplay){
                    uiDataList.Add(new UIItemData(item, currentItem == item));
                }
                i++;
            }
            uiShop.SetItemList(uiDataList.ToArray());
            NewuiShop.SetItemList(uiDataList.ToArray());
        }
    }
}
