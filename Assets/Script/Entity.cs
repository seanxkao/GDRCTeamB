using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour {
    public GameObject cameraController;
    public GameObject front;
    public GameObject back;
    public float zsort;
    protected bool turning;
    protected Vector3 pastV;
    protected Rigidbody rigidbody;

	// Use this for initialization
	protected void Start () {
        turning = false;
        rigidbody = GetComponent<Rigidbody>();
	}

    void FixedUpdate() {
        
        if ( !turning && cameraController.GetComponent<CameraController>().isTurning() ) {
            turning = true;
            if (rigidbody)
            {
                pastV = rigidbody.velocity;
                rigidbody.isKinematic = true;
            }
        }
        else if (turning && !cameraController.GetComponent<CameraController>().isTurning()) {
            turning = false;
            if (rigidbody)
            {
                rigidbody.isKinematic = false;
                rigidbody.velocity = pastV;
            }
        }
        moveEntity();
    }
    protected virtual void moveEntity(){
    }
}
