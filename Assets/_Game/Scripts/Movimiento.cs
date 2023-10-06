using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour 
{
	private Transform freeTransform;
	public float velocidad;
	private float xAxis, zAxis;
	private Animator animator;
	Vector3 position;




	void Start ()
	{
		freeTransform = GetComponent <Transform> ();
		animator = GetComponent <Animator> ();
		position = new Vector3 (-18.195f, 1.179f, 6.306f);
	}

	// Update is called once per frame

	void Update () 

	{
		if (StaticVars.canMove == true) 
		{
			xAxis = Input.GetAxis ("Horizontal");
			zAxis = Input.GetAxis ("Vertical");
			Vector3 caminar = new Vector3 (xAxis, 0, zAxis);
			freeTransform.Translate (caminar * velocidad * Time.deltaTime);
		} 
		if (StaticVars.isTour == true) 
		{
			animator.enabled = true;

		} 
		else 
		{
			animator.enabled = false;
		}
		if (freeTransform.position == position) {
			animator.enabled = false;
		}



		//Opcional
		/*
		if (Input.GetKey (KeyCode.W)) 
		{
			freeTransform.Translate (new Vector3 (0, 0, -velocidad)*Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.S)) 
		{
			freeTransform.Translate (new Vector3 (0, 0, velocidad)*Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.A)) 
		{
			freeTransform.Translate (new Vector3 (velocidad, 0,0)*Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.D)) 
		{
			freeTransform.Translate (new Vector3 ( -velocidad, 0,0)*Time.deltaTime);
		}
		*/
	}
}
