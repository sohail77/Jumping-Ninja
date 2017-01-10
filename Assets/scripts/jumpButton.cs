using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class jumpButton : MonoBehaviour,IPointerDownHandler,IPointerUpHandler {


	public void OnPointerDown(PointerEventData data){
		if (playerJumpScript.instance != null) {
			playerJumpScript.instance.SetPower (true);
		}
	}

	public void OnPointerUp(PointerEventData data){
		if (playerJumpScript.instance != null) {
			playerJumpScript.instance.SetPower (false);
		}


	}
		
}
