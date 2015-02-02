using UnityEngine;
using System.Collections;

public class WalkingController : MonoBehaviour 
{

	#region Class Variables
	
	// public variables
	public GameObject[]		walkingWaypoints;
	public GameObject 		capsule;
	public GameObject 		exterior;
	
	private SeatController seatController;
	private Vector3         nextWaypoint = Vector3.zero;
	private float 			acceleration = 8f;
	private int 			targetedWaypoint = 0;
	
	// private variables
	
	#endregion
	// Use this for initialization
	void Start () 
	{
		seatController = capsule.GetComponent<SeatController>();
		nextWaypoint = walkingWaypoints[targetedWaypoint].transform.position;
		audio.enabled = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(targetedWaypoint <= walkingWaypoints.Length - 1)
		{
			Move();
		}
		else
		{
			seatController.seatted = true;
			exterior.SetActive(false);
			Scene1Controller.Instance.IncrementCounter();
			audio.enabled = false;
			enabled = false;
		}
	}
	
	
	void Move()
	{
		float moveSpeed = acceleration * Time.deltaTime;
		
		transform.position = Vector3.MoveTowards(transform.position, nextWaypoint, moveSpeed);
		//transform.rotation = Quaternion.Slerp(transform.rotation, 
		 //                                     Quaternion.LookRotation(walkingWaypoints[targetedWaypoint].transform.position  - transform.position), 3.0f * Time.deltaTime);
		
		if(Vector3.Distance(transform.position, nextWaypoint) < .01f)
		{
			targetedWaypoint++;
			if(targetedWaypoint <= walkingWaypoints.Length -1)
			{
				nextWaypoint = walkingWaypoints[targetedWaypoint].transform.position;
			}
		}
	}
	
}

