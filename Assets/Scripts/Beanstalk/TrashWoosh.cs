using UnityEngine;
using System.Collections;

public class TrashWoosh : MonoBehaviour {

	// // Use this for initialization
	// void Start () {
	
	// }
	
	// // Update is called once per frame
	// void Update () {
	
	// }

	public AudioClip[] WooshSounds;
	private bool _hasWooshed = false; // Only woosh once per object

	void OnTriggerEnter2D(Collider2D collider){

		if(collider.name == "Player" && !_hasWooshed){
			Woosh();
		}

	}

	private void Woosh() {
		// Do audio
		Debug.Log("Woosh!");
		if (WooshSounds.Length == 0) {
			Debug.LogWarning("No woosh sounds given.", this);
		} else {
			int random = Random.Range(0, WooshSounds.Length);
			AudioSource.PlayClipAtPoint(WooshSounds[random], transform.position);
		}
		_hasWooshed = true;
	}
}
