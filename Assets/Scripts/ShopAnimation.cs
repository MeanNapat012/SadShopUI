using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Toem.ShopSystem;

public class ShopAnimation : MonoBehaviour
{
   public float fadeTime = 1f;
   public CanvasGroup canvasGroup;
   public CanvasGroup canvasGroup2;
   public RectTransform rectTransform;
   public RectTransform rectTransform2;
   public List<GameObject> items = new List<GameObject>();

   public void PanelfadeIn(){
    canvasGroup.alpha = 0f;
    rectTransform.transform.localPosition = new Vector3(0f, -1000f, 0f);
    rectTransform.DOAnchorPos(new Vector2(0f, 0f), fadeTime, false).SetEase(Ease.InOutQuint);
    rectTransform2.DOAnchorPos(new Vector2(0f, 0f), fadeTime, false).SetEase(Ease.InOutQuint);
    canvasGroup.DOFade(1, fadeTime);
    canvasGroup2.DOFade(1, fadeTime);
    StartCoroutine("ItemsAnimation");
   }
   public void Panelfadeout(){
    canvasGroup.alpha = 0f;
    rectTransform.transform.localPosition = new Vector3(0f, 0f, 0f);
    rectTransform.DOAnchorPos(new Vector2(0f, -1000f), fadeTime, false).SetEase(Ease.InOutQuint);
    rectTransform2.DOAnchorPos(new Vector2(0f, -1000f), fadeTime, false).SetEase(Ease.InOutQuint);
    canvasGroup.DOFade(1, fadeTime);
    canvasGroup2.DOFade(1, fadeTime);
   }

   public IEnumerator ItemsAnimation()
   {
      foreach (var item in items)
      {
         item.transform.localScale = Vector3.zero;
      }

      foreach (var item in items)
      {
         item.transform.DOScale(1f,fadeTime).SetEase(Ease.InOutQuint);
         yield return new WaitForSeconds(0.25f);
      } 
   }
}
