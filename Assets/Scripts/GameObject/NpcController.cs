using Assets.Scripts.Managers;
using Common.Data;
using Managers;
using Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController : MonoBehaviour
{

    SkinnedMeshRenderer renderer;
    private Animator ani;
    public int npcId;
    NpcDefine npc;
    Color orignColor;

    private bool inInterative = false;
    // Use this for initialization
    void Start()
    {
        renderer = this.GetComponentInChildren<SkinnedMeshRenderer>();
        ani = GetComponent<Animator>();
        npc = NPCManager.Instance.GetNpcDefine(npcId);

        orignColor = renderer.sharedMaterial.color;
        this.StartCoroutine(Action());
    }

    IEnumerator Action()
    {
        while (true)
        {
            if (inInterative)
            {
                yield return new WaitForSeconds(2f);
            }
            else
            {
                yield return new WaitForSeconds(Random.Range(5f, 10f));
            }
            
            this.Relax();
        }
    }

    void Relax()
    {
        ani.SetTrigger("Relax");
    }



    void OnMouseDown()
    {
        Interative();
    }

    void Interative()
    {
        if (!inInterative)
        {
            inInterative = true;
            StartCoroutine(DoInterative());
        }
    }

    IEnumerator DoInterative()
    {
        yield return FaceToPlayer();
        if (NPCManager.Instance.Interative(npc))
        {
            ani.SetTrigger("Talk");
        }
        yield return new WaitForSeconds(2f);
        inInterative = false;
    }

    IEnumerator FaceToPlayer()
    {
        Vector3 faceTo = (User.Instance.CurrentCharacterObjcet.transform.position - this.transform.position).normalized;
        if (Mathf.Abs(Vector3.Angle(this.transform.position, faceTo)) > 5)
        {
            this.gameObject.transform.forward = Vector3.Lerp(this.transform.forward, faceTo, Time.deltaTime * 5f);
            yield return null;
        }
    }

    private void OnMouseOver()
    {
        HighLight(true);
    }

    private void OnMouseEnter()
    {
        HighLight(true);
    }

    private void OnMouseExit()
    {
        HighLight(false);
    }

    private void HighLight(bool highLight)
    {
        if(highLight)
        {
            if(renderer.sharedMaterial.color != Color.white)
                renderer.sharedMaterial.color = Color.white;
        }
        else
        {
            if(renderer.sharedMaterial.color != orignColor)
                renderer.sharedMaterial.color = orignColor;
        }
    }
}
