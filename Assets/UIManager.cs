using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    #region Public and Protected Members
    public Text m_scoreTExt, m_timerText;
    #endregion


    // Use this for initialization
    void Start () {
        m_anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

        switch( GameManager.currentState )
        {
            case GameManager.STATE.START:
                break;
            case GameManager.STATE.PLAYING:
                m_timerText.text = "<color=red>T</color>imer: "+GameManager.playTime.ToString()+" seconds";
                m_scoreTExt.text = "<color=red>S</color>core: "+ GameManager.score.ToString()+" points";
                break;
            case GameManager.STATE.GAME:
                
                break;
            case GameManager.STATE.PAUSE:
                break;
            case GameManager.STATE.END:
                break;
            default:
                break;
        }

        
	}
    public void Reset()
    {
        m_anim.SetTrigger( "MoveOutTrigger" );
    }

    private Animator m_anim;

}
