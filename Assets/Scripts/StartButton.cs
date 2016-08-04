using UnityEngine;
using System.Collections;

public class StartButton : VRButtonBehavior {

    [Header ("Variables")]
    public GameObject m_canvas;


	// Use this for initialization
	public override void Start () {
        base.Start();
        m_canvasAnim = m_canvas.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	public override void Update () {
        base.Update();
        if( m_isCompleted )
        {
            HandleValidation();
        }
       
    }
    public override void HandleValidation()
    {
        if( m_isCompleted && !m_isValidate )
        {
            base.HandleValidation();
            GameManager.currentState = GameManager.STATE.PLAYING;
            m_canvasAnim.SetTrigger( "moveOutMenuTrigger" );
            
        }
    }
    public override void HandleOut()
    {
        base.HandleOut();

    }
    public override void HandleOver()
    {
        base.HandleOver();
        
    }

    private Animator m_canvasAnim;
}
