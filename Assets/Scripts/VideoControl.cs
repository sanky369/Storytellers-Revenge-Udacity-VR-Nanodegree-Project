using System.Collections; 
using System.Collections.Generic; 
using UnityEngine;
using UnityEngine.Video;

public class VideoControl : MonoBehaviour {

	public GameObject videosphere;
	//public GameObject pointerObj;
	private UnityEngine.Video.VideoPlayer videoPlayer;
	private bool videoPlaying;
	public AudioSource videoAudioSource;
	public GameObject bells;
	//private GvrReticlePointer pointer;

	//[SerializeField] 
	//private AudioSource audioSource; 

	void Start () { 
		videoPlayer = videosphere.GetComponent<VideoPlayer> ();
		//pointer = pointerObj.GetComponent<GvrReticlePointer> ();
//		if (videoPlayer.clip != null) { 
//			videoPlayer.EnableAudioTrack (0, true); 
//			videoPlayer.SetTargetAudioSource(0, audioSource); 
//		} 
	} 

	//Check if input keys have been pressed and call methods accordingly.
	public void Play(){
		if (!videoPlaying) {
			videoPlayer.Play ();
			videoAudioSource.Play();
		}
	}

	public void Pause(){
		if (videoPlaying) {
			videoPlayer.Pause ();
			videoAudioSource.Pause();
		}
	}

	public void Restart(){ 
		videoPlayer.frame = 0;
	}

	public void StopBellPlaying ()
	{
		bells.GetComponent<AudioSource>().Stop();
	}

	public void ForwardTemple(){
		StartCoroutine(MoveToTemple ());
	}

	IEnumerator MoveToTemple ()
	{
		videoPlayer.frame = 2397;
		videoPlayer.Prepare();
		videoAudioSource.time = 79.98f;
		bells.GetComponent<AudioSource>().Play();
		yield return null;
	}

	public void ForwardStreets(){
		StartCoroutine(MoveToStreets ());
	}

	IEnumerator MoveToStreets ()
	{
		StopBellPlaying ();
		videoPlayer.frame = 360;
		videoPlayer.Prepare();
		videoAudioSource.time = 12.012f;
		yield return null;
	}

	public void ForwardTaj(){
		StartCoroutine(MoveToTaj ());
	}

	IEnumerator MoveToTaj ()
	{
		StopBellPlaying ();
		videoPlayer.frame = 3177;
		videoPlayer.Prepare();
		videoAudioSource.time = 106.01f;
		yield return null;
	}

	void Update ()
	{ 
		
		if (videoPlayer.isPlaying) {
			videoPlaying = true;
		}
		if (!videoPlayer.isPlaying) {
			videoPlaying = false;
		}

		//Play or pause the video. 
//		if (Input.GetKeyDown ("space")) { 
//			if (videoPlayer.isPlaying) 
//				videoPlayer.Pause (); 
//			else 
//				videoPlayer.Play(); 
//			audioSource.Play(); 
//		} 
	} 
}
