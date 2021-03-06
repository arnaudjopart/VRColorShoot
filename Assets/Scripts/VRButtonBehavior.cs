﻿using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

[RequireComponent( typeof( AudioSource ) )]

public class VRButtonBehavior : MonoBehaviour {

    public VRInteractiveElement m_interactive;
    public RectTransform m_fillRec;
    public RectTransform m_bgRect;
    public float m_timeToFill;
    public Color m_bgOutColor;
    public Color m_bgOverColor;
    public Color m_EndFillcolor;
    public Color m_startFillColor;
    public bool m_isCompleted;

    public static bool m_isValidate;
    public float m_speedOfFill;
    public float m_speedOfEmpty;

    public AudioClip m_validateSound;
    

    public virtual void Start()
    {
        m_audiSource = GetComponent<AudioSource>();        
    }
    public virtual void Update()
    {
        Vector2 sizeDelta = m_fillRec.sizeDelta;
        float width = sizeDelta.x;

        if( m_isGazeOn && !m_isCompleted && !m_isValidate)
        {          
            width += m_speedOfFill;
            
            if(width >= m_bgRect.sizeDelta.x )
            {
                m_isCompleted = true;
            }
        }
        if( !m_isGazeOn && !m_isValidate)
        {
            if( width > 0 )
            {
                width -= m_speedOfEmpty;
            }
        }
        
        sizeDelta.x = width;
        Color currentColor = Color.Lerp(m_startFillColor,m_EndFillcolor,width/m_bgRect.sizeDelta.x);
        m_fillRec.GetComponent<Image>().color= currentColor;
        
        m_fillRec.sizeDelta = sizeDelta;
    }

    public void Reset()
    {
        print( "reset" );
        m_fillRec.sizeDelta = new Vector2( 0, 15 );
        m_isValidate = false;
        m_isCompleted = false;
    }
    void OnEnable()
    {
        m_interactive.OnOverEvent += HandleOver;
        m_interactive.OnOutEvent += HandleOut;
        m_interactive.OnValidateEvent += HandleOut;
    }
    
    public virtual void HandleOver()
    {
        //Debug.Log( "On Over "+ m_interactive.name );
        m_isGazeOn = true;
        
    }

    public virtual void HandleOut()
    {
        //Debug.Log( "On Out " + m_interactive.name );
        m_isGazeOn = false;

    }

    public virtual void HandleValidation()
    {
        m_isValidate = true;
        m_audiSource.clip = m_validateSound;
        m_audiSource.Play();
        //Debug.Log( "Validate " + m_interactive.name );
    }

    
    private float m_currentFill;
    private AudioSource m_audiSource;
    
    public bool m_isGazeOn;
}
