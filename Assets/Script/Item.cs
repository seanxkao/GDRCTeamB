using UnityEngine;
using System.Collections;

public class Item : Entity {
	public Vector3 offsetOnFloor;
	public Vector3 offsetOnHand;
	public Vector3 angleOnFloor;
	public Vector3 angleOnHand;

    new public string name;
    public bool pickable;
    public int state;

	// Use this for initialization
	protected new void Start () {
        pickable = true;
        base.Start();
	}

    public bool isPickable() {
        return pickable;
    }
	
	// Update is called once per frame
	protected void FixedUpdate () {
        switch (state) { 
            case 0:
                idle();
                break;
            case 1:
                held();
                break;
            case 2:
                used();
                break;
        }
        base.FixedUpdate();
	}

    protected virtual void idle()
    {
        RaycastHit[] hits = Physics.RaycastAll(transform.position, new Vector3(0, -1, 0));
        foreach(RaycastHit hit in hits)
        {
            if (hit.collider.gameObject.CompareTag("Floor"))
            {
				transform.position = Vector3.Lerp(transform.position, hit.point + offsetOnFloor, 0.2f);
				Quaternion rotation = transform.rotation;
				rotation.eulerAngles = angleOnFloor;
				transform.rotation = rotation;
                break;
            }
        }
    }
    protected virtual void held()
	{
		Vector3 scale = transform.localScale;
		scale.x = 1;
		transform.localScale = scale;
    }

    protected virtual void used()
    {
        //after used
    }
	public virtual void pick(GameObject player)
    {
        //TODO: picked by player
        transform.SetParent(player.transform);
		transform.localPosition = offsetOnHand;
		transform.localEulerAngles = angleOnHand;
        state = 1;
    }
    public virtual void drop(GameObject player)
    {
        //TODO: droped by player
        transform.parent = null;
        state = 0;
    }
    public virtual void use(GameObject player)
    {
        //TODO: used by player
        pickable = false;
        state = 2;
    }
}
