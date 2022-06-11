using UnityEngine;
using System.Collections;

public class controles : MonoBehaviour {
	[SerializeField]
	private Transform puzzleField;
	[SerializeField]
	private GameObject btn;
	public int botones;
	public int edad;
	// Use this for initialization

	public GameObject datob;
	public datos dat;
	public int deuda;
	public int dinero;


	void Awake () {

		datob = GameObject.FindGameObjectWithTag("Datos");
		dat = datob.GetComponent<datos> ();
		edad = dat.edad;


		if (edad < 5) {
			botones = 8;
		} else {
			botones = 16;
		}


		for (int i = 0; i < botones; i++) {
			GameObject button = Instantiate(btn);
			button.name = "" + i;
			button.transform.SetParent(puzzleField,false);
		}
		 
	}

	public void regreso(){
		Application.LoadLevel ("Inicio");
	}

	// Update is called once per frame
	void Update () {
	
	}
}
