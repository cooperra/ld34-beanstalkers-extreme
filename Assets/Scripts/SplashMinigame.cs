using UnityEngine;
using System.Collections;

public class SplashMinigame : MinigameBehavior {

	private float _holdTime = 0.0f;
	protected override void GameUpdate(){

		if(PlayerInput.Instance.UserInput != 0)
			_holdTime += Time.deltaTime;
		else
			_holdTime = 0.0f;

		if(_holdTime >= 0.5f)
			ProceedNextGame();

	}
}
