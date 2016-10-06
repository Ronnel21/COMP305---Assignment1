using UnityEngine;
using System.Collections;

public class BadCloudController : MonoBehaviour {
    //Private Instances
    private int _speed;
    private int _drift;
    private Transform _transform;

    //Public Properties
    public int Speed
    {
        get
        {
            return this._speed;
        }
        set
        {
            this._speed = value;
        }
    }

    public int Drift
    {
        get
        {
            return this._drift;
        }
        set
        {
            this._drift = value;
        }
    }


    // Use this for initialization
    void Start()
    {
        this._transform = this.GetComponent<Transform>();
        this._reset();
    }

    // Update is called once per frame
    void Update()
    {
        this._move();
        this._checkBounds();
    }

    //Moves the game object down the screen	 
    private void _move()
    {
        Vector2 newPosition = this._transform.position;

        newPosition.y -= this.Speed;
        newPosition.x += this.Drift;

        this._transform.position = newPosition;
    }

    //Checks to see if the game object meets the top-border of the screen	 
    private void _checkBounds()
    {
        if (this._transform.position.y <= -330f)
        {
            this._reset();
        }
    }

    //Reset the gameObject to the original position
    private void _reset()
    {
        this.Speed = Random.Range(5, 10);
        this.Drift = Random.Range(-2, 2);
        this._transform.position = new Vector2(Random.Range(-205f, 205f), 330f);
    }
}
