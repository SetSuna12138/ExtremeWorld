using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabView : MonoBehaviour
{
    public TabButton[] tabButton;
    public GameObject[] tabView;

    public int index = -1;

    IEnumerator Start()
    {
        for (int i = 0; i < tabButton.Length; i++)
        {
            tabButton[i].tabIndex = i;
            tabButton[i].tabView = this;
        }
        yield return new WaitForEndOfFrame();
        SelectTab(0);

    }
    public void SelectTab(int index)
    {
        if (this.index != index)
        {
            for (int i = 0; i < tabButton.Length; i++)
            {
                tabButton[i].Select(i == index);
                tabView[i].SetActive(i == index);
            }
        }
    }

}
