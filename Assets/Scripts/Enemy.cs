using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {


    public VRInteractiveElement m_interactive;
    

    public bool m_isActive = false;
    public float m_forceAtLaunch = 10;
    // Use this for initialization
    void Awake()
    {
        m_rb = GetComponent<Rigidbody>();
        m_transform = GetComponent<Transform>();
        gameObject.SetActive( false );

        m_interactive.OnClickEvent += HandleClick; 

    }
    void Start () {
        print( "Launch" );
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void LaunchAt(Vector3 positionOfSpawn)
    {
        m_isActive = true;
        gameObject.SetActive( true );
        m_transform.position = positionOfSpawn;
        m_rb.AddForce( Vector3.up * m_forceAtLaunch, ForceMode.Impulse );
        Quaternion rotation = Quaternion.LookRotation(Vector3.zero);
        m_transform.rotation = rotation;
    }

    private void HandleClick()
    {
        print( "die" );
        Destroy( gameObject );
    }

    private Rigidbody m_rb;
    private Transform m_transform;
}
