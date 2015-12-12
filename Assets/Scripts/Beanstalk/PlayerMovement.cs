using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float PlayerInput = 0.0f;
	public float HorizontalSpeed = 2.0f;
	public float MaxHorizontalSpeed = 5.0f;
	public float VerticalSpeed = 5.0f;

	public float HorizontalLimits = 10.0f;

	private Vector2 _velocity = new Vector2();

	void Update(){

		if(Application.platform == RuntimePlatform.WebGLPlayer || Application.isEditor)
			PlayerInput = Input.GetAxis("Horizontal");

		//transform.Translate(new Vector2(((Vector2.right.x * HorizontalSpeed) * PlayerInput) * Time.deltaTime, 0), Space.World);

		_velocity = new Vector2(_velocity.x + ((HorizontalSpeed * PlayerInput) * Time.deltaTime), _velocity.y);
		if(PlayerInput == 0)
			_velocity = new Vector2(Mathf.Lerp(_velocity.x, 0, 4.5f * Time.deltaTime), _velocity.y);

		_velocity = new Vector2(Mathf.Clamp(_velocity.x, -MaxHorizontalSpeed, MaxHorizontalSpeed), _velocity.y);

		transform.position = new Vector2(transform.position.x + _velocity.x, transform.position.y + _velocity.y);

		transform.position = new Vector2(Mathf.Clamp(transform.position.x, -HorizontalLimits, HorizontalLimits), transform.position.y);

		transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0,0, -PlayerInput * 25f)), 3.0f * Time.deltaTime);

	}

	public void InputButton(float input){
		PlayerInput = input;
	}

}
