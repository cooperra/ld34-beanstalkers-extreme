using UnityEngine;
using System.Collections;

public class BeanstalkMinigame : MinigameBehavior {

	public int GoalHeight = 100;
	public GameObject Player;
	
	// Update is called once per frame
	void Update () {
		if (Player.transform.position.y >= GoalHeight) {
			Win();
		}
	}

	void Win() {
		ProceedNextGame();
	}
}
