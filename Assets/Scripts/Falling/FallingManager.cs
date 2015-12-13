using UnityEngine;
using System.Collections;

public class FallingManager : MainBehaviour {

	public GameObject[] ObjectsToDisable;
	public PlayerCamera PlayerCam;
	public Vector3 NewOffset = new Vector3(0, -2, -10);
	public Transform Player;
	public Transform OldPlayer;	// The player from the Beanstalk minigame
	public Transform Ground;
	public float EndTrigger = 20f;

	void Start(){
		PlayerCam.follow = Player;
		Player.transform.position = OldPlayer.transform.position;
		PlayerCam.offset = NewOffset;

		

	}

	protected override void GameUpdate(){
		if(Vector3.Distance(Player.position, Ground.position) <= EndTrigger)
			Debug.Log("End Minigame");
	}
	
}
