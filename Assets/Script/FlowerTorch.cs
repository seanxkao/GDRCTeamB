using UnityEngine;
using System.Collections;

public class FlowerTorch : Item {
	static bool hasSpawn = false;
	GameObject cave;
	public Material cleanCaveMaterial;
	// Use this for initialization
	void Awake(){
		
	}

	void Start () {
		if(hasSpawn){
			Destroy (gameObject);
		}
		hasSpawn = true;
		base.Start ();
		state = 3; // in the pot
		cave = null;
	}
	public override void use (GameObject player){
		if (cave && cameraController.GetComponent<CameraController> ().turn) {
			base.use (player);
			cave.GetComponent<Entity> ().front.GetComponent<Renderer> ().material = cleanCaveMaterial;
			cave.GetComponent<Entity> ().back.GetComponent<Renderer> ().material = cleanCaveMaterial;
			cave.GetComponent<Collider> ().enabled = false;
			Destroy (gameObject);
		}
	}
	public override void pick(GameObject player){
		zsort = 0.06f;
		base.pick (player);
	}
	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.CompareTag ("Cave")) {
			cave = collider.gameObject;
		}
	}
	void OnTriggerExit(Collider collider) {
		if (collider.gameObject.CompareTag ("Cave")) {
			cave = null;
		}
	}

}
