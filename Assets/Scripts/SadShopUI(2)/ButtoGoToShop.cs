using System.Collections;
using System.Collections.Generic;
using Toem.ShopSystem;
using UnityEngine;

public class ButtoGoToShop : MonoBehaviour
{
    public bool oldShop = true;
    public bool newShop = false;

    public UIShop uiShop;
    [SerializeField] GameObject loadingScene;
    [SerializeField] GameObject SadShopUI1;
    [SerializeField] GameObject SadShopUI2;
    [SerializeField] NewShopPresenter newshopPresenter;

    void Start()
    {
        loadingScene.SetActive(true);
        SadShopUI1.SetActive(false);
        SadShopUI2.SetActive(false);
    }

    public void GotoShop1()
    {
        SadShopUI2.SetActive(false);
        SadShopUI1.SetActive(true);
        oldShop = true;
        newShop = false;
        ResetPage();
        StartCoroutine(uiShop.ItemsAnimation());
    }

    public void GotoShop2()
    {
        SadShopUI1.SetActive(false);
        SadShopUI2.SetActive(true);
        oldShop = false;
        newShop = true;
        ResetPage();
        StartCoroutine(uiShop.ItemsAnimation());
    }

    public void ResetPage()
    {
        newshopPresenter.currentCategoryIndex = 0;
        newshopPresenter.currentItemIndex = 0;
        newshopPresenter.RefreshUI();
    }

    public void CloseAll()
    {
        SadShopUI1.SetActive(false);
        SadShopUI2.SetActive(false);
    }
}
