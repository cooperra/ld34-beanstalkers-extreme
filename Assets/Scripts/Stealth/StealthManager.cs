using UnityEngine;
using System.Collections;

public class StealthManager : MainBehaviour {

	public static StealthManager Instance {get; private set;}

	public bool CanStealth = false;

	public float StealthSpeed = 2.0f;
	public float StealthForgiveness = .25f;
	public StealthPlayer Player;

	public GameObject[] DebugLights;

	private int CurrentLight = 0;
	private float _currentStealthSpeed = 0.0f;
	private float _lastStealth = 0.0f;
	private float _randomTime = 0.0f;
	private float _timeModifier = 0.05f;

	void Awake(){
		if(Instance == null)
			Instance = this;

		_currentStealthSpeed = StealthSpeed;
	}

	protected override void GameUpdate(){

		if(CurrentLight == 0)
			if(!Player.Stealthed && GameTime >= _lastStealth + StealthForgiveness)	
				DetectedPlayer();

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

	}

	void DetectedPlayer(){

		Debug.Log("Player is detected!!");

	}

}
