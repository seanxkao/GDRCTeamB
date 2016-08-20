using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	public string loadScene;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartGame () {
		print ("StartGame");
		//SceneManager.LoadScene (loadScene);
	}


	public void ExitGame () {
		print ("ExitGame");
		Application.Quit();
	}
		
}
