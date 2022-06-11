using UnityEngine;
using System.Collections;

public class personaje : MonoBehaviour {


	private Animator animador;
	public int estado = 0;
	// Use this for initialization
	void Start () {
		animador = GetComponent<Animator> ();
	}
	void awake(){
		animador = GetComponent<Animator> ();
	}
	// Update is called once per frame
	void FixedUpdate(){

	}

	void OnMouseDown(){
		StartCoroutine(saludo ());
	}

	public IEnumerator saludo(){
		if (estado == 1) {
			animador.SetBool ("logro", true);
			Debug .Log ("antes");
			yield return new WaitForSeconds (2f);
			Debug .Log ("cambio");
			animador.SetBool ("logro", false);
			estado = 0;
		} else {
			animador.SetBool ("saludo", true);
			Debug .Log ("antes");
			yield return new WaitForSeconds (2f);
			Debug .Log ("cambio");
			animador.SetBool ("saludo", false);
			estado = 1;
		}
		
	}

	void Update () {

	}
}
