using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		StartCoroutine("WaitForView", 40.0f);
	}
	
	private IEnumerator WaitForView(float time)
	{
		yield return new WaitForSeconds(time);
		DemoManager.Instance.IncrementCounter();
	}
}
