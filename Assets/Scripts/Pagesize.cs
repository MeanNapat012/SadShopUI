using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toem.ShopSystem
{
    public class Pagesize : MonoBehaviour
    {
        [SerializeField] ShopPresenter shopPresenter;

        public int currentpagesize = 6;

        public void buttonPagesize2()
        {
            currentpagesize = 2;
            shopPresenter.RefreshUI();
        }

        public void buttonPagesize4()
        {
            currentpagesize = 4;
            shopPresenter.RefreshUI();
        }

        public void buttonPagesize6()
        {
            currentpagesize = 6;
            shopPresenter.RefreshUI();
        }
    }
}
