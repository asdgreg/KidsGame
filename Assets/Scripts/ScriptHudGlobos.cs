using UnityEngine;
using System.Collections;

public class ScriptHudGlobos : MonoBehaviour {

	public TextMesh puntuacion;
	
	public GameObject cronometro;

	private int puntosA = 0;

	public AudioClip audioGameOver;
	public float volumenClip = 0.5f;

	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter().PostNotification(this, "EmpiezaGenerar");
		NotificationCenter.DefaultCenter ().AddObserver (this, "AumentarPuntuacion");
		NotificationCenter.DefaultCenter ().AddObserver (this, "TerminarJuego");
	}
	
	void AumentarPuntuacion(Notification notificacion){
		int puntos = (int)notificacion.data;
		puntosA += puntos;
		puntuacion.text = "PC " + puntosA.ToString();
	}
	
	void TerminarJuego(){
		cronometro.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
