using UnityEngine;
using System.Collections;

public class PlayerShipController : MonoBehaviour {
	//Private Instance
	private Transform _transform;
	private AudioSource[] _sounds;	
	private AudioSource _Woo;
    private AudioSource _thunder;

	//Public Instances
	public GameController gameController;


	// Use this for initialization
	void Start () {
		this._transform = this.GetComponent<Transform> ();
		this._sounds = this.GetComponents<AudioSource> ();
		this._thunder = this._sounds [1];
		this._Woo = this._sounds [2];
	}
	
	// Update is called once per frame
	void Update () {
		this._move ();
	}

	//Move game object along x-axis with mouse	 
	private void _move() {
		this._transform.position = new Vector2 (Mathf.Clamp(Input.mousePosition.x - 320f,-290f, 290f), -175f);
	}

	private void OnTriggerEnter2D(Collider2D other) {
		
		if (other.gameObject.CompareTag ("GoodCloud")) {
			this.gameController.ScoreValue += 200;
            Debug.Log("GoodCloud Hit!");
			this._Woo.Play ();
		}

		if (other.gameObject.CompareTag ("BadCloud")) {
			this.gameController.LivesValue -= 1;
            Debug.Log("BadCloud Hit");
			this._thunder.Play ();
		}

	}
		
}
