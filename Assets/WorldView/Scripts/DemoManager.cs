using UnityEngine;
using System.Collections;

public class DemoManager: MonoBehaviour
{
	public static DemoManager Instance;
	
	public GameObject[] DemoSteps;
	public GameObject	shipObject;
	public int 			DemoStepCount = 0;
	
	private int 		lastDemoCount;
	void Awake()
	{
		Instance = this;
	}	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetMouseButtonDown(0))
		{
			if(DemoStepCount == 0)
			{
				DemoStepCount = 1;
			}
		}
				
		if(lastDemoCount != DemoStepCount)
		{
			DemoSteps[lastDemoCount].SetActive(false);
			lastDemoCount = DemoStepCount;
			DemoSteps[lastDemoCount].SetActive(true);
			
			if(lastDemoCount == 3 || lastDemoCount == 5)
			{
				 shipObject.transform.parent = DemoSteps[lastDemoCount].transform;
			}
		}
	
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
