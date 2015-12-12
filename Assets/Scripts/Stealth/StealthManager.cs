using UnityEngine;
using System.Collections;

public class StealthManager : MainBehaviour {

	public static StealthManager Instance {get; private set;}

	public bool CanStealth = false;

	public float StealthSpeed = 2.0f;

	public GameObject[] DebugLights;

	private int _debugLightToPick = 0;
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

		if(GameTime >= _lastStealth + _randomTime){

			_debugLightToPick = _debugLightToPick == 0 ? 1 : 0;

			if(_debugLightToPick == 0){
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

}
