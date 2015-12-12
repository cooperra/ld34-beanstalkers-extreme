using UnityEngine;
using System.Collections;

public class VineGenerator : MainBehaviour {

	public Transform VinePoint;
	public float Rate = .25f;
	public float DownwardSpeed = -5.0f;

	private LineRenderer _line;
	private float _lastCreated = 0.0f;
	private int _points = 0;
	private float y = 0;

	void Start(){
		_line = GetComponent<LineRenderer>();
	}

	protected override void GameUpdate(){

		y -= DownwardSpeed * Time.deltaTime;

		if(GameTime >= _lastCreated + Rate){
			_points++;
			_line.SetVertexCount(_points);
			//if(_points - 1 == 0)
			_line.SetPosition(_points - 1, VinePoint.position);
			//else
				//_line.SetPosition(_points - 1, VinePoint.position - new Vector3(0, y, 0));
			_lastCreated = GameTime;
		}

	}

}
