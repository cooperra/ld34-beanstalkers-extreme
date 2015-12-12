using UnityEngine;
using System.Collections;

public class ParallaxManager : MonoBehaviour {

	public float ScrollSpeed = .5f;
	public Transform FarBG;
	public float StartY = 5;

	void Update(){

		FarBG.transform.localPosition = new Vector3(0, StartY + (transform.position.y / ScrollSpeed), 15);

	}

}
