using UnityEngine;
using System.Collections;

public class StealthPlayer : MainBehaviour{

	private float _input = 0.0f;

	protected override void GameUpdate(){

		_input = PlayerInput.Instance.UserInput;

		

	}

}
