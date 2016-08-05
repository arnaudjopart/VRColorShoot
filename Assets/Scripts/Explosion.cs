using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

	// Use this for initialization
	void Start () {
        ps = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
        if( !ps.IsAlive() )
        {
            Destroy( gameObject );
        }
	}

    private ParticleSystem ps;

}
