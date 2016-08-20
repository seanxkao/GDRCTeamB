using UnityEngine;
using System.Collections;

public class Item : Entity {
    public string name;
    public bool pickable;
    int state;

	// Use this for initialization
	void Start () {
        state = 0;
        //pickable = true;
        base.Start();
	}

    public bool isPickable() {
        return pickable;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
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

    protected void idle()
    {
        RaycastHit[] hits = Physics.RaycastAll(transform.position, new Vector3(0, -1, 0));
        foreach(RaycastHit hit in hits)
        {
            if (hit.collider.gameObject.CompareTag("Floor"))
            {
                transform.position = Vector3.Lerp(transform.position, hit.point + new Vector3(0, 0.5f, 0), 0.2f);
                //break;
            }
        }
    }
    protected virtual void held()
    {
        //holding by player
    }

    protected virtual void used()
    {
        //after used
    }
    public virtual void pick(GameObject player)
    {
        //TODO: picked by player
        transform.SetParent(player.transform);
        transform.localPosition = new Vector3(0.3f, 0.3f, 0);
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
