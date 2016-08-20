using UnityEngine;
using System.Collections;

public class FlowerTorch : Item {
	static bool hasSpawn = false;
	// Use this for initialization
	void Awake(){
		
	}

	void Start () {
		Debug.Log ("HAHAHA");
		if(hasSpawn){
			Destroy (gameObject);
		}
		hasSpawn = true;
		base.Start ();
		state = 3; // in the pot
	}
	

}
