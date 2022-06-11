using UnityEngine;
using System.Collections;

public class Movimiento : MonoBehaviour {
	private Rigidbody rb;
	public float speed;

	private Animator animador;
	float x;
	float y;//que es z
	void Start(){
		rb = GetComponent<Rigidbody> ();
		GameObject go = GameObject.FindGameObjectWithTag ("perro");
		animador = go.GetComponent<Animator> ();
		Input.gyro.enabled = true; //Habilitar el giroscopi
	}


	void FixedUpdate(){

		Debug.Log("Rotacion: "+Input.gyro.attitude); //Rotación del giroscopio
		Debug.Log("Aceleracion: "+Input.gyro.userAcceleration); //Aceleración del dispositivo
		Debug.Log("Gravedad: "+Input.gyro.gravity); //Gravedad  del dispositivo
		x = (Input.gyro.gravity.x) + x;//si funciona
		
		y = Input.gyro.gravity.y + y ;//cambiando a acelerometro
	
		

		
	//	gameObject.transform.position = new Vector3 (x,0,y);


		Vector3 move = new Vector3 (x, 0.0f, y);


		if (x > 0.5 || y < 0.5) {
			animador.SetBool ("corriendo", true);
			rb.AddForce (move * speed);

		} else {
			animador.SetBool ("corriendo", false);
		}

	}

	public void regresar(){
		Application.LoadLevel ("Inicio");
	}
}
