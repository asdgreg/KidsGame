using UnityEngine;
using System.Collections;

public class ScriptJugadorAtrapa : MonoBehaviour {

	//public bool tocaDerecha = false;
	//public bool tocaIzquierda = false;

	public float velocidad = 2f;
	Animator anim;
	bool izquierda = false;
	bool derecha = false;
	float y;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		NotificationCenter.DefaultCenter ().AddObserver (this, "TerminarJuego");
	}

	void TerminarJuego(){
		
	}
	
	// Update is called once per frame
	void Update () {
		Movement ();
		foreach (Touch touch in Input.touches) {
			if(touch.position.x > Screen.width/2){
				derecha = true;
			}else
				izquierda = true;
		}
	}

	void Movement(){
		if ((Input.GetKey (KeyCode.RightArrow) || derecha)) {
			anim.SetBool ("parado", false);
			anim.SetFloat ("VelX", velocidad);
			transform.Translate (Vector2.right * velocidad * Time.deltaTime);
			this.transform.localScale = new Vector3 (0.5f, 0.5f, 0.5f);
		}
		if ((Input.GetKey (KeyCode.LeftArrow) || izquierda)) {
			anim.SetBool ("parado", false);
			anim.SetFloat ("VelX", velocidad);
			transform.Translate (-(Vector2.right) * velocidad * Time.deltaTime);
			this.transform.localScale = new Vector3 (-0.5f, 0.5f, 0.5f);
		}else
		  anim.SetBool ("parado", true);

	}
}
