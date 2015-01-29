using UnityEngine;
using System.Collections;

public class Flythrough : MonoBehaviour 
{
	#region Class Variables
	
	// public variables
	public Transform []		Waypoints;
	private Vector3         nextWaypoint = Vector3.zero;
	private float 			acceleration = 35f;
	private int 			targetedWaypoint = 0;
	
	// private variables
	
	#endregion
	// Use this for initialization
	void Start () 
	{
	 	nextWaypoint = Waypoints[targetedWaypoint].transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(targetedWaypoint <= Waypoints.Length - 1)
		{
			Move();
		}
		else
		{
			Scene1Controller.Instance.IncrementCounter();
			audio.enabled = false;
			enabled = false;
		}
	}
	
	
	void Move()
	{
		float moveSpeed = acceleration * Time.deltaTime;
		
		transform.position = Vector3.MoveTowards(transform.position, nextWaypoint, moveSpeed);
		transform.rotation = Quaternion.Slerp(transform.rotation, 
		                                      Quaternion.LookRotation(Waypoints[targetedWaypoint].transform.position  - transform.position), 3.0f * Time.deltaTime);
		
		if(Vector3.Distance(transform.position, nextWaypoint) < .01f)
		{
			targetedWaypoint++;
			if(targetedWaypoint <= Waypoints.Length -1)
			{
				nextWaypoint = Waypoints[targetedWaypoint].transform.position;
			}
		}
	}
	
}
