using System.Collections.Generic;
using UnityEngine;

public class SheepGroupManager : MonoBehaviour
{
    public static SheepGroupManager Instance { get; private set; }

    private List<SheepController> sheepGroup = new List<SheepController>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddSheepToGroup(SheepController sheep)
    {
        if (!sheepGroup.Contains(sheep))
        {
            sheepGroup.Add(sheep);
        }
    }

    public void MoveGroup(Vector3 newPosition)
    {
        for (int i = 0; i < sheepGroup.Count; i++)
        {
            Vector3 offset = new Vector3(i, 0, 0); 
            sheepGroup[i].transform.position = newPosition + offset;
        }
    }
}
