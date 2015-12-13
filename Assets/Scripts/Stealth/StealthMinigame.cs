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
	public Sprite AngryGiantSprite;

	public float LoseSpeed = 1.0f;

	public float WinDistance = 25.0f;

	public AudioClip[] FloorCreaks;
	public AudioClip[] HuhSounds;
	public AudioClip GiantDiscoverySound;

	private int CurrentLight = 0;
	private float _currentStealthSpeed = 0.0f;
	private float _lastStealth = 0.0f;
	private float _randomTime = 0.0f;
	private float _timeModifier = 0.05f;
	private Vector3 _giantInitialPos;

	private float _progressToLose = 0.0f;
	private bool _started = false;
	private bool _hasLost = false;

	void Awake(){

		_currentStealthSpeed = StealthSpeed;
		_giantInitialPos = Giant.localPosition;
	}

	protected override void GameUpdate(){

		if(!_started){
			if(PlayerInput.Instance.UserInput != 0)
				_started = true;
			return;
		}

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
				int random = Random.Range(0, HuhSounds.Length);
				AudioSource.PlayClipAtPoint(HuhSounds[random], Player.transform.position);
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

		SoundPlayer();

	}

	void DetectedPlayer(){

		_progressToLose += LoseSpeed * Time.deltaTime;
		Debug.Log("Player is detected!!");

		if(_progressToLose >= 1.0f)
			Lose();

	}

	private float _timeSinceLastSound = 0.0f;
	private void SoundPlayer(){

		if(PlayerInput.Instance.UserInput > 0){
			if(GameTime >= _timeSinceLastSound + 1.5f){
				int random = Random.Range(0, FloorCreaks.Length);
				AudioSource.PlayClipAtPoint(FloorCreaks[random], Player.transform.position, .35f);
				_timeSinceLastSound = GameTime;
			}
		}

	}

	void Win() {
		Debug.Log("YOU WIN");
		ProceedNextGame();
	}

	void Lose(){
		if (!_hasLost) {
			Debug.Log("YOU LOSE");
			// Play cranky giant sound
			if (GiantDiscoverySound == null) {
				Debug.LogWarning("No GiantDiscoverySound selected.", this);
			} else {
				AudioSource.PlayClipAtPoint(GiantDiscoverySound, Player.transform.position);
			}
			// Change giant sprite
			Giant.GetComponent<SpriteRenderer>().sprite = AngryGiantSprite;
			_hasLost = true;
		}

	}

}
