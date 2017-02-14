 using UnityEngine;  
 using System.Collections;  
 using UnityEngine.EventSystems;  
 using UnityEngine.UI;
 
 public class MenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
 
     public Text theText;
 
     public void OnPointerEnter(PointerEventData eventData)
     {
         theText.color = Color.white;
     }
 
     public void OnPointerExit(PointerEventData eventData)
     {
		Color myColor = new Color();
      	ColorUtility.TryParseHtmlString("#414141FF", out myColor);
        theText.color = myColor;
     }
 }