using UnityEngine;
using System.Collections;
using System;

public class Enemy : MonoBehaviour {

    #region Public and Protected Members
    public VRInteractiveElement m_interactive;
    public GameObject m_explosion;
    public Material[] m_listOfColors;
    public MeshRenderer m_meshRenderer;
    public TargetUI m_targetUI;

    static int nbOfLaunch;

    public bool m_isActive = false;
    public float m_forceAtLaunch = 10;

    private GameManager.COLORCODE color;
    #endregion

    #region Main Methods

    void Awake()
    {
        m_rb = GetComponent<Rigidbody>();
        
        m_transform = GetComponent<Transform>();
        gameObject.SetActive( false );

        m_interactive.OnClickEvent += HandleClick;

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LaunchAt(Vector3 positionOfSpawn)
    {

        if( nbOfLaunch > 5 )
        {
            m_targetUI.HideText();
        }
        
        nbOfLaunch++;

        var values = Enum.GetValues(typeof(GameManager.COLORCODE));
        int rnd = UnityEngine.Random.Range(0,values.Length);
        color = (GameManager.COLORCODE)values.GetValue( rnd );

        switch( color )
        {
            case GameManager.COLORCODE.RED:
                m_meshRenderer.material = m_listOfColors[ 0 ];
                break;
            case GameManager.COLORCODE.BLUE:
                m_meshRenderer.material = m_listOfColors[ 1 ];
                break;
            case GameManager.COLORCODE.YELLOW:
                m_meshRenderer.material = m_listOfColors[ 2 ];
                break;
            default:
                break;
        }
        m_isActive = true;
        gameObject.SetActive( true );
        m_transform.position = positionOfSpawn;
        float forceModifier = UnityEngine.Random.value*2;
        m_rb.AddForce( Vector3.up * m_forceAtLaunch, ForceMode.Impulse );
        //Quaternion rotation = Quaternion.LookRotation(Vector3.zero);
        //m_transform.rotation = rotation;
    }

    private void HandleClick()
    {
        //if(m_currentColorGameManager.score++;
        GameObject explosion = Instantiate(m_explosion,m_transform.position,Quaternion.identity) as GameObject;
        Reset();
    }

    public void Reset()
    {
        

        m_isActive = false;
        m_rb.velocity = Vector3.zero;
        gameObject.SetActive( false );
    }
    #endregion

    // Use this for initialization


    #region Privates Variables
    private Rigidbody m_rb;
    private Transform m_transform;
    private Renderer m_renderer;

    #endregion


    
}
