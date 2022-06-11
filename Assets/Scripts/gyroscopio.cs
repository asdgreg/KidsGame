using UnityEngine;
using System.Collections;

public class gyroscopio : MonoBehaviour {
	public Transform camara;
	public Transform suelo;
	public Transform personaje;
	public TextMesh texto1;
	public TextMesh texto2;
	public TextMesh texto3;
	public TextMesh texto4;
	float x;
	float y;
	float z;
	float a;
	void Start()
	{
		Input.gyro.enabled = true; //Habilitar el giroscopio
	}
	
	void FixedUpdate ()
	{
		Debug.Log("Rotacion: "+Input.gyro.attitude); //Rotación del giroscopio
		Debug.Log("Aceleracion: "+Input.gyro.userAcceleration); //Aceleración del dispositivo
		Debug.Log("Gravedad: "+Input.gyro.gravity); //Gravedad  del dispositivo
		x = (Input.gyro.gravity.x) + x;//si funciona
		
		y = Input.gyro.gravity.y + y ;//cambiando a acelerometro
		
		texto1.text = "Aceleracion: "+Input.gyro.userAcceleration;
		texto2.text = "Gravedad: "+Input.gyro.gravity;
		texto3.text = "Rotacion: "+Input.gyro.attitude;
		texto4.text = z.ToString();
		
		transform.position = new Vector3 (x,1 , y-10);
		
		personaje.transform.position = new Vector3 (x,0,y);
		
		
	}
	
	
}

	
