using UnityEngine;
using System.Collections;


public class ie : MonoBehaviour {
	public GameObject datob;


	//objetos
	public GameObject a1;
	public GameObject a2;
	public GameObject a3;
	public GameObject a4;
	public GameObject q1;
	public GameObject q2;
	public GameObject q3;
	public GameObject q5;
	public GameObject q4;

	//finobjertos
	public datos dat;
	public int deuda;
	public int dinero;
	public float radio;
	public Transform ingreso;
	public Transform egreso;
	//transform ingreso
	public Transform i1;
	public Transform i2;
	public Transform i3;
	public Transform i4;
	//transform egreso
	public Transform e1;
	public Transform e2;
	public Transform e3;
	public Transform e4;
	public Transform e5;
	//boleanos de que esta cerca egreso
	public bool be1;
	public bool be2;
	public bool be3;
	public bool be4;
	public bool be5;
	//boleanos de que esta cerca ingreso
	public bool bi1;
	public bool bi2;
	public bool bi3;
	public bool bi4;

	//distancia
	public float di1;
	public float di2;
	public float di3;
	public float di4;

	public float de1;
	public float de2;
	public float de3;
	public float de4;
	public float de5;

	public TextMesh texto;
	int te = 0; 
	public AudioSource ganaste;
	public AudioSource error;
	public AudioSource correcto;
	public AudioSource debesmenos;
	public AudioSource concepto;
	// Use this for initialization
	void Start () {
		datob = GameObject.FindGameObjectWithTag("Datos");
		dat = datob.GetComponent<datos> ();
		deuda = dat.deuda;
		dinero = dat.dinero;
	}
	
	// Update is called once per frame
	void Update () {
		di1 = Vector3.Distance (i1.position, ingreso.position);
		di2 = Vector3.Distance (i2.position, ingreso.position);
		di3 = Vector3.Distance (i3.position, ingreso.position);
		di4 = Vector3.Distance (i4.position, ingreso.position);

		de1 = Vector3.Distance (e1.position, egreso.position);
		de2 = Vector3.Distance (e2.position, egreso.position);
		de3 = Vector3.Distance (e3.position, egreso.position);
		de4 = Vector3.Distance (e4.position, egreso.position);
		de5 = Vector3.Distance (e5.position, egreso.position);

		bi1= verificacion (di1);
		bi2=verificacion (di2);
		bi3=verificacion (di3);
		bi4=verificacion (di4);


		be1=verificacion (de1);
		be2=verificacion (de2);
		be3=verificacion (de3);
		be4=verificacion (de4);
		be5=verificacion (de5);
		if (be1 ) {
			q1.SetActive(false);

		}
		if (be2) {
			q2.SetActive(false);
		}
		if (be3) {
			q3.SetActive(false);
		}
		if (be4) {
			q4.SetActive(false);
		}
		if (be5) {
			q5.SetActive(false);
		}
		if (bi1) {
			a1.SetActive(false);
		}
		if (bi2) {
			a2.SetActive(false);
		}
		if (bi3) {
			a3.SetActive(false);
		}
		if (bi4) {
			a4.SetActive(false);
		}

		if (bi1 && bi2 && bi3 && bi4 && be1 && be2&& be3 && be4 && be5 &&(te < 1)) {
			texto.text = "GANASTE";


			te++;
			StartCoroutine(gano ());
		}
	}

	bool verificacion(float d){
		
		if (d < radio) {
			return true;
		}
		else
			return false;
	}
	public void inicio(){
		Application.LoadLevel ("Inicio");
	}
	public IEnumerator gano(){
		NotificationCenter.DefaultCenter ().PostNotification (this, "incrementarDinero", 100);
		NotificationCenter.DefaultCenter ().PostNotification (this, "menosdeuda",35);
		ganaste.Play();
		yield return new WaitForSeconds (1.5f);
		concepto.Play ();
		yield return new WaitForSeconds (5.5f);
		if (deuda > 0) {
			debesmenos.Play ();
		}
		yield return new WaitForSeconds (1f);

	}
}
