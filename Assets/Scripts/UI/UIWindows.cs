using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWindows : MonoBehaviour {

	public delegate void CloseHander(UIWindows sender, WindowsResult result);
	public event CloseHander OnClose;

    public virtual System.Type Type { get { return this.GetType(); } }
    public enum WindowsResult
	{
		None = 0,
		Yes,
		No,
	}
	

	public void Close(WindowsResult result = WindowsResult.None)
	{
		UIManager.Instance.Close(this.Type);
		if(this.OnClose != null)
			this.OnClose(this, result);
		this.OnClose = null;
	}

	public virtual void OnCloseClick()
	{
		this.Close();
	}

	public virtual void OnYesClick()
	{
		this.Close(WindowsResult.Yes);
	}
}
