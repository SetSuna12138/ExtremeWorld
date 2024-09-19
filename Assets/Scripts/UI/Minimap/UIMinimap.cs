using Managers;
using Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMinimap : MonoBehaviour
{

    public Text mapName;
    public Image minimap;
    public Image arrow;
    public Collider minimapBoundingBox;
    public Transform playerTransform;
    // Use this for initialization
    void Start()
    {
        MinimapManager.Instance.minimap = this;
        UpdateMap();
    }

    public void UpdateMap()
    {
        this.mapName.text = User.Instance.CurrentMapData.Name;
        this.minimap.overrideSprite = MinimapManager.Instance.LoadCurrentMinimap();

        this.minimap.SetNativeSize();
        this.minimap.transform.localPosition = Vector3.zero;
        this.minimapBoundingBox = MinimapManager.Instance.MinimapBoundingBox;
        this.playerTransform = null;

    }

    // Update is called once per frames
    void Update()
    {
        if (playerTransform == null && User.Instance.CurrentCharacterObjcet != null)
        {
            this.playerTransform = User.Instance.CurrentCharacterObjcet.transform;
        }

        if (minimapBoundingBox == null || playerTransform == null)
            return;
        float realWidth = minimapBoundingBox.bounds.size.x;
        float realHeight = minimapBoundingBox.bounds.size.z;

        float realX = playerTransform.position.x - minimapBoundingBox.bounds.min.x;
        float realY = playerTransform.position.z - minimapBoundingBox.bounds.min.z;

        float pivotX = realX / realWidth;
        float pivotY = realY / realHeight;

        this.minimap.rectTransform.pivot = new Vector2(pivotX, pivotY);
        this.minimap.rectTransform.localPosition = Vector2.zero;
        this.arrow.transform.eulerAngles = new Vector3(0, 0, -playerTransform.eulerAngles.y);

    }
}
