using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

	public GameObject vx_explosion;

	public void OnDestroy(){
		GameObject explosion = (GameObject)Instantiate (
			vx_explosion, 
			this.gameObject.transform.position, 
			Quaternion.identity
		);
		Destroy (this.gameObject);
		Destroy (explosion, 1.0f);
	}
}
