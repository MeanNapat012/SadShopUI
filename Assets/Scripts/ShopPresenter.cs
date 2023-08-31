using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toem.ShopSystem
{
    public class ShopPresenter : MonoBehaviour
    {
        int currentItemIndex;
        int currentCategoryIndex;

        int maxCategoryCount = 3;
        int maxShowItemCount;
        int pageSize = 6;

        [SerializeField] UIShop uiShop;
        [SerializeField] ShopStore shopstore;
        [SerializeField] List<CategoryInfo> categoryInfoList = new List<CategoryInfo>();

        void Start()
        {
            RefreshUI();
        }

        void Update()
        {
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
        }

        void PrevItem()
        {
            if(currentItemIndex <= 0) return;
            currentItemIndex--;
            RefreshUI();
        }

        void NextItem()
        {
            if(currentItemIndex >= maxShowItemCount - 1) return;
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
            RefreshUI();
        }

        void NextCategory()
        {
            if (currentCategoryIndex >= maxCategoryCount - 1)
            {
                return;
            }
            currentCategoryIndex++;
            RefreshUI();
        }

        void RefreshUI()
        {
            
        }
    }
}
