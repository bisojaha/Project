using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartUI_MG : MonoBehaviour
{
    CanvasGroup[] groups;
    CanvasGroup allGroups;
    TMP_InputField[] fields;
    List<string> checkNull;

    void Awake()
    {
        groups = GetComponentsInChildren<CanvasGroup>();
        fields = GetComponentsInChildren<TMP_InputField>();
        foreach (CanvasGroup cg in groups)
        {
            allGroups = cg;
            // if (cg.name == transform.name) return;
            cg.alpha = 0;
            cg.blocksRaycasts = false;
        }
        checkNull = new List<string>();
        for (int i = 0; i < fields.Length; i++)
        {
            checkNull.Add(fields[i].text);
        }
    }

    void Start()
    {
        groups[0].alpha = 1;
        groups[0].blocksRaycasts = true;
        groups[1].alpha = 1;
        groups[1].blocksRaycasts = true;
    }

    void Update()
    {
    }

    public void Click_ID()
    {
        if (fields[0].text == checkNull[0])
        {
            return;
        }
        else
        {
            PhotonMG.instance.m_userID = fields[0].text;
            groups[1].alpha = 0;
            groups[1].blocksRaycasts = false;
            groups[2].alpha = 1;
            groups[2].blocksRaycasts = true;
        }
    }

    public void Click_Drone()
    {
        groups[2].alpha = 0;
        groups[2].blocksRaycasts = false;
        groups[3].alpha = 1;
        groups[3].blocksRaycasts = true;
        PhotonMG.instance.Click_Connect();
    }
    public void Click_JoinRoom()
    {
        PhotonMG.instance.Click_JoinRoom();
    }
    public void Click_CreateRoom()
    {
        groups[3].alpha = 0.1f;
        groups[3].blocksRaycasts = false;
        groups[4].alpha = 1;
        groups[4].blocksRaycasts = true;
    }
    public void Click_Create()
    {
        if (fields[1].text == checkNull[1])
        {
            return;
        }
        else
        {
            PhotonMG.instance.m_roomName = fields[1].text;
            PhotonMG.instance.Click_CreateRoom();
            Click_Close();
        }
    }
    public void Click_Close()
    {
        groups[4].alpha = 0;
        groups[4].blocksRaycasts = false;
        groups[3].alpha = 1;
        groups[3].blocksRaycasts = true;
    }
}