using UnityEngine;
using System.Collections;

public class StealthPlayer : MainBehaviour{

	public float MovementSpeed = 1.0f;
	public bool Stealthed = false;
	private float _input = 0.0f;

	protected override void GameUpdate(){

		_input = PlayerInput.Instance.UserInput;

		if(_input == 1){
			transform.position = new Vector2(transform.position.x + (MovementSpeed * Time.deltaTime), transform.position.y);
			Stealthed = false;
		}
		else if(_input == -1)
			Stealthed = true;
		else
			Stealthed = false;

	}

}
