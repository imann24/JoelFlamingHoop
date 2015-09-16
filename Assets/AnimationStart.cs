using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AnimationStart : MonoBehaviour {
	public GameObject coverImage;
	public GameObject scorePanel;
	public float FadeTime;
	public bool clickedStart = false;

	private Image image;
	private Animator anim;
	private GameController gameController;

	//This script controlls all the animations connected with the UI
	//Buttons activate these events and Animation key events activate other parts of the game
	void Start () {
		image = coverImage.GetComponent<Image> ();
		gameController = GameObject.Find ("GameController").GetComponent<GameController> ();
		anim = GetComponent<Animator> ();
	}
	public void Fade(){
		StartCoroutine ("FadeDark");
	}
	IEnumerator FadeDark(){
		//Fades image which covers screen
		float percentComplete = 0f;
		Color colorStart = new Color (0, 0, 0, 0f);
		coverImage.SetActive (true);
		Color colorEnd = new Color (0, 0, 0, 0.4f);
		while (percentComplete < 1.0) {
			percentComplete += Time.deltaTime / FadeTime;

			image.color = Color.Lerp (colorStart, colorEnd, percentComplete);

			yield return null;
		}
	}

	public void Drop(){
		scorePanel.SetActive (true);
		if (gameController.win) {
			scorePanel.transform.GetChild (0).gameObject.SetActive (true);
			scorePanel.transform.GetChild (1).gameObject.SetActive (false);
		} else {
			scorePanel.transform.GetChild (0).gameObject.SetActive (false);
			scorePanel.transform.GetChild (1).gameObject.SetActive (true);
		}
		scorePanel.transform.GetChild (2).gameObject.GetComponent<Text>().text = "Cubes Clicked: " + gameController.clicks;
		scorePanel.transform.GetChild (3).gameObject.GetComponent<Text>().text = "Wins: " + gameController.wins;
		scorePanel.transform.GetChild (4).gameObject.GetComponent<Text>().text = "Losses: " + gameController.losses;
		anim.SetTrigger ("Drop");
	}

	public void Begin(){
		gameController.GameStart ();
	}

	public void StartGame(){
		if (!clickedStart) {
			clickedStart = true;
			Debug.Log ("Started");
			anim.SetTrigger ("Start");
			//Animation key event starts game 
		}
	}
	public void Options(){
		if (!clickedStart) {
			anim.SetTrigger ("Options");
		}
	}
	public void OptionsOut(){
		anim.SetTrigger ("OptionsOut");
	}
	public void Menu(){
		anim.SetTrigger ("Menu");
		clickedStart = false;
		coverImage.SetActive (false);
		//Flags to prevent double clicking
	}


}
