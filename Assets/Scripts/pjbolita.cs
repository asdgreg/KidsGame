using UnityEngine;
using System.Collections;

public class pjbolita : MonoBehaviour {
	float x;
	float y;
	float z;
	public Vector3 asd;
	public int speed;
	public int salto;
	public Rigidbody2D personaje;
	public Vector2 puntotocado;
	public bool presion = false;
	string nombre;
	// Use this for initialization
	void Start () {
		GameObject bolita = GameObject.FindGameObjectWithTag("Player");
		personaje = bolita.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnMouseDrag(){
		puntotocado.x =Input.mousePosition.x;
		puntotocado.y = Input.mousePosition.y;
		presion = true;
	}
	public void movizquierda(){
//		int ayuda = 0;
//		while (true) {
//			personaje.AddForce (-(Vector2.right) * speed);
//			print ("mover izquierda");
//			ayuda++;
//			if(ayuda >= 30){break;}
//		}
	}
	public void movderecha(){
//		int ayuda = 0;
//	//	while(Input.anyKeyDown){
//		personaje.AddForce(-(Vector2.right) * speed );
//		print("mover derecha");
//			ayuda++;
//		//	if(ayuda >= 30){break;}
//
//		//}
	}

}
