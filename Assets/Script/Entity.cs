using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour {
    public GameObject cameraController;

    protected bool turning;
    protected Vector3 pastV;
	// Use this for initialization
	protected void Start () {
        turning = false;
	}

    void FixedUpdate() {
        
        if ( !turning && cameraController.GetComponent<CameraController>().isTurning() ) {
            turning = true;
            pastV = GetComponent<Rigidbody>().velocity;
            GetComponent<Rigidbody>().isKinematic = true;
        }
        else if (turning && !cameraController.GetComponent<CameraController>().isTurning()) {
            turning = false;
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().velocity = pastV;
        }
        moveEntity();
    }
    protected virtual void moveEntity(){
    }
}
