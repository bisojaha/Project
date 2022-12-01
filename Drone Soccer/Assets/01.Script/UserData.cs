using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UserData : MonoBehaviour
{
    [SerializeField]
    string[] m_userList;
    TMP_InputField field;

    void Awake()
    {
        field = transform.Find("InputField (TMP)_UserID").GetComponent<TMP_InputField>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void click_InputField()
    {
        UserID_Save();
    }

    void UserID_Save()
    {
        int index = 0;
        if (m_userList[0] == null)
        {
            m_userList[0] = field.text;
            index++;
        }
        else
        {
            m_userList[index] = field.text;
            index++;
        }
    }
}
