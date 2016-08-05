using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    #region Public and Protected Members
    public Text m_scoreTExt, m_timerText;
    #endregion


    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {

        switch( GameManager.currentState )
        {
            case GameManager.STATE.START:
                break;
            case GameManager.STATE.PLAYING:
                m_timerText.text = "<color=red>T</color>imer: "+GameManager.playTime.ToString();
                m_scoreTExt.text = "<color=red>S</color>core: " + GameManager.score.ToString();
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
}
