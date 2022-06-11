using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class gamecontroller : MonoBehaviour {
	[SerializeField]
	private Sprite bgimage;

	public Sprite[] sprites;

	public List<Sprite> spritesPuzzle = new List<Sprite> ();


	public List<Button> btns = new List<Button>();
	public TextMesh terminado;
	public bool vista1, vista2 = false;
	public int countGuesses;
	public int countCorrectGuesses;
	public int gameguesses;
	public int firstguessIndex, secondguessIndex;
	public string firstguesspuzzle, secondguesspuzzle;
	public AudioSource correcto;
	public AudioSource ganaste;
	public AudioSource debesmenos;

	public GameObject datob;
	public datos dat;
	public int deuda;
	public int dinero;

	// Use this for initialization

	void Start () {
		GetButtons ();
		AddListeners ();
		sprites = Resources.LoadAll<Sprite> ("Sprites/Billetes/todosBilletes");
		agregandoboton ();
		varajar (spritesPuzzle);
		gameguesses = spritesPuzzle.Count / 2;

		datob = GameObject.FindGameObjectWithTag("Datos");
		dat = datob.GetComponent<datos> ();
		deuda = dat.deuda;
		dinero = dat.dinero;
	}

	public void GetButtons(){
		GameObject[] objects = GameObject.FindGameObjectsWithTag ("PuzzleButton");
		for(int i = 0; i < objects.Length ;i++){
			btns.Add(objects[i].GetComponent<Button>());
			btns[i].image.sprite = bgimage;
		}
	}
	void AddListeners(){
		for(int i = 0;i< btns.Count;i++){
			btns[i].onClick.AddListener(() => buttontomado());
		}
	}

	public void agregandoboton(){
		int loop = btns.Count;
		int index = 0;
		for(int i = 0; i < loop; i++){
			if(index >= loop/2){
				index = 0;
			}
			spritesPuzzle.Add(sprites[index]);
			index ++;
		}
	}

	public void buttontomado(){
		string nombre = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
		Debug.Log ("voy bien!" + nombre);

		if (!vista1) {
			vista1 = true;
			firstguessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
			firstguesspuzzle = spritesPuzzle[firstguessIndex].name;
			btns[firstguessIndex].image.sprite = spritesPuzzle[firstguessIndex];
		}else if(!vista2) {
			vista2 = true;
			secondguessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
			secondguesspuzzle = spritesPuzzle[secondguessIndex].name;
			btns[secondguessIndex].image.sprite = spritesPuzzle[secondguessIndex];
	
			StartCoroutine(puzzlesmatchs());
		
		}
	}

	IEnumerator puzzlesmatchs(){
		yield return new WaitForSeconds (0.5f);

		if (firstguesspuzzle == secondguesspuzzle) {
			yield return new WaitForSeconds (0.5f);

			btns [firstguessIndex].interactable = false;
			btns [secondguessIndex].interactable = false;

			btns [firstguessIndex].image.color = new Color (0, 0, 0, 0);
			btns [secondguessIndex].image.color = new Color (0, 0, 0, 0);

			NotificationCenter.DefaultCenter ().PostNotification (this, "incrementarDinero", 5);
			correcto.Play();
			checkgamefin ();
		} else {
			yield return new WaitForSeconds (0.5f);

			btns [firstguessIndex].image.sprite = bgimage;
			btns [secondguessIndex].image.sprite = bgimage;
		}
		//yield return new WaitForSeconds (0.5f);
		vista1 = false;
		vista2 = false;

	}

	void checkgamefin(){
		countCorrectGuesses++;

		if (countCorrectGuesses == gameguesses) {
			Debug.Log("juego terminado");
			terminado.text = "GANASTE";
			StartCoroutine(gano());
		}
	}

	void varajar(List<Sprite> spl){

		for (int i = 0; i < spl.Count; i++) {
			Sprite temp = spl[i];
			int ramdom = Random.Range(i,spl.Count);
			spl[i] = spl[ramdom];
			spl[ramdom] = temp;
		}
	}

	public IEnumerator gano(){
		NotificationCenter.DefaultCenter ().PostNotification (this, "incrementarDinero", 50);
		ganaste.Play();
		yield return new WaitForSeconds (2f);
		if (deuda > 0) {
			debesmenos.Play ();
			NotificationCenter.DefaultCenter ().PostNotification (this, "menosdeuda", 5);
		}
		yield return new WaitForSeconds (1f);
		
	}
	// Update is called once per frame
	void Update () {
	
	}
}
