using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtoGoToShop : MonoBehaviour
{
    [SerializeField] GameObject SadShopUI1;
    [SerializeField] GameObject SadShopUI2;

    void Start()
    {
        SadShopUI1.SetActive(true);
        SadShopUI2.SetActive(false);
    }

    public void GotoShop1()
    {
        SadShopUI1.SetActive(true);
        SadShopUI2.SetActive(false);
    }

    public void GotoShop2()
    {
        SadShopUI1.SetActive(false);
        SadShopUI2.SetActive(true);
    }
}
