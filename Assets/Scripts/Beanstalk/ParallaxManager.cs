using UnityEngine;
using System.Collections;

public class ParallaxManager : MonoBehaviour {

	public float ScrollSpeed = .5f;
	public Transform FarBG;
	public float StartY = 5;

	public Transform[] Layers;
	public float ParallaxFactorX = .5f;
	public float ParallaxFactorY = .5f;
	public float ParallaxStartY = 5;
	public float ParallaxStartX = 5;

	public Transform[] ForegroundLayer;
	public float ForegroundFactor = 5f;
	public float ForgroundStartY = 50.0f;

	void Update(){

		FarBG.transform.localPosition = new Vector3(0, StartY + (transform.position.y / ScrollSpeed), 15);

		for(int i = 0; i < Layers.Length; i++){
			Layers[i].transform.localPosition = new Vector3(ParallaxStartX + (transform.position.x / (ParallaxFactorX * (-i - 1))), ParallaxStartY + (transform.position.y / (ParallaxFactorY * (-i - 1))), 15);
		}

		for(int i = 0; i < ForegroundLayer.Length; i++){
			ForegroundLayer[i].transform.localPosition = new Vector3((transform.position.x / (ParallaxStartX * (-i - 1))), ForgroundStartY + (transform.position.y / (ForegroundFactor * (-i - 1))), 15);
		}

	}

}
