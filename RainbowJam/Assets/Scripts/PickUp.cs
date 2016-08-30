using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour 
{
	private EnemyRespawn2D enemyKill;
	
	protected PlayerMovement2D playerPower;
	
	public GameObject respawnHeader;
	private Transform[] respawnPoint;
	
	[HideInInspector] public bool pickUpUsed;
	protected bool pickUpDropped;
	
	// Use this for initialization
	void Start () 
	{
		
		pickUpUsed = false;
		pickUpDropped = false;
		respawnPoint = respawnHeader.GetComponentsInChildren<Transform>();
		playerPower = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement2D>();
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (pickUpUsed == true) 
		{
			
			int sta = Random.Range(0, (respawnPoint.Length));
			Debug.Log (sta);
			transform.position = respawnPoint[sta].position;
			pickUpUsed = false;
		}
		
		if (pickUpDropped == true) 
		{
			
			int sta = Random.Range(0, (respawnPoint.Length));
			Debug.Log (sta);
			transform.position = respawnPoint[sta].position;
			pickUpDropped = false;
		}
		
	}

}
