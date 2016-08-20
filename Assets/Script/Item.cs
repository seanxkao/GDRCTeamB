using UnityEngine;
using System.Collections;

public class Item : Entity {
    public string name;
    protected bool pickable;


	// Use this for initialization
	void Start () {
        pickable = true;
        base.Start();
	}

    public void picked() { 
        //TODO: picked by player
    }

    public bool isPickable() {
        return pickable;
    }
	
	// Update is called once per frame
	//void Update () {
	   
	//}
}
