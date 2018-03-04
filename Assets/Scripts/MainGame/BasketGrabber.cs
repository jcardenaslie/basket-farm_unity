using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasketGrabber : MonoBehaviour {
	public GameController gm;

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Fruit"){
			gm.addScore ();
			Destroy(other.gameObject);
		} else if (other.tag == "Bomb") {
			
			Bomb bomb = (Bomb)other.gameObject.GetComponent<Bomb>();
            bomb.OnDestroy ();

            Basket basket = this.gameObject.GetComponent<Basket>();

            this.gameObject.SetActive(false);

            gm.GameOver();

		}

	}
}
