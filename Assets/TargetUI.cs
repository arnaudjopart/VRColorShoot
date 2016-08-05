using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TargetUI : MonoBehaviour {

    public Text m_shootMetext;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void HideText()
    {
        m_shootMetext.enabled = false;
    }
}
