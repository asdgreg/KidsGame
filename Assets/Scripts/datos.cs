using UnityEngine;
using System.Collections;
using System;
//using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class datos : MonoBehaviour {
	public static datos estado;
	public int dinero;
	public int personaje;
	public int mascota;
	public int edad;
	public int deuda;
	public int tc;
	public TextMesh text;
	public TextMesh text2;
	public string nombreArchivo;
	public int[] objetos;
	public int primera;


	// Use this for initialization
	void Awake() {

		if (estado == null) {
			estado = this;
			Debug.Log("ya existe" + dinero);
			DontDestroyOnLoad (gameObject);
		}else if(estado!= this){
			Destroy(gameObject);
			Debug.Log("no destruido" + dinero);
		}
		nombreArchivo = Application.persistentDataPath + "/datos.dat";
		NotificationCenter.DefaultCenter ().AddObserver (this,"incrementarDinero");
		NotificationCenter.DefaultCenter ().AddObserver (this,"dmascota");
		NotificationCenter.DefaultCenter ().AddObserver (this,"dpersonaje");
		NotificationCenter.DefaultCenter ().AddObserver (this,"poneredad");
		NotificationCenter.DefaultCenter ().AddObserver (this,"incrementodeuda");
		NotificationCenter.DefaultCenter ().AddObserver (this,"compraobjeto");
		NotificationCenter.DefaultCenter ().AddObserver (this,"comproobjeto");
		NotificationCenter.DefaultCenter ().AddObserver (this,"eliminarobjeto");
		NotificationCenter.DefaultCenter ().AddObserver (this,"tcomida");
		NotificationCenter.DefaultCenter ().AddObserver (this,"menosdeuda");
		cargar ();
	}
	void Start(){
		cargar ();
	}
	
	// Update is called once per frame
	void Update () {
		text.text = dinero.ToString();
		text2.text = deuda.ToString ();

	}
	void tcomida(Notification noti){
		int tcr = (int)noti.data;
		tc = tcr;
		actualizardinero ();
		guardar ();
	}
	void poneredad(Notification noti){
		int edaddat = (int)noti.data;
		edad = edaddat;
		actualizardinero ();
		guardar ();
	}
	void eliminarobjeto(Notification noti){
		int posobjeto = (int)noti.data;
		objetos [posobjeto] = 0;
		actualizardinero ();
		guardar ();
	}
	void comproobjeto(Notification noti){
		int posobjeto = (int)noti.data;
		objetos [posobjeto] = 1;
		actualizardinero ();
		guardar ();
	}
	void compraobjeto(Notification noti){
		int costo = (int)noti.data;
		dinero = dinero - costo;
		actualizardinero ();
		guardar ();
	}

	void menosdeuda(Notification noti){
		int pago = Convert.ToInt32(noti.data);
		if (deuda - pago <= 0) {
			deuda = 0;
		} else {
			deuda = deuda - pago;
		}
		actualizardinero ();
		guardar ();
		
	}
	void incrementodeuda(Notification noti){
		int deuda1 = (int)noti.data;
		deuda = deuda1;
		actualizardinero ();
		guardar ();
		
	}
	void incrementarDinero(Notification noti){
		int dinero1 = (int)noti.data;
		dinero = dinero + dinero1;
		Debug.Log ("incrementando "+dinero1);
		actualizardinero ();
		estado.dinero = dinero;
		guardar ();
	}

	void dmascota(Notification masc){
		int d = (int)masc.data;
		mascota = d;
	}

	void dpersonaje(Notification per){
		int d = (int)per.data;
		personaje = d;
	
	}
	void actualizardinero (){
		text.text = dinero.ToString();
		text2.text = deuda.ToString ();
	}

	void guardar(){
//		Debug.Log ("creando arrchivo");
//		BinaryFormatter bf = new BinaryFormatter ();
//		FileStream file = File.Create(nombreArchivo);
//		DatosGuardar datos = new DatosGuardar ();
//		datos.dinero = dinero;
//		datos.deuda = deuda;
//		datos.edad = edad;
//		datos.mascota = mascota;
//		datos.personaje = personaje;
//		datos.objetos = objetos;
//		datos.tc = tc;
//		bf.Serialize (file, datos);
//		file.Flush ();
//		file.Close (); 

		//windows phone
		PlayerPrefs.SetInt("puntuacionMaxima", dinero);
		PlayerPrefs.SetInt("personaje", personaje);
		PlayerPrefs.SetInt("mascota", mascota);
		PlayerPrefs.SetInt("edad", edad);
		PlayerPrefs.SetInt("deuda",deuda);
		PlayerPrefs.SetInt("primer", primera);
		string[] tag = {"casitap","casitag","cepillo","comidap","comidag","shampoo","juguetep","jugueteg","botella","banera","tazap","tazag","collarp","collarg"};
		if(objetos == null || objetos.Length == 0){objetos = new int[14];}
		for(int i = 0; i < tag.Length; i++){
			PlayerPrefs.SetInt(tag[i],objetos[i]);
		}
		PlayerPrefs.SetInt("tc",tc);

	}
	void cargar(){
//		if (File.Exists (nombreArchivo)) {
//			Debug.Log ("existe");
//			BinaryFormatter bf = new BinaryFormatter ();
//			FileStream file = File.Open (nombreArchivo, FileMode.Open);
//			DatosGuardar dato = (DatosGuardar)bf.Deserialize (file);
//			dinero = dato.dinero;
//			mascota = dato.mascota;
//			personaje = dato.personaje;
//			deuda = dato.deuda;
//			objetos = dato.objetos;
//			edad = dato.edad;
//			tc = datos.tc;
//			file.Close ();
//		} else {
//			dinero = -1;
//			Debug.Log ("no existe archivo, es primera vez");
//			objetos = new int[14];
//				for(int i = 0; i < objetos.Length; i++){
//					objetos[i] = 0;
//				}
//
//		}//ANDROID

		//WINDOWS PHONE
		dinero = PlayerPrefs.GetInt("puntuacionMaxima");
		personaje = PlayerPrefs.GetInt("personaje");
		mascota = PlayerPrefs.GetInt("mascota");
		edad = PlayerPrefs.GetInt("edad");
		deuda = PlayerPrefs.GetInt("deuda");
		primera = PlayerPrefs.GetInt("primer");
				string[] tag = {"casitap","casitag","cepillo","comidap","comidag","shampoo","juguetep","jugueteg","botella","banera","tazap","tazag","collarp","collarg"};
		if(objetos == null || objetos.Length == 0){objetos = new int[14];}
		for(int i = 0; i < tag.Length; i++){
			objetos[i] = PlayerPrefs.GetInt(tag[i],0);
		}
		tc = PlayerPrefs.GetInt("tc");
	}


}
//[Serializable]
//class DatosGuardar{
//	public int dinero;
//	public int mascota; //1, gato 2, es perro
//	public int personaje;
//	public int edad;
//	public int deuda;
//	public int[] objetos;
//	public int tc;
//	public DatosGuardar(){
//	
//	
//	}
//
//}
