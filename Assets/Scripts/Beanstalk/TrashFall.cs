using UnityEngine;
using System.Collections;

public class TrashFall : MonoBehaviour {

	public float FallSpeed = 5.0f;

	void Update () {
	
		transform.position = new Vector2(transform.position.x, transform.position.y - (FallSpeed * Time.deltaTime));

	}

	void OnTriggerEnter2D(Collider2D collider){

		if(collider.name == "Player"){
			collider.GetComponent<PlayerMovement>().OutOfControl(transform);
		}

	}

}
