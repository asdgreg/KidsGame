using UnityEngine;
using System.Collections;

public class ControladorPersonaje : MonoBehaviour {

	public float fuerzaSalto;
	public bool enSuelo = true;
	public Transform comprobadorSuelo;
	private float comprobadorRadio = 0.07f;
	public LayerMask mascaraSuelo;

	private bool dobleSalto = false;

	private Animator animator;

	public bool corriendo = false;
	public float velocidad = 1f;

	void Awake(){
		animator = GetComponent<Animator>();
	}

	// Use this for initialization
	void Start () {
	
	}

	void FixedUpdate(){
		if(corriendo){
			GetComponent<Rigidbody2D>().velocity = new Vector2(velocidad, GetComponent<Rigidbody2D>().velocity.y);
		}
		animator.SetFloat("VelX", GetComponent<Rigidbody2D>().velocity.x);
		enSuelo = Physics2D.OverlapCircle(comprobadorSuelo.position, comprobadorRadio, mascaraSuelo);
		animator.SetBool("isGrounded", enSuelo);
		if(enSuelo){
			dobleSalto = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){
			if(corriendo){
				// Hacemos que salte si puede saltar
				if(enSuelo || !dobleSalto){
					GetComponent<AudioSource>().Play();
					GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, fuerzaSalto);
					//rigidbody2D.AddForce(new Vector2(0, fuerzaSalto));
					if(!dobleSalto && !enSuelo){
						dobleSalto = true;
					}
				}
			}else{
				corriendo = true;
				NotificationCenter.DefaultCenter().PostNotification(this, "EmpiezaCorrer");
			}
		}
	}
}
