using UnityEngine;
using System.Collections;

public class ScriptPinata : MonoBehaviour {

	private Animator anim;
	bool terminoanimacion = false;
	void Awake(){
		anim = GetComponent<Animator> ();
	}
	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter().AddObserver(this, "GolpeoPinata");
		NotificationCenter.DefaultCenter().AddObserver(this, "TerminarJuego");
	}

	void GolpeoPinata(Notification notificacion){
		anim.SetBool ("golpe", true);
		Invoke ("NoGolpePinata", 0.3f);
	}
	void NoGolpePinata(){
		anim.SetBool ("golpe", false);
	}
	void TerminarJuego(){
		this.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (!terminoanimacion) {
			if (!anim.GetCurrentAnimatorStateInfo (0).IsName ("entrada")) {
				NotificationCenter.DefaultCenter().PostNotification(this, "EmpiezaGenerar");
				terminoanimacion = true;
				//Debug.Log("Termino animacion");
			}
		}
	}
}
