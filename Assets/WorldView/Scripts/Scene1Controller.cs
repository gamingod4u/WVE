using UnityEngine;
using System.Collections;

public class Scene1Controller : MonoBehaviour 
{
	#region Class Variables
	
	// public variables
	public static Scene1Controller Instance;
	
	

	public GameObject 	cameraObject;
	public GameObject   shipObject;
	public GameObject 	doorHinge;
	public GameObject   butterfly;
	public GameObject []doorObjects;
	public int 			currentSceneCount = 0;
	
	// private variables

	private WalkingController 	walkingController;
	private ShipController   	shipController;
	private Vector3	  			openDoor = new Vector3(0,90f,0);
	private Vector3				closeDoor = new Vector3(0,0,0);
	private int 				lastSceneCount = 0;	
	private bool				newCount = false;			
		
	#endregion
	
	#region Unity Functions
	void Awake(){Instance = this;}
	void Start () 
	{		
		walkingController = cameraObject.GetComponent<WalkingController>();
		shipController = shipObject.GetComponent<ShipController>();
		lastSceneCount = currentSceneCount;
		StartCoroutine("WaitforWalk", 5.0f);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(lastSceneCount != currentSceneCount)
		{
			newCount = true;
		}
		SwitchCounter();
		
		if(shipObject.transform.position.y > 120f)
		{
			DemoManager.Instance.IncrementCounter();
		}
		else
		{
			butterfly.audio.volume -= shipObject.transform.position.y *.0001f;
		}
	}
	
	#endregion
	
	#region Class Functions
	
	/// <summary>
	/// Increments the scene counter and advances the demo.
	/// </summary>
	public void IncrementCounter()
	{
		currentSceneCount++;
	}
	/// <summary>
	/// Switchs the counter with the proper actions.
	/// </summary>
	void SwitchCounter()
	{
		if(newCount)
		{
			switch(currentSceneCount)
			{
			case 0:{  break;}
				case 1:
				{

					doorHinge.transform.localEulerAngles = Vector3.Slerp(closeDoor, openDoor, 2.0f);
					walkingController.enabled = true;
					
					break;
				}
				case 2:
				{	
					cameraObject.transform.parent = shipObject.transform;
					doorHinge.transform.localEulerAngles = Vector3.Slerp(openDoor, closeDoor, 2.0f);
					doorObjects[0].SetActive(true);
					doorObjects[1].SetActive(false);
					StartCoroutine("WaitforTakeoff", 3.0f);
				 	break;
				}
				case 3:
				{
					
					break;
				}
			}
			newCount = false;
		}
	}
	
	private IEnumerator WaitforTakeoff(float time)
	{
		yield return new WaitForSeconds(time);
		shipController.enabled = true;
	}
	
	private IEnumerator WaitforWalk(float time)
	{
	Debug.Log("in");
		yield return new WaitForSeconds(time);
		Debug.Log("out");
		IncrementCounter();
	}
	#endregion
}
