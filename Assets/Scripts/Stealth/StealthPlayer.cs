using UnityEngine;
using System.Collections;

public class StealthPlayer : MainBehaviour{

	public float MovementSpeed = 1.0f;
	public bool Stealthed = false;
	private float _input = 0.0f;

	public Sprite StealthSprite;
	private Sprite _nonStealthedSprite;

	protected override void GameUpdate(){

		_input = PlayerInput.Instance.UserInput;

		if(_input == 1){
			transform.position = new Vector2(transform.position.x + (MovementSpeed * Time.deltaTime), transform.position.y);
			NoStealth();
		}
		else if(_input == -1)
			YesStealth();
		else
			NoStealth();

	}

	private void NoStealth() {
		if (Stealthed) {
			Stealthed = false;
			// Unset stealth sprite
			if (StealthSprite != null) {
				GetComponent<SpriteRenderer>().sprite = _nonStealthedSprite;
			}
		}
	}

	private void YesStealth() {
		if (!Stealthed) {
			Stealthed = true;
			// Set stealth sprite
			if (StealthSprite != null) {
				_nonStealthedSprite = GetComponent<SpriteRenderer>().sprite;
				GetComponent<SpriteRenderer>().sprite = StealthSprite;
			}
		}
	}

}
