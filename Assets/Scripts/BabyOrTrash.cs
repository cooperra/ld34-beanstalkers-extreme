using UnityEngine;
using System.Collections;

public class BabyOrTrash : MainBehaviour {
	public bool IsBaby;
	
	public void Update() {
		GetComponent<SpriteRenderer>().enabled = (StateManager.Instance.HasBabby && IsBaby) || (!StateManager.Instance.HasBabby && !IsBaby);
	}
}
