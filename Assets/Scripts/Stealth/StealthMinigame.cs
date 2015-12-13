using UnityEngine;
using System.Collections;

public class StealthMinigame : MinigameBehavior {

	public bool CanStealth = false;

	public float StealthSpeed = 2.0f;
	public float StealthForgiveness = .25f;
	public StealthPlayer Player;

	public GameObject[] DebugLights;
	public Transform Giant;
	public Transform GiantMoveTo;

	public float LoseSpeed = 1.0f;

	public float WinDistance = 25.0f;

	private int CurrentLight = 0;
	private float _currentStealthSpeed = 0.0f;
	private float _lastStealth = 0.0f;
	private float _randomTime = 0.0f;
	private float _timeModifier = 0.05f;
	private Vector3 _giantInitialPos;

	private float _progressToLose = 0.0f;

	void Awake(){

		_currentStealthSpeed = StealthSpeed;
		_giantInitialPos = Giant.localPosition;
	}

	protected override void GameUpdate(){

		if(CurrentLight == 0){
			Giant.transform.localPosition = Vector3.MoveTowards(Giant.localPosition, GiantMoveTo.localPosition, 35.0f * Time.deltaTime);
			if(!Player.Stealthed && GameTime >= _lastStealth + StealthForgiveness)
				DetectedPlayer();
		}
		else{
			if(PlayerInput.Instance.UserInput > 0)
				_progressToLose -= Time.deltaTime * .05f;

			Giant.transform.localPosition = Vector3.MoveTowards(Giant.localPosition, _giantInitialPos, 25.0f * Time.deltaTime);
		}

		_progressToLose = Mathf.Clamp01(_progressToLose);

		if(GameTime >= _lastStealth + _randomTime){

			CurrentLight = CurrentLight == 0 ? 1 : 0;

			if(CurrentLight == 0){
				DebugLights[0].GetComponent<SpriteRenderer>().color = Color.red;
				DebugLights[1].GetComponent<SpriteRenderer>().color = Color.black;
			}
			else{
				DebugLights[0].GetComponent<SpriteRenderer>().color = Color.black;
				DebugLights[1].GetComponent<SpriteRenderer>().color = Color.green;
			}

			_currentStealthSpeed -= _timeModifier;
			_randomTime = Random.Range(0.0f, StealthSpeed - _timeModifier);
			_lastStealth = GameTime;

		}

		Giant.GetComponent<SpriteRenderer>().color = Color.Lerp(Color.white, Color.red, _progressToLose);

		if(Player.transform.position.x >= WinDistance)
			Win();

	}

	void DetectedPlayer(){

		_progressToLose += LoseSpeed * Time.deltaTime;
		Debug.Log("Player is detected!!");

		if(_progressToLose >= 1.0f)
			Lose();

	}

	void Win() {
		Debug.Log("YOU WIN");
		ProceedNextGame();
	}

	void Lose(){

		Debug.Log("YOU LOSE");

	}

}
