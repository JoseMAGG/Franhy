using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
	Vector2 touchDeltaPosition;
	public GameObject character;
	public float velocidadRotacion;

	// Update is called once per frame
	void Update () 
	{
        if (Input.GetMouseButtonDown(1))
        {
			if (StaticVars.action == false)
            {
				StaticVars.action = true;
            }
            else
            {
				StaticVars.action = false;
            }

        }
        
		if (StaticVars.canMove == true && StaticVars.action == true) 
		{
		//if (Input.GetMouseButton(1) || true )
	//	{
			float pointer_x = Input.GetAxis ("Mouse X");
			float pointer_y = Input.GetAxis ("Mouse Y");
			transform.Rotate (-pointer_y*velocidadRotacion, 0, 0);
			//character.transform.Rotate (pointer_y, 0, 0);
			//transform.Rotate ( 0 , pointer_x, 0);
			character.transform.Rotate (0 , pointer_x*velocidadRotacion, 0);
			/*
			if (gameObject.transform != null) 
			{
				gameObject.transform.rotation = Quaternion.Euler (0, 0, 0);
				gameObject.transform.Rotate (0, pointer_y * 2, 0);
			}
			*/

	//	}
		}



	}
}
