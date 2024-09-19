using Common.Data;
using Managers;
using Services;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterObject : MonoBehaviour
{

    public int id;
    Mesh mesh = null;
    // Use this for initialization
    void Start()
    {
        this.mesh = this.GetComponent<MeshFilter>().sharedMesh;
    }

    // Update is called once per frame
    void Update()
    {

    }

#if UNITY_EDITOR
    void OnFramGizmos()
    {
        Gizmos.color = Color.green;
        if (this.mesh != null)
        {
            Gizmos.DrawWireMesh(this.mesh, this.transform.position + Vector3.up * this.transform.localScale.y * 5f, this.transform.rotation, this.transform.localScale);
        }
        UnityEditor.Handles.color = Color.red;
        UnityEditor.Handles.ArrowHandleCap(0, this.transform.position, this.transform.rotation, 1f, EventType.Repaint);
    }
#endif
    void OnTriggerEnter(Collider other)
    {
        PlayerInputController playerController = other.GetComponent<PlayerInputController>();
        if(playerController != null && playerController.isActiveAndEnabled)
        {
            TeleporterDefine td = DataManager.Instance.Teleporters[this.id];
            if(td == null)
            {
                Debug.LogFormat("TeleporterObject: Character [{0}] Enter Teleproter [{1}], But TeleproterDefine not existed", playerController.character.Info.Name, this.id);
                return;
            }
            Debug.LogFormat("TeleporterObject: Character [{0}] Enter Teleproter [{1}:{2}]", playerController.character.Info.Name, td.ID, td.Name);
            if(td.LinkTo > 0)
            {
                if (DataManager.Instance.Teleporters.ContainsKey(td.LinkTo))
                    MapService.Instance.SendMapTelePort(this.id);
                else
                    Debug.LogErrorFormat("Teleporter ID:{0} LinkID {1} error!",td.ID, td.LinkTo);
            }
        }
    }
}
