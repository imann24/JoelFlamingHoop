using UnityEngine;
using System.Collections;

public class timer : MonoBehaviour {
	public float timeLimit = 10.0f;
	public float redFontTime = 2.0f;
	public float timeLeft;
	public float countSpeed = 1f;

	public GUIStyle customGuiStyle;
	// Use this for initialization
	private GameController gameController;

	void Start(){
		gameController = GetComponent<GameController> ();
	}
	void OnGUI() {
		int minutes = Mathf.FloorToInt(timeLeft / 60.0f);
		int seconds = Mathf.FloorToInt(timeLeft - minutes * 60);
	
		string niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);

		GUI.Label(new Rect((Screen.width / 1.5f) , 30f,200,100), niceTime, customGuiStyle);
	}
// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime * countSpeed;
		if (timeLeft <= redFontTime) {
			customGuiStyle.normal.textColor = Color.red;
		} else {
			customGuiStyle.normal.textColor = Color.blue;
		}
		if (timeLeft <= 0f) {
			gameController.End();
			enabled = false;
		}
	}

}
