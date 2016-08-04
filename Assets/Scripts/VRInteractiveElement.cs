using UnityEngine;
using System.Collections;
using System;

public class VRInteractiveElement : MonoBehaviour {

    public event Action OnOverEvent;
    public event Action OnOutEvent;
    public event Action OnValidateEvent;
    public event Action OnClickEvent;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnOver()
    {
        if( OnOverEvent != null )
        {
            OnOverEvent();
        }
    }
    public void OnOut()
    {
        if( OnOutEvent != null )
        {
            OnOutEvent();
        }
    }
    public void OnValidate()
    {
        if( OnValidateEvent != null )
        {
            OnValidateEvent();
        }
    }
    public void OnClick()
    {
        if( OnClickEvent != null )
        {
            OnClickEvent();
        }
    }
}
