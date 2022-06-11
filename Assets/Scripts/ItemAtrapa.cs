using UnityEngine;
using System.Collections;

public class ItemAtrapa : MonoBehaviour {

	public AudioClip itemSoundClip;
	public float itemSoundVolume = 1f;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter2D(Collider2D collide){
		if (collide.tag == "Player") {
			string tagActual = this.gameObject.tag;
			switch(tagActual){
			case "Rock":
				NotificationCenter.DefaultCenter().PostNotification(this, "DisminuyeIntento");
				AudioSource.PlayClipAtPoint(itemSoundClip, Camera.main.transform.position, itemSoundVolume);
				break;
			case "Pc5":
				NotificationCenter.DefaultCenter().PostNotification(this, "AumentarPuntuacion", 5);
				AudioSource.PlayClipAtPoint(itemSoundClip, Camera.main.transform.position, itemSoundVolume);
				break;
			case "Pc10":
				NotificationCenter.DefaultCenter().PostNotification(this, "AumentarPuntuacion", 10);
				AudioSource.PlayClipAtPoint(itemSoundClip, Camera.main.transform.position, itemSoundVolume);
				break;
			case "Pc20":
				NotificationCenter.DefaultCenter().PostNotification(this, "AumentarPuntuacion", 20);
				AudioSource.PlayClipAtPoint(itemSoundClip, Camera.main.transform.position, itemSoundVolume);
				break;
			case "Pc100":
				NotificationCenter.DefaultCenter().PostNotification(this, "AumentarPuntuacion", 100);
				AudioSource.PlayClipAtPoint(itemSoundClip, Camera.main.transform.position, itemSoundVolume);
				break;
			case "Pc500":
				NotificationCenter.DefaultCenter().PostNotification(this, "AumentarPuntuacion", 500);
				AudioSource.PlayClipAtPoint(itemSoundClip, Camera.main.transform.position, itemSoundVolume);
				break;
			case "Croqueta":
				NotificationCenter.DefaultCenter().PostNotification(this, "AumentarPuntuacion", 5);
				AudioSource.PlayClipAtPoint(itemSoundClip, Camera.main.transform.position, itemSoundVolume);
				break;
			}
		}
		if (collide.tag == "Suelo") {
			Destroy(gameObject);
		}
		Destroy (gameObject);
	}
}
