using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour {

	public Animator[] animators;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider collider)
	{
		string tag = collider.tag;

		if (tag == "OpenDoor") {
			string name = collider.name;

			switch (name) {
			case "PuertaPrimaria":
					animators [0].SetBool ("openDoor", true);
					animators[1].SetBool ("openDoor", true); 
				break;
			case "PuertaSecundaria":				
					animators [2].SetBool ("openDoor", true);
					animators[3].SetBool ("openDoor", true); 			
				break;
			case "PuertaSalon":	
				animators [4].SetBool ("openDoor", true);		
				break;

			}

		}
	}

}
