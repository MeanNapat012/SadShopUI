using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class UIItemShop : MonoBehaviour
{
    [SerializeField] Image itemImage;
    [SerializeField] Image pointerImage;

    public void SetData(UIItemData data)
    {
        itemImage.sprite = data.itemData.itemShop;
        pointerImage.gameObject.SetActive(data.isSelected);
    }

    
}

public class UIItemData
{
    public ItemData itemData;
    public bool isSelected;

    public UIItemData(ItemData itemData, bool isSelected)
    {
        this.itemData = itemData;
        this.isSelected = isSelected;
    }
}
