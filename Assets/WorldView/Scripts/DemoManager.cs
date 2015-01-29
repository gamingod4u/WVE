using UnityEngine;
using System.Collections;

public class DemoManager: MonoBehaviour
{
	public static DemoManager Instance;
	
	public GameObject[] DemoSteps;
	public GameObject[] starParticles;
	public GameObject	shipObject;
	public GameObject 	camera;
	public GameObject   startingPosition;	
	public int 			DemoStepCount = 0;


	private bool 		triggered = false;
	private int 		lastDemoCount;
	
	void Awake()
	{
		Instance = this;
		Input.compass.enabled = true;
		MagnetSensor.OnCardboardTrigger += new MagnetSensor.CardboardTrigger(OnTrigger);
	}

	void OnDestroy()
	{
		Input.compass.enabled = false;
		MagnetSensor.OnCardboardTrigger -= new MagnetSensor.CardboardTrigger(OnTrigger);
	}
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetMouseButtonDown(0) || triggered)
		{
			triggered = false;
			if(DemoStepCount == 0)
			{
				DemoStepCount = 1;
				camera.transform.position = startingPosition.transform.position;
			
			}
		}
		
		if(Input.touchCount > 0)
			Application.Quit();
					
		if(lastDemoCount != DemoStepCount)
		{

			DemoSteps[lastDemoCount].SetActive(false);
			lastDemoCount = DemoStepCount;
			DemoSteps[lastDemoCount].SetActive(true);
			if(DemoStepCount%2 == 0)
			{
				camera.transform.parent = null;
				starParticles[0].SetActive(true);
				starParticles[1].SetActive(true);
			}
			else
			{
				camera.transform.parent = shipObject.transform;
				starParticles[0].SetActive(false);
				starParticles[1].SetActive(false);
			}


		}
	}
	
	void OnTrigger()
	{
		triggered = true;
	}

	public void IncrementCounter()
	{
		DemoStepCount++;
		if(DemoStepCount == 7)
		{
			Application.LoadLevel(Application.loadedLevel);
		}
	}
}
