using UnityEngine;
using System.Collections;

public class TrashFall : MonoBehaviour {

	public float FallSpeed = 5.0f;

	private float _spinDirection = 0;

	void Start(){

		float random = Random.Range(-2.0f,2.0f);
		_spinDirection = random;

	}

	void Update () {
	
		transform.position = new Vector2(transform.position.x, transform.position.y - (FallSpeed * Time.deltaTime));
		transform.Rotate(new Vector3(0,0,(50 * _spinDirection) * Time.deltaTime));
		if (transform.position.y < 0) {
		    // Remove self on reaching the ground
		    Destroy(this.gameObject);
		}

	}

	void OnTriggerEnter2D(Collider2D collider){

		if(collider.name == "Player"){
			collider.GetComponent<PlayerMovement>().OutOfControl(transform);
		}

	}

}
