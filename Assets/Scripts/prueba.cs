using UnityEngine;
using System.Collections;

public class prueba : MonoBehaviour {

	// Use this for initialization
	void Start () {
		print(PlayerPrefs.GetInt("Player Score"));
	}
	
	// Update is called once per frame
	void Update () {
		PlayerPrefs.SetInt ("Player Score",100);
	}
}
