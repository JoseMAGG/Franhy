using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionsInAnimations : MonoBehaviour {
	
	private Animator animator;
	public Animator[] door;
	string name;

	void Start ()
	{
		animator = GetComponent <Animator> ();
		name = animator.name;

	}

	public void turnOffAnimator()
	{
		animator.enabled = false;
	}

	public void openDoor ()
	{
		Debug.Log (name);
		if (name == "Puerta (4)") 
		{
			door [0].SetBool ("openDoor", false);
		} 
		else 
		{
			door [0].SetBool ("openDoor", false);
			door [1].SetBool ("openDoor", false);	
		}
			
	}
}
