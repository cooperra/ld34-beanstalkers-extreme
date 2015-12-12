using UnityEngine;
using System.Collections;

public class BeanstalkMinigame : MonoBehaviour {

	public int GoalHeight = 100;
	public GameObject Player;
	private MinigameManager _minigameManager;
	public GameObject StealthMinigame;
	
	// Use this for initialization
	void Start () {
		_minigameManager = GameObject.Find("Minigame Manager").GetComponent<MinigameManager>();
		if (StealthMinigame == null) throw new System.Exception("StealthMinigame is null");
	}
	
	// Update is called once per frame
	void Update () {
		if (Player.transform.position.y >= GoalHeight) {
			Win();
		}
	}

	void Win() {
		_minigameManager.SetMinigame(StealthMinigame);
	}
}
