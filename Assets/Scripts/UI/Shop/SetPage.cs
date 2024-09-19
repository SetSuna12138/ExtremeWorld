using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetPage : MonoBehaviour {

	public ShopView shopView;

	public int pageIndex = 0;

	public void Start()
	{
		this.GetComponent<Button>().onClick.AddListener(OnClick);
	}

	public void OnClick()
	{
		if (this.shopView.changePage[0])
		{
			LastPage();

        }
		else
		{
			NextPage();
		}
	}


    public void NextPage()
	{
        shopView.SelectTab(shopView.index++);

    }

	public void LastPage()
	{
		shopView.SelectTab(shopView.index--);
	}
}
