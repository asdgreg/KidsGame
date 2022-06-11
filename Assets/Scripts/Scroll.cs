using UnityEngine;
using System.Collections;

public class Scroll : MonoBehaviour {

	public bool IniciarEnMovimiento = false;
	public float velocidad = 0f;
	private bool enMovimiento = false;
	private float tiempoInicio = 0f;

	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter().AddObserver(this, "EmpiezaCorrer");
		NotificationCenter.DefaultCenter().AddObserver(this, "TerminarJuego");
		if (IniciarEnMovimiento) {
			EmpiezaCorrer();
		}
	}

	void TerminarJuego(){
		enMovimiento = false;
	}

	void EmpiezaCorrer(){
		enMovimiento = true;
		tiempoInicio = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if(enMovimiento){
			GetComponent<Renderer>().material.mainTextureOffset = new Vector2(((Time.time - tiempoInicio) * velocidad) % 1, 0);
		}
	}
}
