using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class DiaryControl : Singleton<DiaryControl>
{
    public List<GameObject> _diaryPagePrefabs = new List<GameObject>();
    public List<GameObject> _SpawnedDiaryPages = new List<GameObject>();
    public bool _DiaryOpen = false;

    private void Awake()
    {
        DaytimeControl.Instance.OnDaytimeChanged += AddDiaryPage;
    }

    private void OnEnable()
    {
        if (!_DiaryOpen)
        {
            _DiaryOpen = true;
            Debug.Log("Diary opened.");
        }
    }
    private void OnDisable()
    {
        _DiaryOpen = false;
        Debug.Log("Diary closed.");
    }
    void AddDiaryPage()
    {
        int index = DaytimeControl.Instance._Daytime - 1;
        GameObject newPage = Instantiate(_diaryPagePrefabs[index]);
        _SpawnedDiaryPages.Add(newPage);

    }
}

