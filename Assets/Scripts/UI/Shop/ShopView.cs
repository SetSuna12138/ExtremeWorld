using Assets.Scripts.UI.Shop;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopView : MonoBehaviour
{

    public SetPage[] changePage;
    public GameObject[] View;
    public Number number;
    public int index = 0;

    public ShopView() 
    {
        number = new Number();
    }
    IEnumerator Start()
    {
        for (int i = 0; i < View.Length; i++)
        {
            this.changePage[i].shopView = this;
            this.changePage[i].pageIndex = i;
        }
        yield return new WaitForEndOfFrame();
        
        SelectTab(0);
    }
    public void SelectTab(int index)
    {
        if (index < 0) index += 3;
        if (index > 2) index -= 3;
        number.SetNumber(index);
        if (this.index != index)
        {
            for (int i = 0; i < View.Length; i++)
            {
                View[i].SetActive(i == index);

            }
        }
    }

}
