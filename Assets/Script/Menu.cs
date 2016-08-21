using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	public string loadScene1;
	public string loadScene2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartGame () {
		print ("StartGame");
		SceneManager.LoadScene (loadScene1);
	}


	public void ExitGame () {
		print ("ExitGame");
		Application.Quit();
	}

	public void BackMenu() {
		print ("BackMenu");
		SceneManager.LoadScene (loadScene2);
	}
		
}
