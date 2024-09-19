using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabButton : MonoBehaviour
{

    public Sprite activeImage;
    private Sprite normalImage;

    public TabView tabView;
    public int tabIndex = 0;
    public bool selected = false;

    public Image image;

    void Start()
    {
        image = this.GetComponent<Image>();
        normalImage = image.sprite;

        this.GetComponent<Button>().onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        tabView.SelectTab(this.tabIndex);
    }

    public void Select(bool select)
    {
        image.overrideSprite = select ? activeImage : normalImage;
    }
}
