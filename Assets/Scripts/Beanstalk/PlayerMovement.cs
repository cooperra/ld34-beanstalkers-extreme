using UnityEngine;
using System.Collections;

public class PlayerMovement : MainBehaviour {

	public float HorizontalSpeed = 2.0f;
	public float MaxHorizontalSpeed = 5.0f;
	public float VerticalSpeed = 5.0f;

	public float HorizontalLimits = 10.0f;

	public float OutOfControlTimeLimit = 3.0f;

	public float InvincibleTime = 5.0f;

	public SpriteRenderer PlayerSprite;
	public LineRenderer LineRender;
	public SpriteRenderer CharacterSprite;

	private Vector2 _velocity = new Vector2();
	private bool _outOfControl = false;
	private float _outOfControlTime = 0.0f;
	private float _input = 0.0f;

	private bool _invincible = false;
	private float _invincibleStarted = 0.0f;

	private int _hitDirection = 0;

	protected override void GameUpdate(){

		_input = PlayerInput.Instance.UserInput;

		if(!_outOfControl){
			_velocity = new Vector2(_velocity.x + ((HorizontalSpeed * _input) * Time.deltaTime), VerticalSpeed);
			if(_input == 0)
				_velocity = new Vector2(Mathf.Lerp(_velocity.x, 0, 4.5f * Time.deltaTime), _velocity.y);

			_velocity = new Vector2(Mathf.Clamp(_velocity.x, -MaxHorizontalSpeed, MaxHorizontalSpeed), _velocity.y);

			transform.position = new Vector2(transform.position.x + _velocity.x, transform.position.y + _velocity.y);
			transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0,0, -_input * 45f)), 3.0f * Time.deltaTime);

		}
		else{
			
			if(GameTime >= _outOfControlTime + OutOfControlTimeLimit){
				_outOfControl = false;
			}

			if(_hitDirection > 0)
				_velocity.x -= 0.25f * Time.deltaTime;
			else
				_velocity.x += 0.25f * Time.deltaTime;

			_velocity = new Vector2(Mathf.Clamp(_velocity.x, -MaxHorizontalSpeed, MaxHorizontalSpeed), Mathf.Clamp(_velocity.y, 0, VerticalSpeed));
			transform.position = new Vector2(transform.position.x + _velocity.x, transform.position.y + _velocity.y);
			transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0,0, -_velocity.normalized.x * 45f)), 3.0f * Time.deltaTime);
		}

			transform.position = new Vector2(Mathf.Clamp(transform.position.x, -HorizontalLimits, HorizontalLimits), transform.position.y);

		if(_invincible){
			PlayerSprite.color = Color.Lerp(PlayerSprite.color, new Color(PlayerSprite.color.r, PlayerSprite.color.g, PlayerSprite.color.b, .5f), 10.0f * Time.deltaTime);
			CharacterSprite.color = Color.Lerp(CharacterSprite.color, new Color(CharacterSprite.color.r, CharacterSprite.color.g, CharacterSprite.color.b, .5f), 10.0f * Time.deltaTime);
			LineRender.materials[0].color = Color.Lerp(LineRender.materials[0].color, new Color(LineRender.materials[0].color.r, LineRender.materials[0].color.g, LineRender.materials[0].color.b, .5f), 10.0f * Time.deltaTime);
		}
		else{
			PlayerSprite.color = Color.Lerp(PlayerSprite.color, new Color(PlayerSprite.color.r, PlayerSprite.color.g, PlayerSprite.color.b, 1), 10.0f * Time.deltaTime);
			CharacterSprite.color = Color.Lerp(CharacterSprite.color, new Color(CharacterSprite.color.r, CharacterSprite.color.g, CharacterSprite.color.b, 1), 10.0f * Time.deltaTime);
			LineRender.materials[0].color = Color.Lerp(LineRender.materials[0].color, new Color(LineRender.materials[0].color.r, LineRender.materials[0].color.g, LineRender.materials[0].color.b, 1), 10.0f * Time.deltaTime);
		}

			if(GameTime >= _invincibleStarted + InvincibleTime)
				_invincible = false;

	}

	public void OutOfControl(Transform enemy){

		if(_invincible)
			return;

		_outOfControl = true;

		_velocity.x = (Mathf.Ceil(transform.position.x - enemy.transform.position.x)) * 250;
		if(transform.position.x - enemy.transform.position.x < 0)
			_hitDirection = -1;
		else
			_hitDirection = 1;
		
		_outOfControlTime = GameTime;
		_invincibleStarted = GameTime;
		_invincible = true;

	}

	void OnDisable(){
		PlayerSprite.color = new Color(PlayerSprite.color.r, PlayerSprite.color.g, PlayerSprite.color.b, 1);
		CharacterSprite.color = new Color(CharacterSprite.color.r, CharacterSprite.color.g, CharacterSprite.color.b, 1);
		LineRender.materials[0].color = new Color(LineRender.materials[0].color.r, LineRender.materials[0].color.g, LineRender.materials[0].color.b, 1);
	}

}
