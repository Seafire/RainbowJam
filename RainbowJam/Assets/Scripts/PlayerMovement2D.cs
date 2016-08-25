using UnityEngine;
using System.Collections;

public class PlayerMovement2D : MonoBehaviour 
{

	public float maxSpeed = 20.0f;				// Sets the max speed for the player
	public float rotSpeed = 180.0f;				// Sets the rotation speed for the player

	float playerBoundsRad = 1.5f;				// To stop the player going off the screen

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Rotate the player
		Quaternion rot = transform.rotation;
		float z = rot.eulerAngles.z;
		z -= Input.GetAxis ("Horizontal") * rotSpeed * Time.deltaTime;
		rot = Quaternion.Euler (0, 0, z);
		transform.rotation = rot;

		//Move the player
		Vector3 pos = transform.position;
		Vector3 velocity = new Vector3(0, Input.GetAxis ("Vertical") * maxSpeed * Time.deltaTime, 0);
		pos += rot * velocity;

		if (pos.y + playerBoundsRad > Camera.main.orthographicSize) 
		{
			pos.y = Camera.main.orthographicSize - playerBoundsRad;
		}
		if (pos.y - playerBoundsRad < -Camera.main.orthographicSize) 
		{
			pos.y = -Camera.main.orthographicSize + playerBoundsRad;
		}

		float screenRatio = (float)Screen.width / (float)Screen.height;
		Debug.Log (screenRatio);
		float cameraWidth = Camera.main.orthographicSize * screenRatio;

		if (pos.x + playerBoundsRad > cameraWidth) 
		{
			pos.x = cameraWidth - playerBoundsRad;
		}
		if (pos.x - playerBoundsRad < -cameraWidth) 
		{
			pos.x = -cameraWidth + playerBoundsRad;
		}

		transform.position = pos;
	}
}
