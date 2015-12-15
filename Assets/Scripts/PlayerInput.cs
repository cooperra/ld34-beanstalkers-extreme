using UnityEngine;
using System.Collections;

public class PlayerInput : MainBehaviour {

	public static PlayerInput Instance {get; private set;}

	public float UserInput = 0.0f;

	void Awake(){
		if(Instance == null)
			Instance = this;
	}

	public void InputButton(float input){
		UserInput = input;
	}

	protected override void Update(){
		base.Update();
		if(Application.platform == RuntimePlatform.WebGLPlayer || Application.isEditor)
			UserInput = Input.GetAxis("Horizontal");
	}
}
