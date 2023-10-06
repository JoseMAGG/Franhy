using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSwitch : MonoBehaviour {

	public AudioClip[] audios;
	private AudioSource audioSource;
	private float timer;
	public Canvas canvas;
	public ParticleSystem particles;

	// Use this for initialization
	void Start () {		
		canvas.enabled = false;
		//particles.enableEmission = false;
		audioSource = GetComponent<AudioSource>();
		timer = 860f;

	}
	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate()
	{		
		if (timer > 760f) {
			timer = timer - 1f;
		} else if (timer == 760f) {
			timer = timer - 1f;
			playFirstAudio ();
		} else if (timer < 760f && timer != 0f) {
			timer = timer - 1f;
		}
		else if (timer == 0f) 
		{
			//particles.emission.enabled = tr;
			canvas.enabled = true;
		}
	}


	void OnTriggerEnter(Collider collider)
	{
		string tag = collider.tag;



		if (tag == "ActivateSound" && StaticVars.canPlayAudio == true) 
		{
			string name = collider.name;



			switch (name) 
			{
			case "AudioTrigger(ensayo)":
				Debug.Log (tag);
				if (StaticVars.i == 1)
				{
					audioSource.clip = audios [1];
					audioSource.Play ();
					Debug.Log ("primer audio");
					StaticVars.i++;
				}
				break;

			}
		
		}

	}

	public void playFirstAudio()
	{
		StaticVars.i++;
		audioSource.clip = audios [0];
		audioSource.Play ();
	}
	public void playSecondAudio()
	{
		audioSource.clip = audios [1];
		audioSource.Play ();
	}
}
