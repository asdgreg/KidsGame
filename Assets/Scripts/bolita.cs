using UnityEngine;
using System.Collections;

public class bolita : MonoBehaviour {
	public Rigidbody personaje;
	public int speed;
	public int salto;
	// Use this for initialization
	void Start () {
		GameObject bolita = GameObject.FindGameObjectWithTag("Player");
		personaje = bolita.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if ((Input.GetKey (KeyCode.RightArrow) || Input.GetKey(KeyCode.D))) {
			personaje.AddForce(Vector2.right * speed);
			//tocaIzquierda = false;
		}
		if ((Input.GetKey (KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))) {
			personaje.AddForce(-(Vector2.right) * speed );
			//tocaDerecha = false;
		}
		if ((Input.GetKey (KeyCode.UpArrow) || Input.GetKey(KeyCode.W))) {
			personaje.AddForce(new Vector2(0, salto));
			//tocaDerecha = false;
		}
	}



	void OnMouseDrag(){

		Vector3 move = new Vector3 (5, 0, 0);

		personaje.AddForce (move * speed);
		
	}
}
