using UnityEngine;
using System.Collections;

public class introbanco : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (intro ());
	}

	IEnumerator intro(){
		yield return new WaitForSeconds (4.6f);
		Application.LoadLevel ("Start");
	}
	// Update is called once per frame
	void Update () {
	
	}
}
