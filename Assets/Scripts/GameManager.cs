using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    #region Public and protected Methods
    public enum STATE { START, PLAYING, GAME, PAUSE, END };
    public static float playTime = 5;
    public static float score;
    public UIManager m_uiIngameManager;
    public UIMainManager m_uiMainManager;
    public VRInput vrInput;

    public enum COLORCODE { RED,BLUE,YELLOW};

    public static COLORCODE currentColor;

    public static STATE currentState;

    static GameManager instance;
    
    #endregion

    void Awake()
    {
        instance = new GameManager();
    }

    // Use this for initialization
    void Start () {
        currentState = STATE.START;
	}
	
	// Update is called once per frame
	void Update () {
        if(currentState == STATE.PLAYING )
        {
            //print( "test" );
            if(Time.time - instance.timer > 1 )
            {
                instance.timer = Time.time;
                playTime--;
            }
            if( playTime <= 0 )
            {
                EndGame();
            }
        }
	}

    public static void LaunchGame()
    {
        ResetStaticGameVariables();
        print( "Launch game" );
        instance.timer = Time.time;
        currentState = STATE.PLAYING;
    }

    public void EndGame()
    {
        currentState = STATE.END;
        m_uiMainManager.Reset();
        m_uiIngameManager.Reset();

    }

    static void ResetStaticGameVariables()
    {
        playTime = 5;
        score = 0; 
    }
    public void SetShootColor(string color)
    {

    }
    #region Privates Variables
    private float timer;
    #endregion

}
