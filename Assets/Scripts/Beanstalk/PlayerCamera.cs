using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour {

	public Transform follow;
	public Vector3 offset;

	void Update(){
		transform.position = new Vector3(offset.x, follow.position.y + offset.y, offset.z);
	}

}
