using UnityEngine;
using System.Collections;

public class TrashGenerator : MainBehaviour {

	public Transform Player;
	public GameObject TrashObject;
	public float Rate = 5.0f;
	private float _lastTime = 0.0f;

	protected override void GameUpdate(){

		if(GameTime >= _lastTime + Rate){

			GameObject obj = Instantiate(TrashObject, new Vector3(Random.Range(-3, 3), Player.transform.position.y + 10, 0), Quaternion.identity) as GameObject;
			obj.transform.parent = transform.parent;

			_lastTime = GameTime;
		}

	}

}
