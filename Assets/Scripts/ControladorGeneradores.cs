using UnityEngine;
using System.Collections;

public class ControladorGeneradores : MonoBehaviour {

	public GameObject[] generadores;
	bool generadoresIniciales = true;
	bool hayGeneradores = true;

	bool seguir = true;

	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter().AddObserver(this, "EmpiezaGenerar");
	}

	void EmpiezaGenerar(Notification notificacion){
		if (generadoresIniciales) {
			GenerarIniciales();
			generadoresIniciales = false;
		}
	}

	void GenerarIniciales(){
		for (int i = 0; i<2; i++) {
			int rand = Random.Range (0, generadores.Length);
			generadores[rand].gameObject.SetActive(true);
			generadores[rand].gameObject.tag = "Generando";
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (!generadoresIniciales && hayGeneradores) {
			//Invoke("ActivarOtroGenerador", 3.0f);
		}
	}

	void ActivarOtroGenerador(){
		int contadorIntentos = 0;
		while (seguir) {
			int rand = Random.Range (0, generadores.Length);
			if(generadores[rand].gameObject.tag == "NoGenerando"){
				generadores[rand].gameObject.SetActive(true);
				generadores[rand].gameObject.tag = "Generando";
				Debug.Log("Activando generador " + rand.ToString());
			}
			contadorIntentos++;
			Debug.Log("contadorIntentos = " + contadorIntentos.ToString());
			if(contadorIntentos >= 8){
				Debug.Log("Ya no seguiran activando");
				seguir = false;
				hayGeneradores = false;
			}
		}
	}
}
