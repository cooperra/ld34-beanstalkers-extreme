using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChargingMinigame : MinigameBehavior {

	public Transform Ground;
	public float GrowSpeed = 5.0f;
	public Transform thisCamera;
	public float ShakeRange = 2.0f;
	public float ShakeSpeed = 5.0f;

	public float HitRate = .5f;
	public float DecayRate = .35f;
	public Image ProgressDisplay;

	public float GoalTime = 3.0f;

	private Vector3 _shakePoint = new Vector3(0,0, -10);
	private float _progress = 0.0f;
	private bool _holding = false;

	private float _goalTimer = 0.0f;

	private bool _ended = false;

	protected override void GameUpdate(){

		if(_ended){
			EndingUpdate();
			return;
		}

		Ground.localScale = new Vector3(Ground.localScale.x + (GrowSpeed * DeltaTime), Ground.localScale.y + (GrowSpeed * DeltaTime), 1);

		if(Vector3.Distance(thisCamera.position, _shakePoint) <= .1f)
			_shakePoint = new Vector3(Random.Range(-ShakeRange, ShakeRange), Random.Range(-ShakeRange, ShakeRange), -10);

		thisCamera.position = Vector3.Lerp(thisCamera.position, _shakePoint, ShakeSpeed);

		if(!_holding && PlayerInput.Instance.UserInput != 0){
			_progress += HitRate * Time.deltaTime;
			_holding = true;
		}
		else if(PlayerInput.Instance.UserInput == 0)
			_holding = false;

		_progress -= ((_progress * .2f) / DecayRate) * Time.deltaTime;
		_progress = Mathf.Clamp01(_progress);

		if(_progress >= .9f){
			ProgressDisplay.color = Color.Lerp(Color.white, Color.blue, _goalTimer / GoalTime);
			_goalTimer += Time.deltaTime;
		}
		else{
			ProgressDisplay.color = Color.Lerp(ProgressDisplay.color, Color.white, 5.0f * Time.deltaTime);
			_goalTimer = 0.0f;
		}

		ProgressDisplay.GetComponent<RectTransform>().sizeDelta = new Vector2(_progress * 500, ProgressDisplay.GetComponent<RectTransform>().sizeDelta.y);

		if(_goalTimer >= GoalTime)
			EndingSetup();

	}

	public Transform Player;
	public Transform Baby;
	public Transform BabyStartPoint;
	public Transform BabyEndPoint;
	public Transform PlayerEndPoint;
	public SpriteRenderer FadeSprite;

	public float EndingTime = 5.0f;
	private float _endingTimer = 0.0f;

	private void EndingSetup(){

		Baby.position = BabyStartPoint.position;
		_ended = true;

	}

	private void EndingUpdate(){

		Baby.position = Vector3.MoveTowards(Baby.position, BabyEndPoint.position, 0.1f * Time.deltaTime);
		Baby.Rotate(new Vector3(0, 0, 45 * Time.deltaTime));

		Player.position = Vector3.Lerp(Player.position, PlayerEndPoint.position, 1.0f * Time.deltaTime);
		Ground.localScale = new Vector3(Ground.localScale.x + ((GrowSpeed * 3) * DeltaTime), Ground.localScale.y + ((GrowSpeed * 3) * DeltaTime), 1);

		_endingTimer += Time.deltaTime;

		if(_endingTimer >= EndingTime * .75f)
			FadeSprite.color = Color.Lerp(FadeSprite.color, Color.white, 5.0f * Time.deltaTime);

		if(_endingTimer >= EndingTime)
			ProceedNextGame();

	}
	
}
