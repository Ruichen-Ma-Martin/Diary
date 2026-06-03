using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class DiaryControl : Singleton<DiaryControl>
{
    //public List<GameObject> _diaryPagePrefabs = new List<GameObject>();
    //public List<GameObject> _SpawnedDiaryPages = new List<GameObject>();
    [SerializeField] private GameObject[] _DiaryPages;
    private bool _DiaryOpen ;
    public GameObject ParentObject;
    private int _currentPageIndex = 0;

    private void Awake()
    {
        //DaytimeControl.OnDaytimeChanged += AddDiaryPage;

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
    

    public void NextPage()
    {
        if (_DiaryPages.Length == 0 || _DiaryPages == null) return;
        _DiaryPages[_currentPageIndex].SetActive(false);
        _currentPageIndex = (_currentPageIndex + 1) % _DiaryPages.Length;
        _DiaryPages[_currentPageIndex].SetActive(true);
    }

    public void PreviousPage()
    {
        if (_DiaryPages.Length == 0 || _DiaryPages == null) return;
        _DiaryPages[_currentPageIndex].SetActive(false);
        _currentPageIndex = (_currentPageIndex - 1 + _DiaryPages.Length) % _DiaryPages.Length;
        _DiaryPages[_currentPageIndex].SetActive(true);
    }
}

