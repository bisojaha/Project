using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartUI_MG : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_ErrorMS;
    [SerializeField] CanvasGroup[] m_groups;
    TMP_InputField[] m_fields;
    List<string> m_checkNull;

    void Awake()
    {
        m_groups = GetComponentsInChildren<CanvasGroup>();
        m_fields = GetComponentsInChildren<TMP_InputField>();
        UI_off();
        m_checkNull = new List<string>();
        for (int i = 0; i < m_fields.Length; i++)
        {
            m_checkNull.Add(m_fields[i].text);
        }
    }

    void Start()
    {
        m_groups[0].alpha = 1;
        m_groups[0].blocksRaycasts = true;
        m_groups[1].alpha = 1;
        m_groups[1].blocksRaycasts = true;
    }

    public void Click_ID()
    {
        if (m_fields[0].text == m_checkNull[0])
        {
            StartCoroutine("ErrorMessage");
            m_ErrorMS.text = "Please enter the ID";
        }
        else
        {
            PhotonMG.instance.m_userID = m_fields[0].text;
            m_groups[1].alpha = 0;
            m_groups[1].blocksRaycasts = false;
            m_groups[2].alpha = 1;
            m_groups[2].blocksRaycasts = true;
        }
    }

    public void Click_Drone()
    {
        m_groups[2].alpha = 0;
        m_groups[2].blocksRaycasts = false;
        m_groups[3].alpha = 1;
        m_groups[3].blocksRaycasts = true;
        PhotonMG.instance.Click_Connect();
    }
    public void Click_JoinRoom()
    {
        PhotonMG.instance.Click_JoinRoom();
    }
    public void Click_CreateRoom()
    {
        m_groups[3].alpha = 0.1f;
        m_groups[3].blocksRaycasts = false;
        m_groups[4].alpha = 1;
        m_groups[4].blocksRaycasts = true;
    }
    public void Click_Create()
    {
        if (m_fields[1].text == m_checkNull[1])
        {
            StartCoroutine("ErrorMessage");
            m_ErrorMS.text = "Please enter the Room Name";
            return;
        }
        else
        {
            PhotonMG.instance.m_roomName = m_fields[1].text;
            PhotonMG.instance.Click_CreateRoom();
            UI_off();
        }
    }
    public void Click_Close()
    {
        m_groups[4].alpha = 0;
        m_groups[4].blocksRaycasts = false;
        m_groups[3].alpha = 1;
        m_groups[3].blocksRaycasts = true;
    }

    void UI_off()
    {
        foreach (CanvasGroup cg in m_groups)
        {
            cg.alpha = 0;
            cg.blocksRaycasts = false;
        }
    }


    IEnumerator ErrorMessage()
    {
        m_groups[5].alpha = 1;
        Debug.Log("ErrorMessage");
        yield return new WaitForSeconds(2f);
        m_groups[5].alpha = 0;
        Debug.Log("Off ErrorMessage");
    }
}