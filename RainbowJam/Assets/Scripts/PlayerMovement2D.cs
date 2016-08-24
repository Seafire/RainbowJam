using UnityEngine;
using System.Collections;

public class PlayerMovement2D : MonoBehaviour 
{

	float maxSpeed = 20.0f;
	float rotSpeed = 180.0f;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Rotate the Ship
		Quaternion rot = transform.rotation;
		float z = rot.eulerAngles.z;
		z -= Input.GetAxis ("Horizontal") * rotSpeed * Time.deltaTime;
		rot = Quaternion.Euler (0, 0, z);
		transform.rotation = rot;

		//Move the Ship
		Vector3 pos = transform.position;
		pos.y += Input.GetAxis ("Vertical") * maxSpeed * Time.deltaTime;
		transform.position = pos;
	}
}
