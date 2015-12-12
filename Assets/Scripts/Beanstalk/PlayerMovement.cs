using UnityEngine;
using System.Collections;

public class PlayerMovement : MainBehaviour {

	public float HorizontalSpeed = 2.0f;
	public float MaxHorizontalSpeed = 5.0f;
	public float VerticalSpeed = 5.0f;

	public float HorizontalLimits = 10.0f;

	public float OutOfControlTimeLimit = 3.0f;

	private Vector2 _velocity = new Vector2();
	private bool _outOfControl = false;
	private float _outOfControlTime = 0.0f;
	private float _input = 0.0f;

	protected override void GameUpdate(){

		//if(Application.platform == RuntimePlatform.WebGLPlayer || Application.isEditor)
		//	PlayerInput = Input.GetAxis("Horizontal");

		_input = PlayerInput.Instance.UserInput;

		//transform.Translate(new Vector2(((Vector2.right.x * HorizontalSpeed) * PlayerInput) * Time.deltaTime, 0), Space.World);

		if(!_outOfControl){
			_velocity = new Vector2(_velocity.x + ((HorizontalSpeed * _input) * Time.deltaTime), VerticalSpeed);
			if(_input == 0)
				_velocity = new Vector2(Mathf.Lerp(_velocity.x, 0, 4.5f * Time.deltaTime), _velocity.y);

			_velocity = new Vector2(Mathf.Clamp(_velocity.x, -MaxHorizontalSpeed, MaxHorizontalSpeed), _velocity.y);

			transform.position = new Vector2(transform.position.x + _velocity.x, transform.position.y + _velocity.y);
			transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0,0, -_input * 35f)), 3.0f * Time.deltaTime);

		}
		else{
			transform.Rotate(new Vector3(0,0, 800 * Time.deltaTime));
			if(GameTime >= _outOfControlTime + OutOfControlTimeLimit){
				GetComponent<Rigidbody2D>().velocity = Vector2.zero;
				GetComponent<Rigidbody2D>().isKinematic = false;
				_outOfControl = false;

			}
			_velocity.y -= 0.05f * Time.deltaTime;
			_velocity = new Vector2(Mathf.Clamp(_velocity.x, -MaxHorizontalSpeed, MaxHorizontalSpeed), Mathf.Clamp(_velocity.y, 0, VerticalSpeed));
			transform.position = new Vector2(transform.position.x, transform.position.y + _velocity.y);
		}

			transform.position = new Vector2(Mathf.Clamp(transform.position.x, -HorizontalLimits, HorizontalLimits), transform.position.y);

	}

	public void OutOfControl(Transform enemy){

		_outOfControl = true;

		GetComponent<Rigidbody2D>().isKinematic = false;
		GetComponent<Rigidbody2D>().AddForce(new Vector2((transform.position.x - enemy.transform.position.x) * 250,0));
		_outOfControlTime = GameTime;

	}

}
