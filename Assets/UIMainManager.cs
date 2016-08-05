using UnityEngine;
using System.Collections;

public class UIMainManager : MonoBehaviour {

    public VRButtonBehavior m_startButton;
    public VRButtonBehavior m_creditsButton;

    // Use this for initialization
    void Start () {
        m_anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Reset()
    {
        ResetButtons();
        m_anim.SetTrigger( "returnToMainMenu" );

    }
    private void ResetButtons()
    {
        m_startButton.Reset();
        m_creditsButton.Reset();
    }

    private Animator m_anim;
}
