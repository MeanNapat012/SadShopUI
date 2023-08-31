using System.Collections;
using System.Collections.Generic;
using UnityEditor.Profiling;
using UnityEngine;

namespace Toem.ShopSystem
{
    public class InventoryPresenter : MonoBehaviour
    {
        int currentCategoryIndex;

        int maxCategoryCount = 3;

        [SerializeField] List<CategoryInfo> categoryInfoList = new List<CategoryInfo>();
        void Start()
        {
        
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                PrevCategory();
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                NextCategory();
            }
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

        [ContextMenu(nameof(RefreshUI))]
        void RefreshUI()
        {

        }
    }
}
