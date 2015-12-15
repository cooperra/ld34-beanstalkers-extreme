using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UISpriteSwitch : MonoBehaviour {

	public Sprite DefaultSprite;
	public Sprite SwitchedSprite;

	public float myInput = 1;

	public void PickDefault(){

		GetComponent<Image>().sprite = DefaultSprite;

	}

	public void PickSwitched(){

		GetComponent<Image>().sprite = SwitchedSprite;

	}

	void Update(){
		if(PlayerInput.Instance.UserInput == myInput)
			PickSwitched();
		else
			PickDefault();
	}

}
