using UnityEngine;
using System.Collections;

public class SeedStone : Item {

	bool destroying;
	float dropTime;
	float destroyPeriod = 2;
	bool isNearPot;
	public GameObject flowerTorch;
	GameObject pot;
	public float onPotOffsetY;

	protected new void Start(){
		base.Start ();
		destroying = false;
		isNearPot = false;
		pot = GameObject.Find ("Pot");
	}
	 	
	void Update() {
		if (destroying) {
			if (Time.time - dropTime < destroyPeriod) {
				Color tmpColor = front.GetComponent<Renderer> ().material.color;
				tmpColor.a = 1 - (Time.time - dropTime) / destroyPeriod;
				front.GetComponent<Renderer> ().material.color = tmpColor;
				tmpColor = back.GetComponent<Renderer> ().material.color;
				tmpColor.a = 1 - (Time.time - dropTime) / destroyPeriod;
				back.GetComponent<Renderer> ().material.color = tmpColor;
			}
			else {
				Destroy(gameObject);
			}
		}
	}

	public override void use (GameObject player){
		if (isNearPot && !cameraController.GetComponent<CameraController>().turn) {
			base.use (player);
			GameObject newFlower = Instantiate (flowerTorch);
			newFlower.GetComponent<FlowerTorch> ().cameraController = cameraController;
			Vector3 tmpPos = pot.transform.position;
			tmpPos.y = pot.transform.position.y + onPotOffsetY;
			newFlower.transform.position = tmpPos;
			Destroy (gameObject);
		}
	}
	public override void drop (GameObject player){
		base.drop (player);
		destroying = true;
		pickable = false;
		dropTime = Time.time;
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.CompareTag ("Pot")) {
			isNearPot = true;
		}
	}
	void OnTriggerExit(Collider collider) {
		if (collider.gameObject.CompareTag ("Pot")) {
			isNearPot = false;
		}
	}
}
