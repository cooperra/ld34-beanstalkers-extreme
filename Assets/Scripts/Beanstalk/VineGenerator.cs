using UnityEngine;
using System.Collections;

public class VineGenerator : MainBehaviour {

	public Transform VinePoint;
	public float Rate = .25f;
	public float DownwardSpeed = -5.0f;
	public float MaterialGrowthRate = .05f;

	private LineRenderer _line;
	private float _lastCreated = 0.0f;
	private int _points = 0;

	void Start(){
		_line = GetComponent<LineRenderer>();
	}

	protected override void GameUpdate(){

		if(GameTime >= _lastCreated + Rate){
			_points++;
			_line.SetVertexCount(_points);
			//if(_points - 1 == 0)
			
			//else
				//_line.SetPosition(_points - 1, VinePoint.position - new Vector3(0, y, 0));
			_lastCreated = GameTime;
		}
		_line.SetPosition(_points - 1, VinePoint.position);
		GetComponent<LineRenderer>().materials[0].mainTextureScale = new Vector2(GetComponent<LineRenderer>().materials[0].mainTextureScale.x + (MaterialGrowthRate * Time.deltaTime), GetComponent<LineRenderer>().materials[0].mainTextureScale.y);

	}

}
