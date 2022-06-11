using UnityEngine;
using System.Collections;

public class dinero : MonoBehaviour {
	public int cantDinero = 0;
	public TextMesh text;
	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter ().AddObserver (this,"incrementarDinero");
		actualizardinero ();
	}

	void incrementarDinero(Notification noti){
		int dinero = (int)noti.data;
		cantDinero = cantDinero + dinero;
		Debug.Log ("incrementando "+cantDinero);
		actualizardinero ();
	}
	void actualizardinero (){
		text.text = cantDinero.ToString();
	}
	// Update is called once per frame
	void Update () {
	
	}
}
