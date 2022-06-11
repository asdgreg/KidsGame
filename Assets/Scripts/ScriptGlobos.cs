using UnityEngine;
using System.Collections;

public class ScriptGlobos : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		NotificationCenter.DefaultCenter().PostNotification(this, "GenerarPremio", this.gameObject.transform.position);
		Destroy (this.gameObject);
	}


}
