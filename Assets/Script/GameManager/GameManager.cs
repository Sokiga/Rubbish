using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMonobehaviour<GameManager>
{
    private void Start()
    {
        UIManager.Instance.ConversionSelectPanel();
        SelectedPanel.Instance.AddSelectCell();
    }
}
