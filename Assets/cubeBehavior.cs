using UnityEngine;
using System.Collections;

public class cubeBehavior : MonoBehaviour {
	public bool appendix = false;

	private bool clicked = false;
	private GameController gameController;
	private Renderer rend;

	void Start(){
		gameController = GameObject.Find ("GameController").GetComponent<GameController> ();
		rend = GetComponent<Renderer> ();
	}
//	public void Reset(){
//		rend.material.color = Color.white;
//		clicked = false;
//		appendix = false;
//	}

	void OnMouseUp(){
		//if !clicked add a click count and change color if appendix make win true
		if (gameController.start) {
			if (!clicked){
				gameController.clicks += 1;
				if (appendix) {
					rend.material.color = Color.green;
					gameController.win = true;
					gameController.Victory();
				} else {
					rend.material.color = Color.red;
				}
				clicked = true;
			}
		}
	}
}
