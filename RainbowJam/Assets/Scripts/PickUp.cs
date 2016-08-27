using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour 
{
	private GameObject player;
	private PlayerMovement2D playerSCR;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		playerSCR = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement2D>();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
