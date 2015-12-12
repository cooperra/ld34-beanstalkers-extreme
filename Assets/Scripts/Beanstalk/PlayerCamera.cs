using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour {

	public Transform follow;
	public Vector3 offset;

	public bool LockX = true;
	public bool LockY = false;

	void Update(){
		Vector3 pos = transform.position;
		if(!LockX)
			pos.x = follow.position.x + offset.x;
		else
			pos.x = offset.x;
		if(!LockY)
			pos.y = follow.position.y + offset.y;
		else
			pos.y = offset.y;

		pos.z = offset.z;

		transform.position = pos;
		
	}

}
