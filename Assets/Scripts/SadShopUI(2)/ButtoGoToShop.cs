using System.Collections;
using System.Collections.Generic;
using Toem.ShopSystem;
using UnityEngine;

public class ButtoGoToShop : MonoBehaviour
{
    public bool oldShop = true;
    public bool newShop = false;

    [SerializeField] GameObject SadShopUI1;
    [SerializeField] GameObject SadShopUI2;
    [SerializeField] ShopPresenter shopPresenter;

    void Start()
    {
        SadShopUI1.SetActive(true);
        SadShopUI2.SetActive(false);
    }

    public void GotoShop1()
    {
        SadShopUI2.SetActive(false);
        SadShopUI1.SetActive(true);
        oldShop = true;
        newShop = false;
        ResetPage();
    }

    public void GotoShop2()
    {
        SadShopUI1.SetActive(false);
        SadShopUI2.SetActive(true);
        oldShop = false;
        newShop = true;
        ResetPage();
    }

    public void ResetPage()
    {
        shopPresenter.currentCategoryIndex = 0;
        shopPresenter.currentItemIndex = 0;
        shopPresenter.RefreshUI();
    }

    public void CloseAll()
    {
        SadShopUI1.SetActive(false);
        SadShopUI2.SetActive(false);
    }
}
