using UnityEngine;
using System.Collections;

public class ActualizarPuntuacionEnPantalla : MonoBehaviour {

	public TextMesh puntos;
	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter().AddObserver(this, "TerminarJuego");
		NotificationCenter.DefaultCenter().AddObserver(this, "Puntos");
	}
	void Puntos(Notification notificacion){
		puntos.text = notificacion.data.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
