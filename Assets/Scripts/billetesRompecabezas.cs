using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class billetesRompecabezas : MonoBehaviour {
	[SerializeField]
	private Transform puzzleField;
	[SerializeField]
	private Transform puzzleField2;
	[SerializeField]
	private GameObject imgO;
	[SerializeField]
	private GameObject imgO2;
	public GameObject datob;
	public datos dat;
	public int deuda;
	public int dinero;

	string[] billetes = {"1 Lempira O","2 Lempira O","5 Lempira O","10 Lempira O","20 Lempira O","50 Lempira O"};
	//string[] billetesBG = {"1 Lempira Or","2 Lempira Or","5 Lempira Or","10 Lempira Or","20 Lempira Or","50 Lempira Or"};//nombres billetes
	public Sprite[] spriteLoad;
	public List<SpriteRenderer> imgs = new List<SpriteRenderer>();
	public List<SpriteRenderer> imgs2 = new List<SpriteRenderer>();
	public SpriteRenderer fondobg;
	public List<Transform> posOriginales;
	public bool[] colocadas = {false,false,false,false,false,false,false,false,false,false,false,false}; 
	public AudioSource ganaste;
	public AudioSource debesmenos;
	public GameObject[] billetesBG;
	int ter = 0;
	public TextMesh finalizo;
	// Use this for initialization
	void cargaobjetos () {
		
		for (int i = 0; i < spriteLoad.Length; i++) {
			GameObject button = Instantiate(imgO);
			button.name = "" + i;
			button.transform.SetParent(puzzleField,false);
		}

//		for (int i = 0; i < spriteLoad.Length; i++) {
//			GameObject button = Instantiate(imgO2);
//			button.name = "" + i;
//			button.transform.SetParent(puzzleField2,false);
//		}
		
	}

	void Start () {

		int bran = Random.Range (0, billetes.Length);
		spriteLoad = Resources.LoadAll<Sprite> ("Sprites/Billetes/"+billetes[bran]);

		billetesBG[bran].SetActive(true);//Resources.Load<Sprite> ("Sprites/Billetes/"+billetesBG[bran]);
		//fondobg.sprite = fondobga;
		cargaobjetos ();
		GetButtons ();

		datob = GameObject.FindGameObjectWithTag("Datos");
		dat = datob.GetComponent<datos> ();
		deuda = dat.deuda;
		dinero = dat.dinero;

	}

	public void GetButtons(){
		GameObject[] objects = GameObject.FindGameObjectsWithTag ("imgRB");
		for(int i = 0; i < objects.Length ;i++){
			imgs.Add(objects[i].GetComponent<SpriteRenderer>());
			imgs[i].sprite = spriteLoad[i];
			//imgs[i].color = new Color32(255,255,255,50);
		}
//		GameObject[] objects2 = GameObject.FindGameObjectsWithTag ("imgRB2");
//		for(int i = 0; i < objects2.Length ;i++){
//			imgs2.Add(objects2[i].GetComponent<SpriteRenderer>());
//			imgs2[i].sprite = spriteLoad[i];
//		}


	}

	// Update is called once per frame
	void Update () {

		for (int i = 0; i < posOriginales.Count; i++) {
		if (Vector3.Distance(posOriginales[i].position,imgs[i].transform.position) <= 0.5)
				colocadas[i] = true;
		}

		if(colocadas[0]&&colocadas[1]&&colocadas[2]&&colocadas[3]&&colocadas[4]&&colocadas[5]&&colocadas[6]&&colocadas[7]&&colocadas[8]&&colocadas[9]&&colocadas[10]&&colocadas[11] && ter < 1){
			Debug.Log("Completado");
			ter++;
			StartCoroutine(gano());
		}
	}

	public IEnumerator gano(){
		NotificationCenter.DefaultCenter ().PostNotification (this, "incrementarDinero", 100);
		finalizo.text = "GANASTE";
		ganaste.Play();
		yield return new WaitForSeconds (2f);
		if (deuda > 0) {
			debesmenos.Play ();
			NotificationCenter.DefaultCenter ().PostNotification (this, "menosdeuda", 10);
		}
		yield return new WaitForSeconds (1f);
		
	}

	public void regresar(){
		Application.LoadLevel ("Inicio");
	}
}
