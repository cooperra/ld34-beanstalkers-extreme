using UnityEngine;
using System.Collections;

public class TrashWoosh : MonoBehaviour {

	// // Use this for initialization
	// void Start () {
	
	// }
	
	// // Update is called once per frame
	// void Update () {
	
	// }

	void OnTriggerEnter2D(Collider2D collider){

		if(collider.name == "Player"){
			Woosh();
		}

	}

	private void Woosh() {
		// Do audio
		Debug.Log("Woosh!");
	}
}
