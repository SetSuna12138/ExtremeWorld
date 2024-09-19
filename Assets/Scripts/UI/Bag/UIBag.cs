using Managers;
using Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBag : UIWindows
{
    public Text money;
    public Transform[] pages;
    public GameObject bagItem;

    List<Image> slots;

    void Start()
    {
        if (slots == null)
        {
            slots = new List<Image>();
            for (int page = 0; page < pages.Length; page++)
            {
                //Add AddRange
                slots.AddRange(this.pages[page].GetComponentsInChildren<Image>(true));
            }
        }
        StartCoroutine(InitBags());
    }

    IEnumerator InitBags()
    {
        for (int i = 0; i < BagManager.Instance.Items.Length; i++)
        {
            var item = BagManager.Instance.Items[i];
            if (item.ItemId > 0)
            {
                GameObject go = Instantiate(bagItem, slots[i].transform);
                var ui = go.GetComponent<UIIconItem>();
                var def = ItemManager.Instance.Items[item.ItemId].Define;
                ui.SetMainIcon(def.Icon,item.Count.ToString());
            }
            
        }

        for(int i =BagManager.Instance.Items.Length - 1;i<slots.Count;i++)
        {
            slots[i].color = Color.gray;
        }
        yield return null;
    }

    void Clear()
    {
        for(int i = 0; i < slots.Count; i++)
        {
            if (slots[i].transform.GetChild(0).gameObject)
            {
                Destroy(slots[i].transform.GetChild(0).gameObject);
            }
        }
    }


    public void OnReset()
    {
        BagManager.Instance.Reset();
        this.Clear();
        StartCoroutine(InitBags());
    }
}