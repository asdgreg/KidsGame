using UnityEngine;
using System.Collections;

public class Ambiente : MonoBehaviour {
	public GameObject datob;
	public datos dat;

	public GameObject tar1;
	public GameObject tar2;
	public GameObject tar3;
	public GameObject tar4;
	public GameObject tar5;
	public GameObject tar6;
	public TextMesh tareatexto;
	public bool comio;
	public bool bano;
	public bool tareas;
	public TextMesh mensaje;
	bool mostrado = false;
	bool mostradob = true;
//horas comida
	public int horac1 = 8;
	public int horac2 = 12;
	public int horac3 = 6;
	public int horab = 2;
	public int horac;
	public bool hora1 = false;
	public bool hora2 = false;
	public bool hora3 = false;
	public bool bano1 = false;
	public int mes;
	public int dia;
	public int ano;
	public int hora;
	public int tc;
	public int tb;
	public AudioSource hambres;
	public AudioSource sucio;
	public int tarea1;
	public int tarea2;
	public int tarea3;
	public int tarea4;
	public int tarea5;
	public int tarea6;

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetInt ("tb") == 0) {
			PlayerPrefs.SetInt("tb",1);
		}
		NotificationCenter.DefaultCenter ().AddObserver (this,"come");
		NotificationCenter.DefaultCenter ().AddObserver (this,"bane");
		mes = System.DateTime.Now.Month;
		dia = System.DateTime.Now.Day;
		ano = System.DateTime.Now.Year;
		hora = System.DateTime.Now.Hour;
		datob = GameObject.FindGameObjectWithTag("Datos");
		dat = datob.GetComponent<datos> ();
		tc = dat.tc;
		tarea1 = PlayerPrefs.GetInt ("tarea1");
		tarea2 = PlayerPrefs.GetInt ("tarea2");
		tarea3 = PlayerPrefs.GetInt ("tarea3");
		tarea4 = PlayerPrefs.GetInt ("tarea4");
		tarea5 = PlayerPrefs.GetInt ("tarea5");
		tarea6 = PlayerPrefs.GetInt ("tarea6");
		PlayerPrefs.SetInt ("diaJugado", dia);
		tareashechas ();
	}

	void tareashechas (){
		if (tarea1 == dia) {
			tar1.SetActive(false);
		}
		if (tarea2 == dia) {
			tar2.SetActive(false);
		}
		if (tarea3 == dia) {
			tar3.SetActive(false);
		}
		if (tarea4 == dia) {
			tar4.SetActive(false);
		}
		if (tarea5 == dia) {
			tar5.SetActive(false);
		}
		if (tarea6 == dia) {
			tar6.SetActive(false);
		}

		if(tarea1 == dia && tarea2 == dia && tarea3 == dia && tarea4 == dia && tarea5 == dia) {
			tareatexto.text = "NO HAY TAREAS";
		}
	}

	public void come(Notification noti){
		if (System.DateTime.Now.Hour >= 8 && System.DateTime.Now.Hour < 12) {
			tc = 1;
			NotificationCenter.DefaultCenter ().PostNotification (this, "tcomida", tc);
		} else {
			if (System.DateTime.Now.Hour >= 12 && System.DateTime.Now.Hour < 6) {
				tc = 2;
				NotificationCenter.DefaultCenter ().PostNotification (this, "tcomida", tc);
			}else{
				if (System.DateTime.Now.Hour >= 6 && System.DateTime.Now.Hour < 8) {
					tc = 3;
					NotificationCenter.DefaultCenter ().PostNotification (this, "tcomida", tc);
				}
			}
		
		}
	
	}
	public void bane(Notification noti){
		if (System.DateTime.Now.Hour >= 8 && System.DateTime.Now.Hour < 12) {
			tb = 1;
			PlayerPrefs.SetInt("tb",tb);
		} else {
			if (System.DateTime.Now.Hour >= 12 && System.DateTime.Now.Hour < 6) {
				tb = 2;
				PlayerPrefs.SetInt("tb",tb);
			}else{
				if (System.DateTime.Now.Hour >= 6 && System.DateTime.Now.Hour < 8) {
					tb = 3;
					PlayerPrefs.SetInt("tb",tb);
				}
			}
			
		}
		
	}
	// Update is called once per frame
	void Update () {
		tc = dat.tc;
		tb = PlayerPrefs.GetInt ("tb");
		if (tc == 1 && hora >= 1 && !mostrado) {
			StartCoroutine(hambre());
		}
		if (tc == 2 && hora >= 6&& !mostrado) {
			StartCoroutine(hambre());
		}
		if (tc == 3 && hora > 8&& !mostrado) {
			StartCoroutine(hambre());
		}
		if (tb == 1 && hora >= 1 && !mostradob) {
			StartCoroutine(pulgas());
		}
		if (tb == 2 && hora >= 6&& !mostradob) {
			StartCoroutine(pulgas());
		}
		if (tb == 3 && hora > 8&& !mostradob) {
			StartCoroutine(pulgas());
		}

	}
	public IEnumerator hambre(){
		mensaje.text = "Hay que Alimentar a la Mascota\n Tiene Hambre";
		hambres.Play ();
		yield return new WaitForSeconds(1f);
		mensaje.text = "";
		mostrado = true;
	}
	public IEnumerator pulgas(){
		yield return new WaitForSeconds(3f);
		mensaje.text = "Hay que banar a la Mascota\n Esta sucio";
		sucio.Play ();
		yield return new WaitForSeconds(1f);
		mensaje.text = "";
		mostradob = true;
	}

	public void rtarea1(){
		PlayerPrefs.SetInt ("tarea1", dia);
		tar1.SetActive(false);
		NotificationCenter.DefaultCenter ().PostNotification (this, "incrementarDinero", 10);
	}
	public void rtarea2(){
		PlayerPrefs.SetInt ("tarea2", dia);
		tar2.SetActive(false);
		NotificationCenter.DefaultCenter ().PostNotification (this, "incrementarDinero", 10);
	}
	public void rtarea3(){
		PlayerPrefs.SetInt ("tarea3", dia);
		tar3.SetActive(false);
		NotificationCenter.DefaultCenter ().PostNotification (this, "incrementarDinero", 10);
	}
	public void rtarea4(){
		PlayerPrefs.SetInt ("tarea4", dia);
		tar4.SetActive(false);
		NotificationCenter.DefaultCenter ().PostNotification (this, "incrementarDinero", 10);
	}
	public void rtarea5(){
		PlayerPrefs.SetInt ("tarea5", dia);
		tar5.SetActive(false);
		NotificationCenter.DefaultCenter ().PostNotification (this, "incrementarDinero", 10);
	}
	public void rtarea6(){
		PlayerPrefs.SetInt ("tarea6", dia);
		tar6.SetActive(false);
		NotificationCenter.DefaultCenter ().PostNotification (this, "incrementarDinero", 10);
	}
}
