using UnityEngine;
using System.Collections;

public class BlinkScript : MonoBehaviour 
{
	public GameObject[]  ItemsToBlink;
	private bool		 blinking = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(ItemsToBlink.Length > 0)
		{
			foreach(GameObject items in ItemsToBlink)
			{
			 	if(!blinking)
			 	{
					StartCoroutine ("BlinkOff", .75f);
				}
				else
				{
				    StartCoroutine("BlinkOn", .75f);
				}	
			}
			
			
		}
	}
	
	private IEnumerator BlinkOff(float time)
	{
	  yield return new WaitForSeconds(time);
	  foreach(GameObject items in ItemsToBlink)
	  {
	  	items.SetActive(false);
	  	blinking = true;
	  }
	}
	
	private IEnumerator BlinkOn(float time)
	{
		yield return new WaitForSeconds(time);
		foreach(GameObject item in ItemsToBlink)
		{
			item.SetActive(true);
			blinking = false;
		}
	}
}
