using UnityEngine;
using System.Collections;

public class SeatController : MonoBehaviour 
{
	public GameObject [] 	seats;
	public GameObject       camera;
	public Vector3 []		seatRotation;
	public  bool 			seatted = false;
	
	private float 			seatChangeCooldown = 1.0f;
	private bool 			seatChange = false;
	private int 			seatNum = 0;
	// Use this for initialization
	void Awake () 
	{
		seatRotation = new Vector3[seats.Length];
		seatRotation[0] = new Vector3(0, 80,0);
		seatRotation[1] = new Vector3(0,100,0);
		seatRotation[2] = new Vector3(0,250,0);
		seatRotation[3] = new Vector3(0,290,0);
		seatRotation[4] = new Vector3(0,160,0);
		seatRotation[5] = new Vector3(0,200,0);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(seatted && !seatChange)
		{
			if(Input.GetMouseButtonDown(0))
			{
				seatChange = true;
				seatNum++;
				ClampSeatNum();
				camera.transform.position = seats[seatNum].transform.position;
				camera.transform.eulerAngles = seatRotation[seatNum];
			}
		}
		
		if(seatChange && seatChangeCooldown > 0)
		{
			 seatChangeCooldown -= Time.deltaTime;
		}
		else
		{
			seatChangeCooldown = 1;
			seatChange = false;
		}
	}
	
	void ClampSeatNum()
	{
		if(seatNum > 5)
			seatNum = 0;
		if(seatNum < 0)
			seatNum = 5;
	}
}
