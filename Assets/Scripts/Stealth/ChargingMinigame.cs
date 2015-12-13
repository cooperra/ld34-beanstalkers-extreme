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

	private Vector3 _shakePoint = new Vector3(0,0, -10);
	private float _progress = 0.0f;
	private bool _holding = false;

	protected override void GameUpdate(){

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

		ProgressDisplay.GetComponent<RectTransform>().sizeDelta = new Vector2(_progress * 500, ProgressDisplay.GetComponent<RectTransform>().sizeDelta.y);

	}
	
}
