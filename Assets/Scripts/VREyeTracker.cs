using UnityEngine;
using System.Collections;

public class VREyeTracker : MonoBehaviour {

    public Transform m_EyeCam;
    public LayerMask m_layerMask;
    public float m_maxDistance;
    public VRInput m_VRInput;

    public GameManager m_gameManager;
    public GameObject m_cursor;
    public Material m_hightligthMaterial;
    public Material[] m_listOfCursorMaterials;


    #region Main Methods

    // Use this for initialization
    void Start()
    {
        m_cursorMeshRender = m_cursor.GetComponent<MeshRenderer>();
        m_cursorMeshRender.material = m_listOfCursorMaterials[ 2 ];


    }

    void OnEnable()
    {
        m_VRInput.OnClickEvent += HandleClick;
    }

    // Update is called once per frame
    void Update()
    {

        switch( GameManager.currentState )
        {
            case GameManager.STATE.START:
                m_cursorMeshRender.material = m_listOfCursorMaterials[ 2 ];
                break;
            case GameManager.STATE.PLAYING:
                switch( GameManager.currentColor )
                {
                    case GameManager.COLORCODE.RED:
                        m_cursorMeshRender.material = m_listOfCursorMaterials[ 0 ];
                        break;
                    case GameManager.COLORCODE.BLUE:
                        m_cursorMeshRender.material = m_listOfCursorMaterials[ 1 ];
                        break;
                    case GameManager.COLORCODE.YELLOW:
                        break;
                    default:
                        break;
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



        Ray eyeRay = new Ray(m_EyeCam.position, m_EyeCam.forward);
        if( Physics.Raycast( eyeRay, out m_hit, m_maxDistance, m_layerMask ) )
        {
            VRInteractiveElement interactive = m_hit.collider.GetComponent<VRInteractiveElement>();
            if( interactive && interactive != m_lastInteractive )
            {
                interactive.OnOver();
                RemoveLastInteractive();
            }
            m_lastInteractive = interactive;
            m_currentInteractive = interactive;
        }
        else
        {
            if( m_lastInteractive )
            {
                m_lastInteractive.OnOut();
                RemoveLastInteractive();
            }           
            
            m_currentInteractive = null;
        }

    }

    private void HandleClick()
    {
        if( m_currentInteractive != null )
        {
            print( m_currentInteractive.name );
            m_currentInteractive.OnClick();
        }

        
    }
    private void HandleValidatek()
    {
        if( m_currentInteractive != null )
        {
            m_currentInteractive.OnValidate();
        }

    }
    #endregion

    #region Utils
    private void RemoveLastInteractive()
    {
        m_lastInteractive = null;
    }
    #endregion

    private RaycastHit m_hit;
    private VRInteractiveElement m_currentInteractive;
    private VRInteractiveElement m_lastInteractive;
    private MeshRenderer m_cursorMeshRender;
}
