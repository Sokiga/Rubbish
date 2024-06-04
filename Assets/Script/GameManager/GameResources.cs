using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class GameResources : MonoBehaviour
{
    private static GameResources instance;

    public static GameResources Instance
    {
        get
        {
            if (instance == null)
            {
                instance = Resources.Load<GameResources>("GameResources");
            }
            return instance;
        }
    }

    public List<BuffDataSO> buffDataSOs = new List<BuffDataSO>();

}
