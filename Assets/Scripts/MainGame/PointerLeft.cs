using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PointerLeft : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

	public Basket basket;

	public void OnPointerDown(PointerEventData data){
		Debug.Log ("Button Right Hold Down" + data.pointerId);
		basket.MoveLeft ();
	}

	public void OnPointerUp(PointerEventData data){
		Debug.Log ("Button Right Hold Down" + data.pointerId);
		basket.MoveCenter ();
	}
}
