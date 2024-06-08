using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedPanel : SingletonMonobehaviour<SelectedPanel>
{
    public GameObject selectCellPrefab;
    public Transform selectPool;
    public List<SelectCellData> selectCellData = new List<SelectCellData>();
    public int Section = 0;

    public void AddSelectCell()
    {
        if (selectCellData.Count < 3) return;

        for (int i = 0; i < 3; i++)
        {
            SelectCell selectCell = Instantiate(selectCellPrefab, selectPool).GetComponent<SelectCell>();
            selectCell.Init(selectCellData[i]);
        }
        List<SelectCellData> dataToRemove = new List<SelectCellData>(selectCellData.GetRange(0, 3));
        selectCellData.RemoveAll(x => dataToRemove.Contains(x));
    }

    public void RemoveAll()
    {
        Transform[] transforms = selectPool.GetComponentsInChildren<Transform>();
        if (transforms.Length > 0)
        {
            foreach (Transform selectCell in transforms)
            {
                if (selectCell.parent == selectPool)
                {
                    Destroy(selectCell.gameObject);
                }
            }
        }
    }
}

[Serializable]
public class SelectCellData
{
    public int targetScore;
    public int technologyPoint;
}
