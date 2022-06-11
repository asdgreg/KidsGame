using UnityEngine;
using System.Collections;

public class mascota : MonoBehaviour {
	int estado = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseDown(){
		StartCoroutine (accion());

	}
	public IEnumerator accion(){
		print (gameObject.tag.ToString ());
		if (gameObject.tag.ToString () == "perrop") {
			if(estado == 0){
				Animator anim = gameObject.GetComponent<Animator>();
				anim.SetBool("saltar",true);;
				yield return new WaitForSeconds (3f);
				anim.SetBool("saltar",false);
				estado = 1;
			}else{
				Animator anim = gameObject.GetComponent<Animator>();
				anim.SetBool("rascarse",true);;
				yield return new WaitForSeconds (3f);
				anim.SetBool("rascarse",false);
				estado = 0;
			}
		} else {
			if(estado == 0){
				Animator anim = gameObject.GetComponent<Animator>();
				anim.SetBool("salto",true);;
				yield return new WaitForSeconds (3f);
				anim.SetBool("salto",false);
				estado = 1;
			}else{
				Animator anim = gameObject.GetComponent<Animator>();
				anim.SetBool("lamer",true);;
				yield return new WaitForSeconds (3f);
				anim.SetBool("lamer",false);
				estado = 0;
			}
		}
	}
}
