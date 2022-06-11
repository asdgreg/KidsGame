using UnityEngine;
using System.Collections;

public class PuntuacionFinalAtrapa : MonoBehaviour {

	public TextMesh puntos;
	public TextMesh puntuacion;

	// Use this for initialization
	void Start () {
		puntuacion.text = puntos.text.Substring (2);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
