using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
 {
	public AudioClip []  playerClips;
	public AudioClip []  sfxClips;
	
	public GameObject	 SoundPlayer;
	
	
	private static AudioManager instance;

	public static AudioManager getInstance()
	{
		return instance;
	}	

	void Awake()
	{
		if(instance != null)
		{
			Destroy(gameObject);
		}
		instance = this; 
	}	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	public GameObject CreateSoundObject(Transform position, bool loop, bool playerSound, float volume, int clipCount)
	{
		GameObject soundPlayer = Instantiate(SoundPlayer, position.position, position.rotation) as GameObject;
		soundPlayer.audio.loop = loop;
		soundPlayer.audio.volume = volume;
		
		return soundPlayer;
	}
	
	
}
