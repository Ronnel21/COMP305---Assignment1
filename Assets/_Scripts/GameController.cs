using UnityEngine;
using System.Collections;
// needed for UI elements
using UnityEngine.UI;
// needed for switching scenes
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	//Private Instances 
	private int _scoreValue = 0;
	private int _livesValue = 5;
	private AudioSource _gameOverSound;

	//Public Instances
	public int badCloudNumber = 3;
	public GameObject badCloud;
	public Text LivesLabel;
	public Text ScoreLabel;
	public Text GameOverLabel;
	public Text FinalScoreLabel;
	public Button RestartButton;
	public GameObject PlayerShip;
    public GameObject GoodCloud;    


	//Public Properties
	public int ScoreValue {
		get {
			return this._scoreValue;
		}

		set {
			this._scoreValue = value;
			this.ScoreLabel.text = "Score: " + this._scoreValue;
		}
	}

	public int LivesValue {
		get {
			return this._livesValue;
		}

		set {
			this._livesValue = value;
            // end the game
			if (this._livesValue <= 0) {
				this._endGame ();
			} else {
				this.LivesLabel.text = "Lives: " + this._livesValue;
			}
		}
	}

	// Use this for initialization
	void Start () {
		this._gameOverSound = this.GetComponent<AudioSource> ();
		this.GameOverLabel.gameObject.SetActive (false);
		this.FinalScoreLabel.gameObject.SetActive (false);
		this.RestartButton.gameObject.SetActive (false);

		// repeat the number of bad clouds
		for (int badCloudCount= 0; badCloudCount < this.badCloudNumber; badCloudCount++) {
			Instantiate (this.badCloud);
		}
	}
	
	// Update is called once per frame
	void Update () {

	}

    //Check what is on when 'endGame' is reached
	private void _endGame() {
		this.PlayerShip.SetActive (false);
        this.GoodCloud.SetActive(false);
		this.LivesLabel.gameObject.SetActive (false);
		this.ScoreLabel.gameObject.SetActive (false);		
		this.GameOverLabel.gameObject.SetActive (true);
        this._gameOverSound.Play ();
		this.FinalScoreLabel.text = "Final Score: " + this.ScoreValue;
		this.FinalScoreLabel.gameObject.SetActive (true);
		this.RestartButton.gameObject.SetActive (true);
	}

	//Public Methods
    //Switch scenes
	public void RestartButton_Click() {
		SceneManager.LoadScene ("Game"); 
	}
}
