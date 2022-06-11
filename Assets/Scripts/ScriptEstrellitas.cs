using UnityEngine;
using System.Collections;

public class ScriptEstrellitas : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (Destruir ());
	}

	private IEnumerator Destruir(){
		yield return new WaitForSeconds (0.8f);
		Debug.Log("Objeto Destruido");
		Destroy (this.gameObject);
	}

	// Update is called once per frame
	void Update () {
	
	}

}
