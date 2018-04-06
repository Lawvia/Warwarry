using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	private bool canContinue = true;

	void Start () {
		//string checkLevelName = PlayerPrefs.GetString("savedLevel");
	//	if(checkLevelName == null || checkLevelName == ""){
	//		canContinue = false;
	//	}
	}

	void newGame () {
		//PlayerPrefs.DeleteAll();
		Application.LoadLevel("vsAI-1");
	}

	void loadGame () {
		//if (canContinue) {
	//		string levelName = PlayerPrefs.GetString ("savedLevel");
	//		Application.LoadLevel (levelName);
		//}
		Application.LoadLevel("starting");
	}
}
