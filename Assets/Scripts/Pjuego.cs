using UnityEngine;
using System.Collections;

public class Pjuego : MonoBehaviour {
	public GUIStyle estilo;
	public Vector3 vectorderecha;
	public Vector3 vectorizquierda;
	public Vector3 centro;
	public Vector3 vectorarriba;
	public bool bderecha = false;
	public bool bizquierda = false;
	public bool barriba = false;
	public Transform juego;
	public Transform mtienda;
	public Transform mtareas;
	public GameObject nino;
	public GameObject nina;
	public GameObject perro;
	public GameObject gato;
	public GameObject datob;
	public string[] tag = {"casitap","casitag","cepillo","comidap","comidag","shampoo","juguetep","jugueteg","botella","banera","tazap","tazag","collarp","collarg"};
	public int[] objetos;
	public datos dat;
	public AudioSource sonidojuego;
	public AudioSource sonidotarea;

// Use this for initialization
//
//	void Awake(){
//		datob = GameObject.FindGameObjectWithTag("Datos");
//		dat = datob.GetComponent<datos> ();
//		objetos = dat.objetos;
//		if (dat.mascota == 1) {
//			Destroy (perro);
//			
//		} else {
//			Destroy(gato);
//		}
//		
//		if (dat.personaje == 1) {
//			Destroy (nino);
//		} else {
//			Destroy(nina);
//		}
//		//eliminacion de los objetos
//		
//		for(int i = 0; i < tag.Length; i++){
//			GameObject go = GameObject.FindGameObjectWithTag(tag[i]);
//
//			if(objetos[i] ==0){
//				Destroy(go);
//
//			}
//		}
//		
//		if (dat.mascota == 1) {
//			GameObject obt = GameObject.FindGameObjectWithTag("tazap");
//			Destroy(obt);
//		}
//		if (dat.mascota == 2) {
//			GameObject obt = GameObject.FindGameObjectWithTag("tazag");
//			Destroy(obt);
//			
//		}
//	}
	void Start () {
		estilo.fontSize = 91;
		centro = transform.position;
		datob = GameObject.FindGameObjectWithTag("Datos");
		dat = datob.GetComponent<datos> ();
		objetos = dat.objetos;
		if (dat.mascota == 1) {
			Destroy (perro);

		} else {
			Destroy(gato);
		}

		if (dat.personaje == 1) {
			Destroy (nino);
		} else {
			Destroy(nina);
		}
		//eliminacion de los objetos

		for(int i = 0; i < tag.Length; i++){
			GameObject go = GameObject.FindGameObjectWithTag(tag[i]);
			Debug.Log(tag[i]);
			if(objetos[i] ==0){
				Destroy(go);
			}
		}

		if (dat.mascota == 1) {
			GameObject obt = GameObject.FindGameObjectWithTag("tazap");
			Destroy(obt);
		}
		if (dat.mascota == 2) {
			GameObject obt = GameObject.FindGameObjectWithTag("tazag");
				Destroy(obt);
			
		}


	}

	// Update is called once per frame
	void Update () {

		vectorderecha = transform.position;
		vectorderecha.x = 20;
		vectorizquierda = transform.position;
		vectorizquierda.x = -20;
		vectorarriba = transform.position;
		vectorarriba.y = 20;

		
		Vector3 juegof = juego.position;
		Vector3 tiendaf = mtienda.position;
		Vector3 tareasf = mtareas.position;

		tiendaf.x = -20;
		juegof.x = 20;
		tareasf.y = 20;
		if (bderecha) {
		
			transform.position = Vector3.MoveTowards(transform.position, vectorderecha, (20f * Time.deltaTime));
			juego.position = Vector3.MoveTowards(juego.position,juegof,(20f * Time.deltaTime) );
		}
		if (bizquierda) {

			transform.position = Vector3.MoveTowards(transform.position, vectorizquierda, (20f * Time.deltaTime));
			mtienda.position = Vector3.MoveTowards(mtienda.position,tiendaf,(20f * Time.deltaTime) );
		}
		if (barriba) {
			transform.position = Vector3.MoveTowards(transform.position, vectorarriba, (20f * Time.deltaTime));
			mtareas.position = Vector3.MoveTowards(mtareas.position,tareasf,(20f * Time.deltaTime) );
		}
		if (bizquierda == false && bderecha == false && barriba == false) {
			tiendaf.x = -20;
			juegof.x = 20;
			tareasf.y = 20; 
			juego.position = Vector3.MoveTowards(juego.position,juegof,(20f * Time.deltaTime) );
			mtienda.position = Vector3.MoveTowards(mtienda.position,tiendaf,(20f * Time.deltaTime) );
			mtareas.position = Vector3.MoveTowards(mtareas.position,tareasf,(20f * Time.deltaTime) );
			transform.position = Vector3.MoveTowards(transform.position, centro, (20f * Time.deltaTime));
		}

        
	}


//	void OnGUI () {
//		if (GUI.Button (new Rect (10,10,300,150), "TIENDA <-",estilo)) {//boton para pantalla izquierda
//			Debug.Log("Camara  Izquierda");	
//			if(bderecha == true){bderecha = false;barriba = false;}else{if(bizquierda ==false && bizquierda == false && barriba == false){bderecha = false; bizquierda = true;}}
//			if(barriba){barriba = false;}
//		}
//		
//		if (GUI.Button (new Rect (Screen.width - 300,10,300,150), "JUEGOS->",estilo)) {//boton para pantalla derecha
//			Debug.Log("Camara  Derecha");
//			if(bizquierda == true){bizquierda = false;barriba = false;}else{if(bderecha ==false && bizquierda == false && barriba == false){bderecha = true; bizquierda = false;}}
//			if(barriba){barriba = false;}
//		}
//		if (GUI.Button (new Rect (Screen.width/2 - 150,10,300,150), "Tareas",estilo)) {//boton para pantalla arriba
//			Debug.Log("Camara  ARRIBA");
//			if(bizquierda == true || bderecha == true || barriba == true){bizquierda = false; bderecha = false; barriba = false;}else{if(bderecha ==false && bizquierda == false){bderecha = false; bizquierda = false; barriba = true;}}
//		}
//	}



	public void tienda(){
		Debug.Log("Camara  Izquierda");	

		if(bderecha == true){bderecha = false;barriba = false;}else{if(bizquierda ==false && bizquierda == false && barriba == false){bderecha = false; bizquierda = true;}}
		if(barriba){barriba = false;}
	}

	public void juegos(){
		Debug.Log("Camara  Derecha");

		if(bizquierda == true){bizquierda = false;barriba = false;}else{if(bderecha ==false && bizquierda == false && barriba == false){bderecha = true; bizquierda = false;sonidojuego.Play ();}}
		if(barriba){barriba = false;}
	}
	public void arriba(){
		Debug.Log("Camara  ARRIBA");
		if(bizquierda == true || bderecha == true || barriba == true){bizquierda = false; bderecha = false; barriba = false;}else{if(bderecha ==false && bizquierda == false){bderecha = false; bizquierda = false; barriba = true;sonidotarea.Play ();}}
	}

	public void pares(){
		Application.LoadLevel ("puzzlePares");
	}
	public void RPB(){
		if (PlayerPrefs.GetInt("edad") <= 5) {
			Application.LoadLevel ("mjRBilletes2");
		} else {
			Application.LoadLevel ("mjRBilletes");
		}

	}
	public void comprartienda(){
		Application.LoadLevel ("tienda");
	}
	public void banco(){
		Application.LoadLevel ("banco");
	}
	public void btnperro3D(){
		Application.LoadLevel ("paseo3D");

	}
	public void btnie(){
		Application.LoadLevel ("ie");
		
	}
	public void btnpinata(){
		Application.LoadLevel ("MainPinata");
		
	}
	public void btnbolsa(){
		Application.LoadLevel ("MainAtrapa");
		
	}
	public void btnperrocorrer(){
		Application.LoadLevel ("MainPerrito");
		
	}
	public void globos(){
		Application.LoadLevel ("MainGlobos");
		
	}
	public void consola(){
		Application.LoadLevel ("gusanoConsola");
		
	}

	public void btnsaltar(){
		NotificationCenter.DefaultCenter ().PostNotification (this, "incrementarDinero", 5);
	}
	public void btntareas(){
		NotificationCenter.DefaultCenter ().PostNotification (this, "incrementarDinero", 5);
	}
	public void btnbmascota(){
		NotificationCenter.DefaultCenter ().PostNotification (this, "incrementarDinero", 5);
	}
	public void btnpmascota(){
		NotificationCenter.DefaultCenter ().PostNotification (this, "incrementarDinero", 5);
	}
	public void btnbanarse(){
		NotificationCenter.DefaultCenter ().PostNotification (this, "incrementarDinero", 5);
	}

}
