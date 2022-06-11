using UnityEngine;
using System.Collections;

public class nivelactual : MonoBehaviour {
	public int numeronivel;
	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter ().AddObserver (this,"superado");
	}

	public void superado(Notification noti){
		if(numeronivel > PlayerPrefs.GetInt("nivelsuperado"))
		PlayerPrefs.SetInt ("nivelsuperado", numeronivel);
	}
	// Update is called once per frame
	void Update () {
	
	}
}
