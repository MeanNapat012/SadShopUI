using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toem.ShopSystem
{
    public class Pagesize : MonoBehaviour
    {
        [SerializeField] ShopPresenter shopPresenter;

        public int currentpagesize = 6;

        public void buttonPagesize6()
        {
            currentpagesize = 6;
            //shopPresenter.RefreshUI();
        }

        public void buttonPagesize10()
        {
            currentpagesize = 10;
            //shopPresenter.RefreshUI();
        }

        public void buttonPagesize15()
        {
            currentpagesize = 15;
            //shopPresenter.RefreshUI();
        }
    }
}
