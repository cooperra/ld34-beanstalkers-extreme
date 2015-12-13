using UnityEngine;
using System.Collections;

public abstract class MinigameBehavior : MainBehaviour {

	private MinigameManager _minigameManager;
	public GameObject[] NecessaryObjects;
	public GameObject NextGame;

	// Use this for initialization
	public void Start () {
		_minigameManager = GameObject.Find("Minigame Manager").GetComponent<MinigameManager>();
		if (NextGame == null) {
			Debug.Log("Warning: No next game set");
		}
	}

	public void Disable() {
		// disable all the things!
		this.gameObject.SetActive(false);
		foreach (GameObject o in NecessaryObjects) {
			o.SetActive(false);
		}
	}

	public void Enable() {
		// reenable all the things!
		this.gameObject.SetActive(true);
		foreach (GameObject o in NecessaryObjects) {
			o.SetActive(true);
		}
	}

	//public Init() {
	//	// set it up!
	//}

	//public Reset() {
	//	// reset it up!
	//}

	public void ProceedNextGame() {
		if (NextGame == null) {
			Debug.Log("ProceedNextGame, but no next game set");
		} else {
			_minigameManager.GetComponent<MinigameManager>().SetMinigame(NextGame);
		}
	}

}
