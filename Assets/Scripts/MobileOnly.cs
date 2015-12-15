using UnityEngine;
using System.Collections;

public class MobileOnly : MonoBehaviour {

	// Use this for initialization
	void Start () {

		if(Application.isMobilePlatform)
			gameObject.SetActive(false);
	
	}
}
