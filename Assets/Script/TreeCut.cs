using UnityEngine;
using System.Collections;

public class TreeCut : Entity{
	public bool isCut;
	public float cutTime;
	public float fallPeriod;

	protected void Start(){
		isCut = false;
		base.Start ();
	}
	public void cut(){
		isCut = true;
		cutTime = 0;
	}
	protected override void moveEntity(){
		if (isCut) {
			Quaternion rotation = transform.rotation;
			Vector3 eular = rotation.eulerAngles;
			if (cutTime < fallPeriod) {
				eular.z = 90-90 * Mathf.Cos((cutTime) / fallPeriod*Mathf.PI/2);
			} else {
				eular.z = 90;
				tag = "Floor";
			}
			rotation.eulerAngles = eular;
			transform.rotation = rotation;
			cutTime += Time.fixedDeltaTime;
		}
		
	}
}
