using UnityEngine;
using System.Collections;

public class WorldRotate : MonoBehaviour 
{

	
	// Update is called once per frame
	void Update () 
	{
		float newRotationY = this.transform.localEulerAngles.y + (1*Time.deltaTime);
		float newRotationX = this.transform.localEulerAngles.x + (.5f*Time.deltaTime);
		this.transform.localEulerAngles = new Vector3(newRotationX, newRotationY, 0);
	}
}
