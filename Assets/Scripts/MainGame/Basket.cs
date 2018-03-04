using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour {

	public GameObject[] positionPoints;


	private bool isNotCenter = false;


	void Start(){
		Debug.Log ("Tag " + this.tag);
	}

	public void MoveRight(){
		isNotCenter = true;
		Debug.Log ("Basket Move Right");
		Vector3 newPos = new Vector3 (
			positionPoints [2].transform.position.x,
			this.transform.position.y,
			0
		);
		this.transform.position = newPos;
	}
	public void MoveCenter(){
		isNotCenter = true;
		Debug.Log ("Basket Move Center");
		Vector3 newPos = new Vector3 (
			positionPoints [1].transform.position.x,
			this.transform.position.y,
			0
		);
		this.transform.position = newPos;
	}
	public void MoveLeft(){
		Debug.Log ("Basket Move left");
		Vector3 newPos = new Vector3 (
			positionPoints [0].transform.position.x,
			this.transform.position.y,
			0
		);
		this.transform.position = newPos;
	}

	public bool IsNotCenter {
		get {
			return isNotCenter;
		}
	}
}
