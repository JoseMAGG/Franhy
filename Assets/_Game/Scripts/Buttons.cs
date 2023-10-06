using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttons : MonoBehaviour {

	public void button(string action) //Evento que se ejecuta al oprimir un botón (cada uno tiene su función)
	{
		switch (action)
		{
		case "playGame":
			if (StaticVars.lab != "Ninguno") {
			SceneManager.LoadScene (StaticVars.lab); //Abre la escena del laboratorio en la variable estática
			}
			break;
		case "openCredits":
			SceneManager.LoadScene ("Credits");
			break;
		case "openSettings":
			SceneManager.LoadScene ("Settings");
			break;
		case "close":
			Application.Quit();
			break;
		case "back":
			SceneManager.LoadScene ("Menu");
			break;
		}
	}
}
