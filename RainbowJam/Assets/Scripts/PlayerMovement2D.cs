using UnityEngine;
using System.Collections;

public class PlayerMovement2D : MonoBehaviour 
{

	public float maxSpeed = 20.0f;				// Sets the max speed for the player
	public float rotSpeed = 180.0f;				// Sets the rotation speed for the player

	private float playerBoundsRad = 1.75f;				// To stop the player going off the screen
	private bool poweredUp = false;
	private PickUp pickUp;
	private EnemyRespawn2D enemyKill;

	// Use this for initialization
	void Start () 
	{
		pickUp = GameObject.FindGameObjectWithTag("PickUp").GetComponent<PickUp>();
		//enemyKill = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyRespawn2D>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		//ROTATE
		// Set the variable to the current rotation values
		Quaternion rot = transform.rotation;
		// Calculate the rotation of the z-axis
		float z = rot.eulerAngles.z;
		// Alter the z value with input and the max rotation variable over time
		z -= Input.GetAxis ("Horizontal") * rotSpeed * Time.deltaTime;
		// Set the rotation value by passing though all changes
		rot = Quaternion.Euler (0, 0, z);
		// Set the objects rotation to the new rotation calculated
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

		// Calculate the ratio of the main camera
		float screenRatio = (float)Screen.width / (float)Screen.height;
		//Using the ratio calculate the the camera max width
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

	void OnTriggerStay2D(Collider2D coll)
	{
		if (!poweredUp)
		{
			if(coll.tag == "PickUp")
			{
				poweredUp = true;
				Debug.Log(poweredUp);
			}
		}

		if (poweredUp) 
		{
			if(coll.tag == "Enemy")
			{
				enemyKill = coll.GetComponent<EnemyRespawn2D> ();
				enemyKill.playerHit = true;
				poweredUp = false;
			}
		}
	}
}
