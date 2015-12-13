using UnityEngine;
using System.Collections;

public class FallingPlayer : MainBehaviour {

	public float FallSpeed = 2.0f;

	public float HorizontalSpeed = 2.0f;
	public float HorizontalMaxSpeed = 4.0f;

	public float HorizontalLimits = 3.0f;


	private float _xVelocity = 0.0f;
	private float _input = 0.0f;


		

	protected override void GameUpdate(){

		_input = PlayerInput.Instance.UserInput;

		if(_input != 0.0f){
			_xVelocity += (HorizontalSpeed * _input) * Time.deltaTime;
		}
		else{
			_xVelocity =Mathf.Lerp(_xVelocity, 0, 4.5f * Time.deltaTime);
		}

		_xVelocity = Mathf.Clamp(_xVelocity, -HorizontalMaxSpeed, HorizontalMaxSpeed);

		transform.position = new Vector3(transform.position.x + (_xVelocity * Time.deltaTime), transform.position.y - (FallSpeed * Time.deltaTime), 0);

		transform.position = new Vector2(Mathf.Clamp(transform.position.x, -HorizontalLimits, HorizontalLimits), transform.position.y);

	}

}
