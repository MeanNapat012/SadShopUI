using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPresenter : MonoBehaviour
{
    int currentItemIndex;
    
    int maxShowItemCount;
    int pageSize = 6;

    [SerializeField] UIShop uiShop;
    [SerializeField] ShopStore shopstore;
    
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

    void RefreshUI()
    {
        
    }
}
