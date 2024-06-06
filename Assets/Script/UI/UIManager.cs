using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : SingletonMonobehaviour<UIManager>
{
    public GameObject GamePanel;
    public GameObject StorePanel;
    public GameObject SelectPanel;

    public void ConversionGamePanel()
    {
        GamePanel.SetActive(true);
        StorePanel.SetActive(false);
        SelectPanel.SetActive(false);
    }

    public void ConversionStorePanel()
    {
        GamePanel.SetActive(false);
        StorePanel.SetActive(true);
        SelectPanel.SetActive(false);
    }

    public void ConversionSelectPanel()
    {
        GamePanel.SetActive(false);
        StorePanel.SetActive(false);
        SelectPanel.SetActive(true);
    }
}
