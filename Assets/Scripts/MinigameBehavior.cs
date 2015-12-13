using UnityEngine;
using System.Collections;

public class MinigameBehavior : MainBehaviour {

	private MinigameManager _minigameManager;
	public GameObject[] NecessaryObjects;
	public GameObject NextGame;

	// Use this for initialization
	void Start () {
		//_minigameManager = MinigameManager.Instance;
		if (NextGame == null) {
			Debug.Log("Warning: No next game set");
		}
	}

	public virtual void Disable() {
		// disable all the things!
		this.gameObject.SetActive(false);
		foreach (GameObject o in NecessaryObjects) {
			o.SetActive(false);
		}
	}

	public virtual void Enable() {
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
			//_minigameManager.SetMinigame(NextGame);
			MinigameManager.Instance.SetMinigame(NextGame);
		}
	}

}
