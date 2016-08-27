using UnityEngine;
using System.Collections;

public class EnemyDirection2D : MonoBehaviour 
{

	private Transform treePos;

	public float rotSpeed = 180.0f;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (treePos == null) 
		{
			GameObject tree = GameObject.Find ("IdentaTree");

			if(tree != null)
			{
				treePos = tree.transform;
			}
		}

		//if (treePos = null)
		//	return;				// Try again


		// We are now sure the tree is in the scene

		Vector3 dir = treePos.position - transform.position;
		dir.Normalize ();
		float zAngle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg - 90;

		transform.rotation = Quaternion.Euler (0, 0, zAngle);
	}
}
