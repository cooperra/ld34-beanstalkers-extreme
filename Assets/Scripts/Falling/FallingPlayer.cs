using UnityEngine;
using System.Collections;

public class FallingPlayer : MainBehaviour {

	public float FallAcceleration = 1.0f; // per frame?
	public float FallMaxSpeed = 2.0f;//3

	public float HorizontalSpeed = 2.0f;//5
	public float HorizontalMaxSpeed = 4.0f;//2

	public float HorizontalLimits = 3.0f;//3


	private float _xVelocity = 0.0f;
	private float _yVelocity = 0.0f;
	private float _input = 0.0f;


		

	protected override void GameUpdate(){

		_input = PlayerInput.Instance.UserInput;

		if(_input != 0.0f){
			_xVelocity += (HorizontalSpeed * _input) * Time.deltaTime;
		}
		else{
			_xVelocity =Mathf.Lerp(_xVelocity, 0, 4.5f * Time.deltaTime);
		}

		_yVelocity -= FallAcceleration;
		_yVelocity = Mathf.Clamp(_yVelocity, -FallMaxSpeed, 0);

		_xVelocity = Mathf.Clamp(_xVelocity, -HorizontalMaxSpeed, HorizontalMaxSpeed);

		transform.position = new Vector3(transform.position.x + (_xVelocity * Time.deltaTime), transform.position.y + (_yVelocity * Time.deltaTime), 0);

		transform.position = new Vector2(Mathf.Clamp(transform.position.x, -HorizontalLimits, HorizontalLimits), transform.position.y);

		transform.Rotate(new Vector3(0,0, 80 * Time.deltaTime));

	}

}
