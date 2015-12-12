using UnityEngine;
using System.Collections;

public abstract class MainBehaviour : MonoBehaviour {

	public static float TileSize = 32f;

	protected float GameTime = 0.0f;
	protected float DeltaTime = 0.0f;

	protected virtual void GameUpdate(){}
	protected virtual void LateGameUpdate(){}
	protected virtual void FixedGameUpdate(){}

	protected virtual void Update(){
		if(StateManager.Instance != null && StateManager.Instance.IsRunning ()){
			DeltaTime = Time.deltaTime;
			GameTime += DeltaTime;
			GameUpdate();
		}
	}

	protected virtual void LateUpdate(){
		if(StateManager.Instance != null && StateManager.Instance.IsRunning ())
			LateGameUpdate();
	}

	protected virtual void FixedUpdate(){
		if(StateManager.Instance != null && StateManager.Instance.IsRunning ())
			FixedGameUpdate();
	}

	public static float ConvertToPixels(float tiles){
		return tiles * TileSize;
	}

	protected delegate void DoFor();
	event DoFor doFor;
	protected delegate void DoEnd();
	event DoEnd doEnd;

	/// <summary>
	/// Does a function every frame for x amount of seconds.
	/// </summary>
	protected IEnumerator DoForSeconds(DoFor callback, float time, DoEnd doOnEnd = null){
		
		doFor += callback;
		float timer = 0.0f;
		if(doOnEnd != null)
			doEnd += doOnEnd;
		while(timer < time){
			if(StateManager.Instance.IsRunning()){
				doFor();
				timer += DeltaTime;
			}
			yield return null;
		}
		if(doEnd != null){
			doEnd();
			doEnd -= doOnEnd;
		}
		doFor -= callback;
	}

	IEnumerator DoEvery(float seconds){
		while(true){
			yield return new WaitForSeconds(seconds);
		}
	}

}
