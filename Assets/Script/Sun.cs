using UnityEngine;
using System.Collections;

public class Sun : Entity{
	void Update(){
		Quaternion rotation = transform.rotation;
		rotation.eulerAngles = new Vector3(0, 0, Time.time*25);
		transform.rotation = rotation;
	}
}
