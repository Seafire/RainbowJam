using UnityEngine;
using System.Collections;

public class EnemyRespawn2D : MonoBehaviour
{
	public GameObject respawnHeader;
	private Transform[] respawnPoint;
	
	private bool treeHit;
	public bool playerHit;

	// Use this for initialization
	void Start () 
	{
		treeHit = false;
		playerHit = false;
		respawnPoint = respawnHeader.GetComponentsInChildren<Transform>();

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (treeHit == true) 
		{

			int sta = Random.Range(0, (respawnPoint.Length));
			Debug.Log (sta);
			transform.position = respawnPoint[sta].position;
			treeHit = false;
		}

		if (playerHit == true) 
		{
			
			int sta = Random.Range(0, (respawnPoint.Length));
			Debug.Log (sta);
			transform.position = respawnPoint[sta].position;
			playerHit = false;
		}

	}

	void OnTriggerStay2D(Collider2D coll)
	{	
		if (coll.tag == "Tree")
		{
			treeHit = true;
		}
	}
	
	void OnTriggerExit2D(Collider2D coll)
	{
		if (coll.tag == "Tree")
		{
			//treeHit = false;
		}
	}
}
