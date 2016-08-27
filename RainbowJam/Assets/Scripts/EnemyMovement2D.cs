using UnityEngine;
using System.Collections;

public class EnemyMovement2D : MonoBehaviour 
{
	public float maxSpeed = 2.0f;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		//Move the enemy
		Vector3 pos = transform.position;
		Vector3 velocity = new Vector3(0, maxSpeed * Time.deltaTime, 0);
		pos += transform.rotation * velocity;

		transform.position = pos;
	}
}
