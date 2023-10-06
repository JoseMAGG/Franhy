using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDownList : MonoBehaviour {

	public int value = 0;

	void Start () {
		changeValue ();
	}


	public void changeValue()
	{
		
		value = this.GetComponent<Dropdown>().value; //Toma el componente del objeto al que está asociado el script, en este caso el valor de la opción seleccionada en la lista de opciones

		switch (value) { //Guarda el nombre del laboratorio escogido dependiendo del valor de la opción escogida en el momento
		case 0:
			this.GetComponent<Dropdown> ().captionText.text = "Seleccione laboratorio";
			StaticVars.lab = "Ninguno"; //Guarda el nombre en la variable estática
			break;
		case 1:
			this.GetComponent<Dropdown> ().captionText.text = "Procesos unitarios";
			StaticVars.lab = "Procesos_Unitarios"; //Guarda el nombre en la variable estática
			break;
		}
	}
}
