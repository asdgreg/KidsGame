using UnityEngine;
using System.Collections;

public class ButtonClick : MonoBehaviour {

	float x;
	float y;
	float z;
	public Vector3 asd;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		x = Input.mousePosition.x;
		y = Input.mousePosition.y;

	}


	void OnMouseDrag(){
		transform.position = Camera.main.ScreenToWorldPoint(new Vector3(x,y,10f));
	}

}
