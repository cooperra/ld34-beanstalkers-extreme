using UnityEngine;
using System.Collections;

public class EndingScene : MinigameBehavior {

	public Transform thisCamera;
	public float ShakeRange = 2.0f;
	public float ShakeSpeed = 5.0f;
	public SpriteRenderer FadeSprite;
	private Vector3 _shakePoint = new Vector3(0,0, -10);
	
	protected override void GameUpdate(){
		if(Vector3.Distance(thisCamera.position, _shakePoint) <= .1f)
			_shakePoint = new Vector3(Random.Range(-ShakeRange, ShakeRange), Random.Range(-ShakeRange, ShakeRange), -10);

		thisCamera.position = Vector3.Lerp(thisCamera.position, _shakePoint, ShakeSpeed);

		FadeSprite.color = Color.Lerp(FadeSprite.color, Color.white, 1.0f * Time.deltaTime);
	}
}
