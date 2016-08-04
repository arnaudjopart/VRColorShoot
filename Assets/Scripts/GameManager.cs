using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    #region Public and protected Methods
    public enum STATE { START, PLAYING, GAME, PAUSE, END };

    static public STATE currentState;
    
    #endregion


    // Use this for initialization
    void Start () {
        currentState = STATE.START;
	}
	
	// Update is called once per frame
	void Update () {
        print( currentState );
	}

}
