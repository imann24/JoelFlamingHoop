 using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public int gridWidth;
	public int gridHeight;
	public GameObject basicCube;
	public bool gameStart = false;
	public bool gameEnd = false;

	public bool start = false;
	public bool win = false;
	public int clicks = 0;
	public int wins = 0;
	public int losses = 0;

	private float newTimeLimit = 0;
	private float newRedFontTimeLimit = 0;
	private int newGridWidth = 0;
	private int newGridHeight = 0;

	private timer timer;
	private int gridSpacing = 2;
	private GameObject[,] allCubes;
	private AnimationStart UIScript;
	void Start(){
		UIScript = GameObject.Find ("Canvas").GetComponent<AnimationStart> ();
		timer = GetComponent<timer> ();
	}

	public void Save(){
		if (newTimeLimit != 0) {
			timer.timeLimit = newTimeLimit;
		}
		if (newRedFontTimeLimit != 0) {
			timer.redFontTime = newRedFontTimeLimit;
		}
		if (newGridWidth != 0) {
			gridWidth = newGridWidth;
		}
		if (newGridHeight != 0) {
			gridHeight = newGridHeight;	
		}
	}
	public void GameLength(string newLength){
		float result;
		if (float.TryParse (newLength, out result)) {
			newTimeLimit = result;
		}
	}
	public void RedFontTime(string newRed){
		float result;
		if (float.TryParse (newRed, out result)) {
			newRedFontTimeLimit = result;
		}
	}
	public void GridWidth(string newWidth){
		int result;
		if (int.TryParse (newWidth, out result)) {
			newGridWidth = result;
		}
	}
	public void GridHeight(string newHeight){
		int result;
		if (int.TryParse (newHeight, out result)) {
			newGridHeight = result;
		}
	}
	public void GameStart(){
		allCubes = new GameObject[gridWidth, gridHeight];
		for (int x = 0; x < gridWidth; x++) {
			for (int y = 0; y < gridHeight; y++) {  
				allCubes [x, y] = (GameObject)Instantiate (basicCube, new Vector3 (x * gridSpacing - 7, y * gridSpacing - 4, 0), Quaternion.identity);
			}
		}
		start = true;
		timer.countSpeed = 1f;
		timer.timeLeft = timer.timeLimit;
		timer.enabled = true;
		int appX = Random.Range(0, gridWidth);
		int appY = Random.Range(0, gridHeight);
		allCubes [appX, appY].GetComponent<cubeBehavior> ().appendix = true;
	}
	public void Victory(){
		timer.countSpeed = 5f;
		//Victory particles
	}
	public void End(){
		if (win) {
			wins += 1;
		} else {
			losses += 1;
		}
		UIScript.Fade();
		UIScript.Drop();
		for (int x = 0; x < gridWidth; x++) {
			for (int y = 0; y < gridHeight; y++) {  
				Destroy(allCubes [x, y]);
			}
		}
		gameStart = false;
		start = false;
		win = false;
		//GAME!
		//Camera fades dark
		//UI Drop
		//Victory! or Defeat!
		//Cubes Clicked:
		// Wins?
	}
}
