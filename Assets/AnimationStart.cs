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
	void Start () {
		image = coverImage.GetComponent<Image> ();
		gameController = GameObject.Find ("GameController").GetComponent<GameController> ();
		anim = GetComponent<Animator> ();
	}
	public void Fade(){
		StartCoroutine ("FadeDark");
	}
	IEnumerator FadeDark(){
		float percentComplete = 0f;
		Color colorStart = image.color;
		coverImage.SetActive (true);
		Color colorEnd = new Color (0, 0, 0, 0.3f);
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
	}


}
