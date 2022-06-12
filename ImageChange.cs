using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageChange : MonoBehaviour
{
    Image m_Image;

    public void Start()
    {
        m_Image = GetComponent<Image>();
    }

    public void setWhite()
    {
        m_Image.color = Color.white;
    }
    public void setGreen()
    {
        m_Image.color = Color.green;
    }
    public void setRed()
    {
        m_Image.color = Color.red;
    }
}
