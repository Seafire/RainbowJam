using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour 
{
	
	//private bool poweredUp = false;
	private PickUp pickUp;
	private EnemyRespawn2D enemyKill;

	protected PlayerMovement2D playerPower;
	
	public GameObject respawnHeader;
	private Transform[] respawnPoint;

	[HideInInspector] public bool powerUpUsed;
	protected bool powerUpDropped;

	// Use this for initialization
	void Start () 
	{

		powerUpUsed = false;
		powerUpDropped = false;
		respawnPoint = respawnHeader.GetComponentsInChildren<Transform>();
		playerPower = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement2D>();
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (powerUpUsed == true) 
		{
			
			int sta = Random.Range(0, (respawnPoint.Length));
			Debug.Log (sta);
			transform.position = respawnPoint[sta].position;
			powerUpUsed = false;
		}
		
		if (powerUpDropped == true) 
		{
			
			int sta = Random.Range(0, (respawnPoint.Length));
			Debug.Log (sta);
			transform.position = respawnPoint[sta].position;
			powerUpDropped = false;
		}
		
	}

	void OnTriggerStay2D(Collider2D coll)
	{	

	}


}
