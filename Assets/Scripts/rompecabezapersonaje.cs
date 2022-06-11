using UnityEngine;
using System.Collections;

public class rompecabezapersonaje : MonoBehaviour {
	//distancias
	public float cabeza;
	public float cuerpo;
	public float manoD;
	public float manoI;
	public float pieD;
	public float PieI;
	//transform real

	public Transform cabezaT;
	public Transform cuerpoT;
	public Transform manoDT;
	public Transform manoIT;
	public Transform pieDT;
	public Transform PieIT;
	//transform donde debe coincidir

	public Transform cabezaT2;
	public Transform cuerpoT2;
	public Transform manoDT2;
	public Transform manoIT2;
	public Transform pieDT2;
	public Transform PieIT2;

	//booleano de colocacion
	public bool cabezab;
	public bool cuerpob;
	public bool manoDb;
	public bool manoIb;
	public bool pieDb;
	public bool PieIb;
	public bool completado = false;
	//sprites

	public Texture2D cabezaS;
	public Sprite cuerpoS;
	public Sprite manoDS;
	public Sprite manoIS;
	public Sprite pieDS;
	public Sprite PieIS;
	//parametros

	public TextMesh texto;
	public int te;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		cabeza = Vector3.Distance (cabezaT.position, cabezaT2.position);
		cuerpo = Vector3.Distance (cuerpoT.position, cuerpoT2.position);
		manoD = Vector3.Distance (manoDT.position, manoDT2.position);
		manoI = Vector3.Distance (manoIT.position, manoIT2.position);
		pieD = Vector3.Distance (pieDT.position, pieDT2.position);
		PieI = Vector3.Distance (PieIT.position, PieIT2.position);

		cabezab= verificacion (cabeza);
		cuerpob=verificacion (cuerpo);
		manoDb=verificacion (manoD);
		manoIb=verificacion (manoI);
		pieDb=verificacion (pieD);
		PieIb=verificacion (PieI);

		if (cabezab && cuerpob && manoDb && manoIb && pieDb && PieIb) { completado = true;}

		if (cabezab && cuerpob && manoDb && manoIb && pieDb && PieIb&& completado &&(te < 1)) {
			texto.text = "COMPLETADO!!!";
			te++;
		}

	}



	bool verificacion(float d){
	
		if (d < 0.4)
			return true;
		else
			return false;
	}

	public void aceptado(){
		if(completado){
			Application.LoadLevel("desicionmascota");
		}
	
	}
}
