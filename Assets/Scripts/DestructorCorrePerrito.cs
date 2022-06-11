using UnityEngine;
using System.Collections;

public class DestructorCorrePerrito : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag != "Player") {
			Destroy(coll.gameObject);
		}
	}

//	void OnTriggerEnter2D(Collider2D other){
//		Destroy(other.gameObject);
//	}
}
