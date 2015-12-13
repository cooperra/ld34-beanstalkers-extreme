using UnityEngine;
using System.Collections;

public class FallingPlayer : MonoBehaviour {

	public float FallSpeed = 2.0f;

	void Update(){

		transform.position = new Vector3(0, transform.position.y - (FallSpeed * Time.deltaTime), 0);

	}

}
