using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Bomb") {
			Destroy (col.gameObject);
		} else if (col.gameObject.tag == "Fruit") {
			Destroy (col.gameObject, 0.5f);
		}
	}
}
