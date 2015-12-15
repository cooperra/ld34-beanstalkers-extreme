using UnityEngine;
using System.Collections;

public class TutorialDismiss : MainBehaviour {

	private float _timer = 0.0f;

	protected override void Update(){

		base.Update();

		if(PlayerInput.Instance.UserInput != 0 && MinigameManager.Instance.TutorialShowing)
			_timer += Time.deltaTime;
		else if(!MinigameManager.Instance.TutorialShowing)
			_timer = 0.0f;
		if(_timer >= 1f){
			MinigameManager.Instance.CurrentMinigame.EndTutorial();
			_timer = 0.0f;
		}

	}
}
