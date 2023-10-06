using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;



public class Control : MonoBehaviour {

	public Canvas[] canvas;							//Referencias a los canvas de los menús
	public Animator animatorTour;					//Referencia al animator del recorrido guiado
    public Animator animatorFranhy;
	public GameObject[] characters;
	public float velocidad;
	private float xAxis, zAxis;
	private bool isFreeTour;
	public Camera camara; 
	public Canvas[] buttons;
	public Canvas[] canvas2;
	public TextMeshProUGUI[] textLab;
	private AudioSource[] audioSourse;
	public AudioClip[] audios;

	void Start () {
		activateFranhy ();
		deactivateAllCanvas ();
		isFreeTour = false;
		audioSourse = characters [0].GetComponents<AudioSource> ();
		/*
        animatorFranhy.SetBool("Aparicion", false);
        animatorFranhy.SetBool("Desaparicion", false);
        */
    }
	

	void Update () {
	}

	public void buttonAction(string actionCanvas)			//Metodo que dice la acción que debe realizar al apretar determinado botón
	{
		
		int length1 = actionCanvas.IndexOf (',');
		string action = actionCanvas.Substring(0,length1);

		length1 = length1+1;

		int length2 = actionCanvas.Length - length1;
		string canvasString = actionCanvas.Substring (length1, length2);

		int canvas = int.Parse (canvasString);

		switch (action)
		{
		case "infoLab":
			StaticVars.canMove = false;
			activateFranhy ();
			activateCanvas (0, canvas);
			break;
		case "startTour":
			deactivateFranhy ();
			deactivateCanvas (0, canvas);
			startGuidedTour ();
			break;
		case "freeTour":
			deactivateFranhy ();
			deactivateCanvas (0, canvas);
			startFreeTour ();
			break;	
		case "rules":
			showMenu (action);
			textLab[0].text = "Oprima uno de los botones abajo para ver la normativa de uso y procedimientos de los elementos y situaciones especificados.";
			break;
		case "infoLabBack":	
			if (isFreeTour == false) {
				StaticVars.canMove = false;
			} else {
				StaticVars.canMove = true;
			}
			deactivateFranhy ();
			deactivateCanvas (0, canvas);
			audioSourse [0].Stop ();
			break;	
		case "chemical":
			audioSourse [0].clip = audios [0];
			audioSourse [0].Play ();
			textLab[0].text = "1- Leer detenidamente el rótulo del frasco antes de utilizar un determinado compuesto, en caso de cualquier duda preguntar a la persona encargada.\n\n2- Asegurarse de hacer una adecuada disposición de residuos y sobrantes según las indicaciones de la persona a cargo.\n\n3- Cuando se manipulen productos químicos, se deben usar guantes.\n\n4- No oler directamente los frascos, abanicar con la mano para acercar el olor a la nariz.\n\n5- No pipetear con la boca. Utilizar la pera o el pipeteador. \n\n6- Nunca adicione agua sobre un ácido; siempre al contrario, es decir, ácido sobre el agua. \n\n7- Los productos inflamables no deben estar cerca de fuentes de calor, como estufas, hornillos, radiadores, etc. \n\n8- Limpie inmediatamente cualquier derrame de productos o reactivos. Protéjase si es necesario para realizar la tarea.\n\n9- Rotule los implementos indicando su contenido.\n\n10- En caso de emergencia no entre en pánico, siga las instrucciones de seguridad dadas.\n\n";
			break;
		case "rulesLab":
			audioSourse [0].clip = audios [1];
			audioSourse [0].Play ();
			textLab[0].text = "1- Utilizar la ropa y equipo de protección personal acordes a la actividad práctica. Es recomendable vestir ropa sencilla, que proteja la mayor parte del cuerpo y preferentemente de algodón.\n\n2- Usar zapatos cerrados, con suelas gruesas y sin tacones o plataformas.\n\n3- Se debe llevar el cabello siempre recogido, y no se permitirá el uso de pulseras, collares colgantes o bufandas.\n\n4- No introducir ni consumir alimentos o bebidas en el laboratorio. No fumar.\n\n5- Es importante y obligatorio el uso de la BATA de laboratorio.\n\n6- Para manipular sustancias químicas se deben usar guantes de látex o nitrilo.\n\n7- Algunos equipos manejan altas temperaturas, para su manipulación por favor haga el uso de guantes de protección y gafas de seguridad.\n\n8- Se debe de leer la etiqueta y consultar la ficha de datos de seguridad de los reactivos químicos antes de su utilización.\n\n9- No debe nunca utilizar ningún reactivo al cual le falte la etiqueta del frasco. Todos los envases que contengan reactivo químico deben estar debidamente identificados. \n\n10- Operar un instrumento, aparato o planta piloto solamente cuando se sabe manipular, de otra manera solicitar la ayuda del profesor para adquirir la destreza necesaria. Una vez concluido el uso de un aparato, instrumento o planta piloto, seguir el procedimiento adecuado para apagarlo o desconectarlo.\n\n11- Todo material de vidrio que esté roto debe ser desechado y notificado al profesor. \n\n12- Al concluir una práctica, verificar que todas las tomas de agua, gas, aire, eléctricas u otras en el lugar de trabajo estén bien cerradas y/o desconectadas.\n\n13- Dejar limpias y secas las mesas de trabajo y el piso del laboratorio.\n\n14- Cualquier incidente o accidente ocurrido notificarlo inmediatamente al profesor.";
			break;		
		case "fire":
			audioSourse [0].clip = audios [2];
			audioSourse [0].Play ();
			textLab[0].text = "- En caso de que se produzca un incendio, lo primero que debe hacerse es informar a los demás y pedir ayuda. Si el incendio es pequeño se puede intentar apagarlo usando las medidas de protección disponibles (extinguidores, arena, etc.) En los equipos eléctricos no se puede usar agua. Recuerde que el chorro del extintor se debe dirigir a la base de la llama.\n\n- Si corre el riesgo de quedar atrapado o alcanzado por las llamas o el humo, abandone el Laboratorio: su integridad es más importante que la de los equipos. Al evacuar el Laboratorio hágalo en orden, sin pánico. En caso de que haya gran cantidad de humo, inclínese, pues el humo tiende a ascender. Si debe pasar por zonas de intenso calor, cúbrase la cabeza con una tela preferentemente mojada. \n\n- Si usted estaba trabajando con materiales peligrosos (tóxicos o corrosivos), reporte esto al personal de apoyo antes de alejarse del Laboratorio.\n\n- Asegúrese de conocer la ubicación de los extintores, las duchas de seguridad y la ruta de evacuación. ";
			break;
		case "infoLabBack2":
			showMenu (action);
			textLab[0].text = "Oprima uno de los botones abajo para ver la normativa de uso y procedimientos de los elementos y situaciones especificados.";
			audioSourse [0].Stop ();
			break;


		case "infoMachine":
			StaticVars.canMove = false;
			activateFranhy ();
			activateCanvas (0, canvas);
			if (canvas == 2) {
				textLab [1].text = "Compuesto por una consola de control que cuenta con un interruptor de encendido, dos visores (temperatura y vatios), dos reguladores (potencia y velocidad del ventilador), dos conexiones (alimentación de potencia a las diferentes superficies estudiadas y otra para la termocupla ubicada en la parte posterior de la placa que permite determinar la temperatura de la superficial de la placa), ducto rectangular (Compuesto de dos ganchos ubicados lateralmente para sujetar la placa al ducto, dos puntos para censar la temperatura: uno antes y tres después de la placa y tres puntos para censar el perfil de temperatura de la superficie: el primero a 8 mm el segundo a 35 mm y el tercero a 62 mm de la superficie) y placas (plana, aletas extendidas cilíndricas y trapezoidales).";
			}
			break;			
		case "infoMachineBack":			
			StaticVars.canMove = true;		
			deactivateFranhy ();
			deactivateCanvas (0,canvas);
			audioSourse [0].Stop ();
			break;
		case "usesMachine0":
			audioSourse [0].clip = audios [3];
			audioSourse [0].Play ();
			textLab [1].text = "Convección libre: Es un tipo de transferencia de calor en el que no se involucran corrientes de fluidos externas a las creadas naturalmente. El principio de la convección libre se da por una diferencia de temperaturas que se da cuando una fuente de calor calienta un fluido estático, al aumentar temperatura se disminuye la densidad y el fluido más caliente es menos denso se aleja mientras el más denso y con menor temperatura se acerca a la fuente de calor generando un movimiento de circulación. Cuando el fluido calentado se aleja de la fuente de calor lo hace transportando energía por lo cual se genera una manera muy eficiente de transferencia de calor. La convección natural sólo es posible cuando hay una fuerza como la gravitatoria que atrae el fluido a la fuente de calor.\n\nConvección forzada: Es cuando se parte de un fluido en movimiento en vez de uno estático y el movimiento es generado por medio de algún mecanismo como ventilador, bomba o el viento (corrientes externas a las creadas naturalmente por la diferencia de temperaturas) y se genera una circulación del fluido desde el principio mejorando la transferencia de calor considerablemente. La convección forzada es muy usada en sistemas de refrigeración ya que en ocasiones la convección libre no es posible por cuestiones geométricas o físicas.\n";
			break;
		case "implementsMachine0":
			audioSourse [0].clip = audios [4];
			audioSourse [0].Play ();
			textLab[1].text = "1- Bata de laboratorio\n\n2- Zapatos tapados\n\n3- Guantes de cuero";
			break;
		case "conditionsMachine0":
			audioSourse [0].clip = audios [5];
			audioSourse [0].Play ();
			textLab[1].text = "1- Verificar que la temperatura no exceda los 100 grados centígrados, en caso que se supere esta temperatura, disminuir la potencias.\n\n2- No asentar lo módulos sobre los terminales de los sensores de temperatura\n\n3- Tener la precaución de no quemarse con los modelos calientes, si es necesario utilizar guantes de cuero.\n";
			break;


		case "exit":
			Application.Quit();
			break;
		case "backMenu":
			StaticVars.canMove = false;
			SceneManager.LoadScene ("Menu");
			break;
		


		}
	}

	public void startGuidedTour()
	{		
		StaticVars.canPlayAudio = true;
		StaticVars.isTour = true;
		StaticVars.canMove = false;
		StaticVars.action = true;
		StaticVars.i = 1;

		Vector3 position = new Vector3 (-18.195f, 1.179f, 6.306f);
		Quaternion rotation = new Quaternion (0f, 180f, 0f, 0f);
		characters [0].transform.SetPositionAndRotation (position, rotation);
		rotation = new Quaternion (0f, 0f, 0f, 0f);
		camara.transform.rotation = rotation;

		Debug.Log (StaticVars.canPlayAudio);

		animatorTour.SetBool ("startTour", true);

		deactivateButtons ();
	}

	public void startFreeTour()
	{
		StaticVars.canPlayAudio = false;
		StaticVars.i = 0;
		StaticVars.isTour = false;	
		StaticVars.canMove = true;
		isFreeTour = true;


		Debug.Log (StaticVars.canPlayAudio);

		activateButtons ();
	}

	void OnTriggerEnter(Collider tag)
	{
		if (tag.tag == "TurnOffAnimations") 
		{
			animatorTour.SetBool ("startTour", false);
		}
	}

	public void activateCanvas(int canvas1, int canvas2)
	{
		canvas [canvas1].enabled = true;
		canvas [canvas2].enabled = true;	
	}

	public void deactivateCanvas(int canvas1, int canvas2)
	{
		canvas [canvas1].enabled = false;
		canvas [canvas2].enabled = false;	
	}

	public void activateFranhy()
	{
		animatorFranhy.SetBool ("Aparicion", true);                
		animatorFranhy.SetBool ("Desaparicion", false);		
	}

	public void deactivateFranhy()
	{
		animatorFranhy.SetBool("Aparicion", false);
		animatorFranhy.SetBool("Desaparicion", true);
	}

	public void deactivateAllCanvas()
	{
		//Se deshabilitan los canvas que no se necesitan al inicio
		canvas [1].enabled = false;
		canvas [2].enabled = false;
		canvas [3].enabled = false;
		canvas [4].enabled = false;
		canvas [5].enabled = false;
		canvas [6].enabled = false;
		canvas [7].enabled = false;
		canvas [8].enabled = false;
		canvas [9].enabled = false;
		canvas [10].enabled = false;
		canvas [11].enabled = false;
		canvas [12].enabled = false;
		canvas [13].enabled = false;
		canvas [14].enabled = false;
		canvas [15].enabled = false;

		canvas2 [0].enabled = false;

	}

	public void deactivateButtons()
	{
		buttons [0].enabled = false;
		buttons [1].enabled = false;
		buttons [2].enabled = false;
		buttons [3].enabled = false;
		buttons [4].enabled = false;
		buttons [5].enabled = false;
		buttons [6].enabled = false;
		buttons [7].enabled = false;
		buttons [8].enabled = false;
		buttons [9].enabled = false;
		buttons [10].enabled = false;
		buttons [11].enabled = false;
		buttons [12].enabled = false;
		buttons [13].enabled = false;
        /*
		buttonsParticles [0].emission.enabled = false;
		buttonsParticles [1].emission.enabled = false;
		buttonsParticles [2].emission.enabled = false;
		buttonsParticles [3].emission.enabled = false;
		buttonsParticles [4].emission.enabled = false;
		buttonsParticles [5].emission.enabled = false;
		buttonsParticles [6].emission.enabled = false;
		buttonsParticles [7].emission.enabled = false;
		buttonsParticles [8].emission.enabled = false;
		buttonsParticles [9].emission.enabled = false;
		buttonsParticles [10].emission.enabled = false;
		buttonsParticles [11].emission.enabled = false;
		buttonsParticles [12].emission.enabled = false;
		buttonsParticles [13].emission.enabled = false;
        */
	}

	public void activateButtons()
	{
		buttons [0].enabled = true;
		buttons [1].enabled = true;
		buttons [2].enabled = true;
		buttons [3].enabled = true;
		buttons [4].enabled = true;
		buttons [5].enabled = true;
		buttons [6].enabled = true;
		buttons [7].enabled = true;
		buttons [8].enabled = true;
		buttons [9].enabled = true;
		buttons [10].enabled = true;
		buttons [11].enabled = true;
		buttons [12].enabled = true;
		buttons [13].enabled = true;
        /*
		buttonsParticles [0].emission.enabled = true;
		buttonsParticles [1].emission.enabled = true;
		buttonsParticles [2].emission.enabled = true;
		buttonsParticles [3].emission.enabled = true;
		buttonsParticles [4].emission.enabled = true;
		buttonsParticles [5].emission.enabled = true;
		buttonsParticles [6].emission.enabled = true;
		buttonsParticles [7].emission.enabled = true;
		buttonsParticles [8].emission.enabled = true;
		buttonsParticles [9].emission.enabled = true;
		buttonsParticles [10].emission.enabled = true;
		buttonsParticles [11].emission.enabled = true;
		buttonsParticles [12].emission.enabled = true;
		buttonsParticles [13].emission.enabled = true;
        */

	}

	public void showMenu(string button)
	{
		switch (button) 
		{
		case "rules":			
			canvas [1].enabled = false;
			canvas2 [0].enabled = true;
			break;
		case "infoLabBack2":
			canvas [1].enabled = true;
			canvas2 [0].enabled = false;
			break;

		}
	}
}
