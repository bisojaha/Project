using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarChoice : MonoBehaviour
{
    public GameObject[] m_droneList;
    int m_index;
    int m_NextIndex;

    void Start()
    {

    }

    void Update()
    {

    }

    public void Click_Previous()
    {
        m_droneList[m_index].SetActive(false);
        if (m_index == 0)
        {
            m_index = m_droneList.Length - 1;
        }
        else
        {
            m_index--;
        }
        m_droneList[m_index].SetActive(true);
    }
    public void Click_Next()
    {
        m_droneList[m_index].SetActive(false);
        if (m_index == m_droneList.Length - 1)
        {
            m_index = 0;
        }
        else
        {
            m_index++;
        }
        m_droneList[m_index].SetActive(true);
    }
}
