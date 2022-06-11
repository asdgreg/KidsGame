using UnityEngine;
using System.Collections;

public class logroie : MonoBehaviour {
	public AudioSource acertado;
	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter ().AddObserver (this, "logrado");
	}


	void logrado(){
		acertado.Play ();
		Destroy (gameObject);
	}
	// Update is called once per frame
	void Update () {
	
	}
}
