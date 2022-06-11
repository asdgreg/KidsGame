using UnityEngine;
using System.Collections;

public class PremiosGlobos : MonoBehaviour {

	public GameObject[] premios;

	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter().AddObserver(this, "GenerarPremio");
	}
	void GenerarPremio(Notification notificacion){
		GameObject premio = premios [Random.Range (0, premios.Length)];
		Instantiate(premio, (Vector3)notificacion.data, Quaternion.identity);
		switch(premio.tag){
		case "Pc5":
			NotificationCenter.DefaultCenter().PostNotification(this, "AumentarPuntuacion", 5);
			break;
		case "Pc10":
			NotificationCenter.DefaultCenter().PostNotification(this, "AumentarPuntuacion", 10);
			break;
		case "Pc20":
			NotificationCenter.DefaultCenter().PostNotification(this, "AumentarPuntuacion", 20);
			break;
		case "Pc100":
			NotificationCenter.DefaultCenter().PostNotification(this, "AumentarPuntuacion", 100);
			break;
		case "Pc500":
			NotificationCenter.DefaultCenter().PostNotification(this, "AumentarPuntuacion", 500);
			break;
		case "Pc1000":
			NotificationCenter.DefaultCenter().PostNotification(this, "AumentarPuntuacion", 600);
			break;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
