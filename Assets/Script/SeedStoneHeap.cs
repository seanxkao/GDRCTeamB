using UnityEngine;
using System.Collections;

public class SeedStoneHeap : Item {
	public GameObject seedStone;
	// Use this for initialization
	protected void Start () {
	
	}

	public override void pick (GameObject player)
	{
		GameObject newSeed = Instantiate(seedStone);
		newSeed.GetComponent<SeedStone> ().cameraController = cameraController;
		newSeed.GetComponent<SeedStone>().pick (player);
		player.GetComponent<Player> ().itemOnHand = newSeed;
	}
}
