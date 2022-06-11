using UnityEngine;
using System.Collections;

public class CronometroPinata : MonoBehaviour {

	public TextMesh cronometro;
	public float tiempo = 0.0f;
	private bool empezo = false;
	private bool termino = false;
	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter().AddObserver(this, "EmpiezaGenerar");
	}
	
	void EmpiezaGenerar(Notification notificacion){
		//Debug.Log("Entra cronometro");
		empezo = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (empezo) {
			tiempo -= Time.deltaTime;
			if (tiempo >= 0 && !termino) {
				cronometro.text = tiempo.ToString ("f0");
			} else {
				NotificationCenter.DefaultCenter ().PostNotification (this, "TerminarJuego");
				termino = true;
			}
		}
	}
}
