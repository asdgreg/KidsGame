using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class gusanoConsola : MonoBehaviour {
	public List<int> secuencia = new List<int>();
	public List<int> secuenciatocada = new List<int>();
	public List<Button> btns = new List<Button>();
	public int posactual = 0;
	public int tamano = 0;
	public TextMesh puntos;
	public TextMesh ronda;
	public int puntosgenerados = 0;
	public int rondaactual = 1;
	public AudioSource tecla;
	// Use this for initialization
	void Start () {
		GetButtons ();
		AddListeners ();
		secuencia.Add (1);
		NotificationCenter.DefaultCenter ().AddObserver (this,"botongusano");
		print (Random.Range (1, 3));
		if (Random.Range (1, 3) == 1) {
			print ("12");
			secuencia.Add (siguienteposxy (1, 5));
		} else {
			print ("15");
			secuencia.Add (siguienteposxy (1, 2));
		}
		StartCoroutine (ejecucion ());
		ronda.text = "RONDA N: " + rondaactual;
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
	public void botongusano(Notification noti){
		string nombre = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
		
		int postocado = int.Parse (nombre);

	}

	void AddListeners(){
		for(int i = 0;i< btns.Count;i++){
			btns[i].onClick.AddListener(() => botontocado());
		}
	}
	public void botontocado(){
		string nombre = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
		int botontocado = int.Parse (nombre);
		secuenciatocada.Add (botontocado+1);
		btns[botontocado].image.color = new Color(0,155,0,255);
		posactual++;
		StartCoroutine (apagar (botontocado));
		tecla.Play ();
	}

	public IEnumerator apagar(int i){
		yield return new WaitForSeconds (0.45f);
		btns[i].image.color = new Color(0,0,0,0);
	}
	// Update is called once per frame
	void Update () {
	
	}
	public IEnumerator ejecucion(){
		bool correcto = true;
		while(correcto){
			StartCoroutine(mostrando());
			secuenciatocada = null;
			secuenciatocada = new List<int>();
			posactual = 0;
			while(esperando()){
				print("esperando...");
				yield return new WaitForSeconds (1.0f);
			}

			for(int i = 0; i<secuencia.Count; i++){
				if(secuencia[i] == secuenciatocada[i]){
					print ("correcta");
					correcto = true;
				}else{
					print ("incorrecta");
					correcto = false;
				}
				if(!correcto){break;}

			}
			yield return new WaitForSeconds (2.0f); //ultima vista total
			for (int i = 0; i<btns.Count; i++) {
				btns[i].image.color = new Color(0,0,0,0);
			}
			print ("limpiadas");
			if(correcto){
				ronda.text = "RONDA N: " + rondaactual++;
				print ("pos" + secuencia[1]);
				puntos.text = "SECUENCIA: "+ secuencia.Count;
				print ("posanterior" + secuencia[0]);
				secuencia.Add (siguienteposxy (secuencia[secuencia.Count-1],secuencia[secuencia.Count-2]));
				print ("btonagregado");
				if(rondaactual == 5 ||rondaactual == 10 ||rondaactual == 15||rondaactual == 20||rondaactual == 25||rondaactual == 30||rondaactual == 45||rondaactual > 50)
				   {
					NotificationCenter.DefaultCenter ().PostNotification (this, "incrementarDinero", (rondaactual/5)*10);
				}
			}else{
				//entrega premios
				puntos.text = "TERMINADO";
					NotificationCenter.DefaultCenter ().PostNotification (this, "menosdeuda", ((rondaactual)*10)/3);
					NotificationCenter.DefaultCenter ().PostNotification (this, "incrementarDinero", (rondaactual)*10);

			}
			
		}
		

	}
	public bool esperando(){
		bool llenando;
		if (posactual >= secuencia.Count) {
			llenando = false;
		} else {
			llenando = true;
		}
		return llenando;
	}


	public IEnumerator mostrando(){
		//mostrando 

		yield return new WaitForSeconds (3.0f);//espera 5 segundos
		for (int i = 0; i<secuencia.Count; i++) {
			int randomize = Random.Range(1,255);
			btns[secuencia[i]-1].image.color = new Color(randomize,randomize,0,255);
			print("color"+randomize);
			yield return new WaitForSeconds (0.7f);
			StartCoroutine (apagar (secuencia[i]-1));
		}
		yield return new WaitForSeconds (3.0f); //ultima vista total
		for (int i = 0; i<secuencia.Count; i++) {
			btns[secuencia[i]-1].image.color = new Color(0,0,0,0);
		}

	}
	public int siguienteposxy(int pos,int posa){
		int sig = 0;
		print (pos);
		print (posa);
		print ("siguiente booton agregar " + pos);
		switch(pos){
		case 1:
		case 5:
		case 9:
		case 13:{
			print ("grupo 1");
			if(pos == 1 && posa ==2){
				sig = 5;
			}
			if(pos == 1 && posa ==5){
				sig = 2;
			}
			if(pos == 13 && posa ==14){
				sig = 9;
			}
			if(pos == 13 && posa ==9){
				sig = 14;
			}
			if(pos == 5 && posa ==6){
				int ra = Random.Range(1,3);
				if(ra == 1){
					sig = 1;
				}else{
					sig = 9;
				}
			}
			if(pos == 5 && posa ==1){
				int ra = Random.Range(1,3);
				if(ra == 1){
					sig = 6;
				}else{
					sig = 9;
				}
			}
			if(pos == 5 && posa ==9){
				int ra = Random.Range(1,3);
				if(ra == 1){
					sig = 6;
				}else{
					sig = 1;
				}
			}
			if(pos == 9 && posa ==10){
				int ra = Random.Range(1,3);
				if(ra == 1){
					sig = 5;
				}else{
					sig = 13;
				}
			}
			if(pos == 9 && posa ==5){
				int ra = Random.Range(1,3);
				if(ra == 1){
					sig = 10;
				}else{
					sig = 13;
				}
			}
			if(pos == 9 && posa ==13){
				int ra = Random.Range(1,3);
				if(ra == 1){
					sig = 10;
				}else{
					sig = 5;
				}
			}
			break;
		}
		case 4:
		case 8:
		case 12:
		case 16:{
			if(pos == 4 && posa ==3){
				sig = 8;
			}
			if(pos == 4 && posa ==8){
				sig = 3;
			}
			if(pos == 16 && posa ==15){
				sig = 12;
			}
			if(pos == 16 && posa ==12){
				sig = 15;
			}
			if(pos == 8 && posa ==7){
				int ra = Random.Range(1,3);
				if(ra == 1){
					sig = 4;
				}else{
					sig = 12;
				}
			}
			if(pos == 8 && posa ==4){
				int ra = Random.Range(1,3);
				if(ra == 1){
					sig = 7;
				}else{
					sig = 12;
				}
			}
			if(pos == 8 && posa ==12){
				int ra = Random.Range(1,3);
				if(ra == 1){
					sig = 7;
				}else{
					sig = 4;
				}
			}
			if(pos == 12 && posa ==11){
				int ra = Random.Range(1,3);
				if(ra == 1){
					sig = 8;
				}else{
					sig = 16;
				}
			}
			if(pos == 12 && posa ==8){
				int ra = Random.Range(1,3);
				if(ra == 1){
					sig = 11;
				}else{
					sig = 16;
				}
			}
			if(pos == 12 && posa ==16){
				int ra = Random.Range(1,3);
				if(ra == 1){
					sig = 11;
				}else{
					sig = 8;
				}
			}
			
			break;
		}
		case 2:
		case 3:{
			
			if(pos == 2 && posa ==1){
				int ra = Random.Range(1,3);
				if(ra == 1){
					sig = 3;
				}else{
					sig = 6;
				}
			}
			if(pos == 2 && posa ==3){
				int ra = Random.Range(1,3);
				if(ra == 1){
					sig = 6;
				}else{
					sig = 1;
				}
			}
			if(pos == 2 && posa ==6){
				int ra = Random.Range(1,3);
				if(ra == 1){
					sig = 1;
				}else{
					sig = 3;
				}
			}
			if(pos == 3 && posa ==2){
				int ra = Random.Range(1,3);
				if(ra == 1){
					sig = 4;
				}else{
					sig = 7;
				}
			}
			if(pos == 3 && posa ==4){
				int ra = Random.Range(1,3);
				if(ra == 1){
					sig = 7;
				}else{
					sig = 2;
				}
			}
			if(pos == 3 && posa ==7){
				int ra = Random.Range(1,3);
				if(ra == 1){
					sig = 2;
				}else{
					sig = 4;
				}
			}
			
			break;
		}
		case 14:
		case 15:{
			if(pos == 14 && posa ==13){
				int ra = Random.Range(1,3);
				if(ra == 1){
					sig = 10;
				}else{
					sig = 15;
				}
			}
			if(pos == 14 && posa ==10){
				int ra = Random.Range(1,3);
				if(ra == 1){
					sig = 15;
				}else{
					sig = 13;
				}
			}
			if(pos == 14 && posa ==15){
				int ra = Random.Range(1,3);
				if(ra == 1){
					sig = 13;
				}else{
					sig = 10;
				}
			}
			if(pos == 15 && posa ==14){
				int ra = Random.Range(1,3);
				if(ra == 1){
					sig = 11;
				}else{
					sig = 16;
				}
			}
			if(pos == 15 && posa ==16){
				int ra = Random.Range(1,3);
				if(ra == 1){
					sig = 14;
				}else{
					sig = 11;
				}
			}
			if(pos == 15 && posa ==11){
				int ra = Random.Range(1,3);
				if(ra == 1){
					sig = 13;
				}else{
					sig = 16;
				}
			}
			break;
		}


			
			//asdasd
		default : {print ("default"); break;}
		case 6:
		case 7:
		case 10:
		case 11:{
			int ra = Random.Range(1,5);
			print (ra);
			if(ra == 1){sig = pos - 4;}//sube
			if(ra == 2){sig = pos + 4;}//baja
			if(ra == 3){sig = pos + 1;}//derecha
			if(ra == 4){sig = pos - 1;}//izquierda
			break;
		}
		}
		return sig;
	}


}