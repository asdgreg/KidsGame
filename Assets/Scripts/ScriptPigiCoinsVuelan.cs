using UnityEngine;
using System.Collections;

public class ScriptPigiCoinsVuelan : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (Destruir ());
	}
	
	// Update is called once per frame
	void Update () {

	}

	private IEnumerator Destruir(){
		yield return new WaitForSeconds (1f);
		Debug.Log("Objeto Destruido");
		Destroy (this.gameObject);
	}
}
