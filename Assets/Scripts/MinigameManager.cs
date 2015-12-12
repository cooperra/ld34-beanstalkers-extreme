﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// public enum Minigames{
// 	ASCENT,
// 	SNEAK
// }


public class MinigameManager : MonoBehaviour {

	// private Minigames _currentMinigame;
	private GameObject _currentMinigame;
	// private Dictionary<Minigames, GameObject> MinigameMap;

	// Use this for initialization
	void Start () {
		// _currentMinigame = Minigames.ASCENT;
		// MinigameMap = new Dictionary<Minigames, GameObject>
		// 	{{Minigames.ASCENT, GameObject.Find("Beanstalk Setup")},
		// 	 {Minigames.SNEAK, GameObject.Find("Stealth Game Setup")}};
		// Debug.Log(MinigameMap[Minigames.ASCENT]);
		// Debug.Log(MinigameMap[Minigames.SNEAK]);

		_currentMinigame = GameObject.FindGameObjectsWithTag("Minigame")[0];
		Debug.Log(_currentMinigame);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetMinigame(GameObject m) {
		SwitchMinigame(_currentMinigame, m);
		_currentMinigame = m;
	}


	private void SwitchMinigame(GameObject old_m, GameObject new_m) {
		old_m.SetActive(false);
		new_m.SetActive(true);
	}
}