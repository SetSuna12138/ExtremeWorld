using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITest : UIWindows
{
    public Text title;
	// Use this for initialization
	void Start () {
		
	}
	
	public void SetTitle(string text)
	{
		this.title.text = text;
	}
	// Update is called once per frame
	void Update () {
		
	}
}
