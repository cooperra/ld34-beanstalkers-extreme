using UnityEngine;
using System.Collections;

public class BeanstalkMinigame : MinigameBehavior {

	public int GoalHeight = 100;
	public GameObject Player;
	public GameObject CloudHouse;
	private GameObject _cloudHouseInstance;

	// Start
	void Start () {
		if (_cloudHouseInstance == null) {
			_cloudHouseInstance = Instantiate(CloudHouse, new Vector3(0, GoalHeight - 10, 0), Quaternion.identity) as GameObject;
		}
	}
	
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
