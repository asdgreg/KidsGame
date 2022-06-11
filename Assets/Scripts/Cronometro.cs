using UnityEngine;
using System.Collections;

public class Cronometro : MonoBehaviour {

	public TextMesh cronometro;
	public float tiempo = 0.0f;
	public bool termino = false;
	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter().PostNotification(this, "EmpiezaGenerar");
	}
	
	// Update is called once per frame
	void Update () {
		tiempo -= Time.deltaTime;
		if (tiempo >= 0 && !termino) {
			cronometro.text = tiempo.ToString ("f0");
		} else {
			
			NotificationCenter.DefaultCenter().PostNotification(this, "TerminarJuego");
			termino = true;;
		}

	}
}
