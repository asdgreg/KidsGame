using UnityEngine;
using System.Collections;

public class GeneradorGlobos : MonoBehaviour {

	public GameObject[] objetos;
	public float tiempoMin = 1f;
	public float tiempoMax = 1.5f;
	private bool seguir = true;
	// Use this for initialization
	void Start () {
		Generar ();
		NotificationCenter.DefaultCenter ().AddObserver (this, "TerminarJuego");
	}
	void TerminarJuego(){
		seguir = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Generar(){
		if (seguir) {
			Instantiate(objetos[Random.Range(0,objetos.Length)], transform.position, Quaternion.identity);
			Invoke("Generar", Random.Range(tiempoMin, tiempoMax));
		}
	}
}
