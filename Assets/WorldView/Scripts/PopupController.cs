using UnityEngine;
using System.Collections;

public class PopupController : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
		StartCoroutine("WaitForPopup", 10.0f);
	}
		
	private IEnumerator WaitForPopup(float time)
	{
		yield return new WaitForSeconds(time);
		DemoManager.Instance.IncrementCounter();
	}
}
