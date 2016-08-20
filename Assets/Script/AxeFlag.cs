using UnityEngine;
using System.Collections;

public class AxeFlag : Item {

	public GameObject treeCut;

	void Start() {
		base.Start ();
		treeCut = null;
	}
	protected override void idle(){
		pickable = cameraController.GetComponent<CameraController>().turn;
		base.idle ();
	}
	public override void use(GameObject player){
		if(treeCut) {
			treeCut.GetComponent<TreeCut> ().cut ();
			treeCut = null;
		}
	}
	void OnTriggerEnter(Collider collider) {
		if(collider.gameObject.CompareTag("TreeCut") && !collider.gameObject.GetComponent<TreeCut>().isCut) {
			treeCut = collider.gameObject;
		}
	}
	void OnTriggerExit(Collider collider) {
		if (collider.gameObject.CompareTag ("TreeCut")) {
			treeCut = null;
		}
	}
}
