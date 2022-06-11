using UnityEngine;
using System.Collections;

public class ScriptCirculos : MonoBehaviour {

	public float tiempoReduccion = 5f;

	public AudioClip itemSoundClip;
	public float itemSoundVol;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		tiempoReduccion -= Time.deltaTime/4f;
		if (tiempoReduccion > 0 && transform.localScale.x > 0) {
			transform.localScale = new Vector3 (transform.localScale.x - 0.006f,
			                                   transform.localScale.y - 0.006f,
			                                   transform.localScale.z - 0.006f);

		} else {
			Destroy(this.gameObject);		
		}
	
	}
	void OnMouseDown(){
		float radio = transform.localScale.x;
		AudioSource.PlayClipAtPoint (itemSoundClip, Camera.main.transform.position, itemSoundVol);
		NotificationCenter.DefaultCenter().PostNotification(this, "GolpeoPinata");
		if (radio > 0.9) {
			NotificationCenter.DefaultCenter ().PostNotification (this, "AumentarPuntuacion", 60);
		} else if (radio > 0.7) {
			NotificationCenter.DefaultCenter ().PostNotification (this, "AumentarPuntuacion", 40);
		} else if (radio > 0.5) {
			NotificationCenter.DefaultCenter ().PostNotification (this, "AumentarPuntuacion", 20);
		} else if (radio > 0.3) {
			NotificationCenter.DefaultCenter ().PostNotification (this, "AumentarPuntuacion", 5);
		} else {
			NotificationCenter.DefaultCenter ().PostNotification (this, "AumentarPuntuacion", 1);
		}

		Destroy (this.gameObject);
	}
}
