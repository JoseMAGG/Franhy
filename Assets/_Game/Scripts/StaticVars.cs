using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticVars : MonoBehaviour {
	
	public static string lab; //Variable estática que guarda el nombre del laboratorio al que se quiere ingresar
	public static bool canMove;
	public static bool isTour;
	public static bool canPlayAudio;
	public static int i;
	public static bool action;

	void Start () {
		lab = "";
		canMove = false;
		isTour = false;
		canPlayAudio = false;
		i = 0;
		action = true;
	}

}
