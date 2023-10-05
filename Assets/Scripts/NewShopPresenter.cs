using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.Networking;
using System.IO;
using System.Collections;

namespace Toem.ShopSystem
{
    public class NewShopPresenter : MonoBehaviour
    {
        
        public int currentItemIndex;
        public int currentCategoryIndex;

        int maxCategoryCount = 3;
        public int maxShowItemCount;
        public int pageSize;

        [SerializeField] ButtoGoToShop buttoGoToShop;
        [SerializeField] string savePath;
        [SerializeField] string onLineGoogleDive;
        [SerializeField] Pagesize currecntPageSize;
        [SerializeField] UIShop uiShop;
        [SerializeField] UIShop NewuiShop;
        [SerializeField] ShopStore shopstore;
        [SerializeField] PlayerCoin playerCoin;
        [SerializeField] List<CategoryInfo> categoryInfoList = new List<CategoryInfo>();



        void Start()
        {
            LoadItemFromGoogleDive();
        }

        void Update()
        {
            if (pageSize != currecntPageSize.currentpagesize)
            {
                pageSize = currecntPageSize.currentpagesize;
                RefreshUI();
            }
            
            if((buttoGoToShop.oldShop == true) && (buttoGoToShop.newShop == false))
            {
                if(Input.GetKeyDown(KeyCode.A))
                {
                    PrevItem();
                }
                else if(Input.GetKeyDown(KeyCode.D))
                {
                    NextItem();
                }
                else if(Input.GetKeyDown(KeyCode.Q))
                {
                    PrevCategory();
                }
                else if(Input.GetKeyDown(KeyCode.E))
                {
                    NextCategory();
                }
            }

            if((buttoGoToShop.oldShop == false) && (buttoGoToShop.newShop == true))
            {
                if(Input.GetKeyDown(KeyCode.W))
                {
                    PrevItem();
                }
                else if(Input.GetKeyDown(KeyCode.S))
                {
                    NextItem();
                }
                else if (Input.GetKeyDown(KeyCode.E))
                {
                    PrevCategory();
                }
                else if (Input.GetKeyDown(KeyCode.D))
                {
                    NextCategory();
                }
            }
            
            if(Input.GetKeyDown(KeyCode.Space))
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

        [ContextMenu(nameof(SaveScoreData))]
        void SaveScoreData()
        {
            if(string.IsNullOrEmpty(savePath))
            {
                Debug.LogError("No save path");
                return;
            }

            var scoreJson = JsonConvert.SerializeObject(shopstore.itemList, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            }); ;
            var dataPath = Application.dataPath;
            var targetFilePath = Path.Combine(dataPath, savePath);

            var directoryPath = System.IO.Path.GetDirectoryName(targetFilePath);
            if(Directory.Exists(directoryPath) == false)
            {
                Directory.CreateDirectory(directoryPath);
            }
            File.WriteAllText(targetFilePath, scoreJson);
        }
        IEnumerator LoadScoreRourtine(string url)
        {
            var webRequest = UnityWebRequest.Get(url);
            var progress = webRequest.downloadProgress;
            Debug.Log(progress);
            yield return webRequest.SendWebRequest();

            if(webRequest.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError(webRequest.error);
            }
            else
            {
                var downloadedText = webRequest.downloadHandler.text;
                Debug.Log("Data : " + downloadedText);
                shopstore.itemList = JsonConvert.DeserializeObject<List<ItemData>>(downloadedText);
            }
            RefreshUI();
        }

        [ContextMenu(nameof(LoadItemFromGoogleDive))]
        void LoadItemFromGoogleDive()
        {
            StartCoroutine(LoadScoreRourtine(onLineGoogleDive));
        }
        

        public void RefreshUI()
        {
            if (currentCategoryIndex < 0 || currentCategoryIndex >= categoryInfoList.Count)
            {
                return;
            }
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
            NewuiShop.SetCurrentItemInfo(currentItem);

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
