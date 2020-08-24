using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetup : MonoBehaviour {

	public Camera mainCam;
	public BoxCollider2D topWall;
	public BoxCollider2D bottomWall;
	public BoxCollider2D leftWall;
	public BoxCollider2D rightWall;
	public BoxCollider2D block;
	public Transform Player01;


	// Update is called once per frame
	void Update () {

		topWall.size = new Vector2 (Camera.main.ScreenToWorldPoint(new Vector3 (Screen.width * 2f, 0f,0f)).x, 0.1f);
		topWall.offset = new Vector2 (0f, Camera.main.ScreenToWorldPoint (new Vector3 (0f, Screen.height, 0f)).y + 0.1f);

		bottomWall.size = new Vector2 (Camera.main.ScreenToWorldPoint(new Vector3 (Screen.width * 2f, 0f,0f)).x, 0.1f);
		bottomWall.offset = new Vector2 (0f, Camera.main.ScreenToWorldPoint (new Vector3 (0f, 0f, 0f)).y - 0.1f);

		leftWall.size = new Vector2 (0.1f,Camera.main.ScreenToWorldPoint(new Vector3 (0,Screen.height * 2f,0f)).y);
		leftWall.offset = new Vector2 (Camera.main.ScreenToWorldPoint (new Vector3 (0f, 0f, 0f)).x -0.1f,0f);

		rightWall.size = new Vector2 (0.1f,Camera.main.ScreenToWorldPoint(new Vector3 (0,Screen.height * 2f, 0f)).y);
		rightWall.offset = new Vector2 (Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width, 0f, 0f)).x + 0.1f,0f);


		rightWall.size = new Vector2(0.1f, Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height * 2f, 0f)).y);
		rightWall.offset = new Vector2(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x + 0.1f, 0f);
		//Player01.transform.position = new Vector3 (Camera.main.ScreenToWorldPoint (new Vector3 (0f, 0f, 0f)).x, Player01.transform.position.y, 0f);
	}


}
