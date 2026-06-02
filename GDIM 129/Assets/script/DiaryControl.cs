using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class DiaryControl : Singleton<DiaryControl>
{
    public List<GameObject> _diaryPagePrefabs = new List<GameObject>();
    public List<GameObject> _SpawnedDiaryPages = new List<GameObject>();
    private bool _DiaryOpen ;
    public GameObject ParentObject;
    private int _currentPageIndex = 0;

    private void Awake()
    {
        DaytimeControl.OnDaytimeChanged += AddDiaryPage;

    }



    

    public void OpeanDiary()
    {
        if(_DiaryOpen == false)
        {
            _DiaryOpen = true;
            gameObject.SetActive(true);

        }
        else
        {
            _DiaryOpen = false;
            gameObject.SetActive(false);
        }
    }
    void AddDiaryPage()
    {
        int index = DaytimeControl.Instance._Daytime - 1;
        GameObject newPage = Instantiate(_diaryPagePrefabs[index], ParentObject.transform);
        _SpawnedDiaryPages.Add(newPage);
        newPage.SetActive(false);

    }

    public void NextPage()
    {
        if (_SpawnedDiaryPages.Count == 0 || _SpawnedDiaryPages == null) return;
        _SpawnedDiaryPages[_currentPageIndex].SetActive(false);
        _currentPageIndex = (_currentPageIndex + 1) % _SpawnedDiaryPages.Count;
        _SpawnedDiaryPages[_currentPageIndex].SetActive(true);
    }

    public void PreviousPage()
    {
        if (_SpawnedDiaryPages.Count == 0 || _SpawnedDiaryPages == null) return;
        _SpawnedDiaryPages[_currentPageIndex].SetActive(false);
        _currentPageIndex = (_currentPageIndex - 1 + _SpawnedDiaryPages.Count) % _SpawnedDiaryPages.Count;
        _SpawnedDiaryPages[_currentPageIndex].SetActive(true);
    }
}

