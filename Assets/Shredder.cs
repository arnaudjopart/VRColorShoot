using UnityEngine;
using System.Collections;

public class Shredder : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider e)
    {

        Enemy enemy = e.GetComponent<Enemy>();
        if( enemy )
        {
            enemy.Reset();
        }
        
    }
}
