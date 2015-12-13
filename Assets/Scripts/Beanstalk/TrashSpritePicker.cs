using UnityEngine;
using System.Collections;

public class TrashSpritePicker : MonoBehaviour {

	public Sprite[] RandomSprites;

	void Start(){
		int random = Random.Range(0, RandomSprites.Length);
		GetComponent<SpriteRenderer>().sprite = RandomSprites[random];
	}

}
