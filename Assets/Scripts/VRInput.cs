using UnityEngine;
using System.Collections;
using System;

public class VRInput : MonoBehaviour {

    public event Action OnClickEvent;
    public event Action OnDoubleClickEvent;

    

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

                if( Input.GetMouseButtonDown( 0 ) )
                {

                    OnClick();
                }
                if( Input.GetAxis( "Mouse X" ) > .9f )
                {
                    GameManager.currentColor = GameManager.COLORCODE.BLUE;
                }
                if( Input.GetAxis( "Mouse X" ) < -.9f )
                {
                    GameManager.currentColor = GameManager.COLORCODE.RED;
                }

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
    public void OnClick()
    {
        if( OnClickEvent != null )
        {
            print( "click" );
            OnClickEvent();
        }

    }
}
