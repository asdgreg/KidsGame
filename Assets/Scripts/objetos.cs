using UnityEngine;
using System.Collections;

public class objetos : MonoBehaviour {

	public string tag;
	public TextMesh mensaje;
	public GameObject tazonp;
	public GameObject tazong;
	// Use this for initialization


	void Start () {
		tag = gameObject.tag;
		Debug.Log (tag);
		print (PlayerPrefs.GetInt("comidap"));
		if (tag == "comidag") {
			tazong = GameObject.FindGameObjectWithTag ("tazag");	
			tazong.SetActive (false);
		}
		if (tag == "comidap") {
			tazonp = GameObject.FindGameObjectWithTag("tazap");	
			print ("ocultando taza perro");
			tazonp.SetActive(false);
		}
		if (tag == "tazap" && PlayerPrefs.GetInt("comidap") == 0) {
			gameObject.SetActive(false);
		}
		if (tag == "tazag" && PlayerPrefs.GetInt("comidag") == 0) {
			gameObject.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {


	}

	void OnMouseDown(){
		switch(tag){
		case "comidap" :{
		//	tazonp = GameObject.FindGameObjectWithTag("tazap");
			if(tazonp != null){
				print ("aqui");
				tazonp.SetActive(true);
				StartCoroutine(escondido(3));


			}else{
					StartCoroutine(mensajemostrar ("Compremos una Taza para tu Perro"));
			}
			break;
		}
		case "comidag":{
			//tazong = GameObject.FindGameObjectWithTag("tazag");
			if(tazong!=null){
				tazong.SetActive(true);
				StartCoroutine(escondido(4));

			}else{
				//mensaje que necesita comprar el tazon primero
				StartCoroutine(mensajemostrar ("Compremos una Taza para tu Gato"));
			}
			break;
		}
		case "tazap":{
			GameObject go = GameObject.FindGameObjectWithTag("perrop");
			Animator anim = go.GetComponent<Animator>();
			tazonp = GameObject.FindGameObjectWithTag("tazap");
			StartCoroutine(accion(anim, "comer"));
			break;
		}
		case "tazag":{
			GameObject go = GameObject.FindGameObjectWithTag("gatog");
			Animator anim = go.GetComponent<Animator>();
			tazong = GameObject.FindGameObjectWithTag("tazag");
			StartCoroutine(accion(anim, "comer"));
			break;
		}
		case "banera":{
			if (PlayerPrefs.GetInt ("mascota")==2){
				print ("0asasda");
				GameObject go = GameObject.FindGameObjectWithTag("perrop");
				Animator anim = go.GetComponent<Animator>();
				StartCoroutine(accion(anim, "banarse"));
			}else{
				GameObject go = GameObject.FindGameObjectWithTag("gatog");
				Animator anim = go.GetComponent<Animator>();
				StartCoroutine(accion(anim, "banarse"));
			}
			break;
		}
		default: break;
		}
	}
	
	public IEnumerator mensajemostrar(string texto){
		mensaje.text = texto;
		Debug .Log ("antes");
		yield return new WaitForSeconds (3f);
		mensaje.text = "";

	}
	public IEnumerator accion(Animator anim, string acc){
		anim.SetBool(acc,true);
		yield return new WaitForSeconds (3f);
		anim.SetBool(acc,false);
		if (acc == "comer" && tag == "tazap") {
			yield return new WaitForSeconds (1.3f);
			NotificationCenter.DefaultCenter ().PostNotification (this, "come");
			tazonp.SetActive(false);
		}
		if (acc == "comer" && tag == "tazag") {
			yield return new WaitForSeconds (1.3f);
			NotificationCenter.DefaultCenter ().PostNotification (this, "come");
			tazong.SetActive(false);
		}
		if (acc == "banarse") {
			anim.SetBool("banarse",true);
			yield return new WaitForSeconds (1.3f);
			anim.SetBool("banarse",false);

		}
	}
	
	public IEnumerator escondido(int num){

		Debug .Log ("escondido");
		yield return new WaitForSeconds (1f);
		NotificationCenter.DefaultCenter ().PostNotification (this, "eliminarobjeto",num);
		Debug .Log ("hecho");
		Destroy(gameObject);
	}


}
