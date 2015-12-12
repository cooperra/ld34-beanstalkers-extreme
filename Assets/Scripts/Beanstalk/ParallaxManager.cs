using UnityEngine;
using System.Collections;

public class ParallaxManager : MonoBehaviour {

	public float ScrollSpeed = .5f;
	public Transform FarBG;
	public float StartY = 5;

	public Transform[] Layers;
	public float ParallaxFactor = .5f;
	public float ParallaxStartY = 5;

	void Update(){

		FarBG.transform.localPosition = new Vector3(0, StartY + (transform.position.y / ScrollSpeed), 15);

		for(int i = 0; i < Layers.Length; i++){
			Layers[i].transform.localPosition = new Vector3(0, (transform.position.y / (ParallaxFactor * (-i - 1))), 15);
		}

	}

}
