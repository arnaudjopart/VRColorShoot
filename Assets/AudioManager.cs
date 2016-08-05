using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

    public AudioClip sound;
    // Use this for initialization
	void Start () {
        m_audioSource = GetComponent<AudioSource>();
        m_audioSource.clip = sound;
        m_audioSource.PlayDelayed( 1 );
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private AudioSource m_audioSource;
}
