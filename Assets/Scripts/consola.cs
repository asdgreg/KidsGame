using UnityEngine;
using UnityEngine.UI;
using System.Collections;

using System.Collections.Generic;

public class consola : MonoBehaviour {
	public List<Button> btns = new List<Button>();
	public float tiempoPausa;
	public float tiempoverde1;
	public float tiempoverde2;
	public float tiempoverde3;
	public float tiemporojo1;
	public float tiemporojo2;
	public float tiemporojo3;
	public float tiempoactivov;
	public float tiempoactivor;
	public bool jugando= true;
	public AudioSource acerto;
	public TextMesh texto;
	public TextMesh	puntos;
	public int logrados;
	public float tiempo = 0.0f;
	public bool termino = false;
	public string[] posx2 = {"1","2","3","4"};
	public string[] posy2 = {"1","2","3","4"};
	//actualizacion

	public List<string> secuencia = new List<string>();
	public List<string> s_tocada = new List<string>();
	// Use this for initialization
	void Start () {
		GetButtons ();
		AddListeners ();
		StartCoroutine(rotacionv(tiempoverde1));
		StartCoroutine(rotacionv(tiempoverde2));		
		StartCoroutine(rotacionv(tiempoverde3));
		StartCoroutine(rotacionr(tiemporojo1));
		StartCoroutine(rotacionr(tiemporojo2));		
		StartCoroutine(rotacionr(tiemporojo3));
	}

	// Update is called once per frame
	void Update () {
		tiempo -= Time.deltaTime;
		if (tiempo >= 0 && !termino) {
			texto.text = "TIEMPO: "+tiempo.ToString ("f0");
			tiempoactivov = tiempo *0.01f;
		} else {
			termino = true;;
		}
	}

	void AddListeners(){
		for(int i = 0;i< btns.Count;i++){
			btns[i].onClick.AddListener(() => botontocado());
		}
	}
	public void botontocado(){
		string nombre = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;

		int postocado = int.Parse (nombre);

		if (btns[postocado].image.color.a == 255) {
			if(btns[postocado].image.color.r == 155){
				btns[postocado].image.color = new Color(0,0,0,0);
				if(logrados <=0){logrados = 0;}else{logrados--;}

				puntos.text = "DINERO GANADO: "+ logrados.ToString();
				acerto.Play();
			}
			if(btns[postocado].image.color.g == 155f){
				btns[postocado].image.color = new Color(0,0,0,0);
				logrados++;
				puntos.text = "DINERO GANADO: "+logrados.ToString();
				acerto.Play();
			}
		}
	}
	public void GetButtons(){
		GameObject[] objects = GameObject.FindGameObjectsWithTag ("btnconsola");
		for(int i = 0; i < objects.Length ;i++){
			btns.Add(objects[i].GetComponent<Button>());

		}
		for(int i = 0; i < btns.Count ;i++){

			btns[i].image.color = new Color(0,0,0,0);
		}
	}

	public IEnumerator rotacionv(float temp){
		while (jugando) {
			yield return new WaitForSeconds (temp);
			yield return new WaitForSeconds (tiempoPausa);
			int rand =Random.Range(0,btns.Count);
			btns[rand].image.color = new Color(0,155,0,255);
			yield return new WaitForSeconds (tiempoactivov);
			btns[rand].image.color = new Color(0,0,0,0);
		}
	}
	public IEnumerator rotacionr(float temp){
		while (jugando) {
			yield return new WaitForSeconds (temp);
			yield return new WaitForSeconds (tiempoPausa);
			int rand =Random.Range(0,btns.Count);
			btns[rand].image.color = new Color(155,0,0,255);
			yield return new WaitForSeconds (tiempoactivor);
			btns[rand].image.color = new Color(0,0,0,0);
		}
	}

	public IEnumerator cadenamostrar(float temp){

			yield return new WaitForSeconds (temp);
			yield return new WaitForSeconds (tiempoPausa);
			int rand =Random.Range(0,btns.Count);
			btns[rand].image.color = new Color(155,0,0,255);
			yield return new WaitForSeconds (tiempoactivor);
			btns[rand].image.color = new Color(0,0,0,0);

	}


	public int botonencender(int x, int y){
		int posx = x;
		int posy = y;
		return (posx + 4 * posy);
	}





	public void regresar(){
		Application.LoadLevel("Inicio");
	}
}
