using UnityEngine;
using System.Collections;

public class ScriptHudPinata : MonoBehaviour {

	public TextMesh puntuacion;
	public GameObject piggiCoinsVuelan;
	public GameObject P1;
	public GameObject P2;

	private int golpesPrecisos = 1;
	private bool animPigi = false;
	private int puntuacionActual = 0;

	// Use this for initialization
	void Start () {
		int rnd = Random.Range (0, 2);
		if (rnd == 1) {
			P1.SetActive(true);
		}else
			P2.SetActive(true);

		NotificationCenter.DefaultCenter ().AddObserver (this, "AumentarPuntuacion");
	}

	void AumentarPuntuacion(Notification notificacion){
		int puntos = (int)notificacion.data;
		puntuacionActual += puntos;
		if (puntos >= 40) {
			golpesPrecisos++;
			if((golpesPrecisos % 5) == 0){
				animPigi = true;
			}
		}
		puntuacion.text = "PC " + puntuacionActual.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		if (animPigi) {
			Instantiate(piggiCoinsVuelan, transform.position, Quaternion.identity);
			animPigi = false;
		}
	
	}
}
