using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Hub_LocationBtn : MonoBehaviour
{
    [SerializeField] private GameObject _hubPannel;
    [SerializeField] private GameObject _workPannel;
    [SerializeField] private GameObject _clubPannel;
    [SerializeField] private GameObject _gymPannel;
    [SerializeField] private GameObject _libaryPannel;



    [SerializeField] private Button _gymBtn;
    [SerializeField] private Button _workBtn;
    [SerializeField] private Button _libraryBtn;
    [SerializeField] private Button _clubBtn;


    List<GameObject> placePannels; //list of place pannels

    private void Start()
    {
        setupList();
        fn_ReturnToHub(); // set hub active and others false

    }
    private void Update()
    {
        _gymBtn.onClick.AddListener(goToGym);
        _workBtn.onClick.AddListener(goToWork);
        _libraryBtn.onClick.AddListener(goToLib);
        _clubBtn.onClick.AddListener(goToClub);
    }

    private void setupList()
    {
        placePannels = new List<GameObject>();
        placePannels.Add(_workPannel);
        placePannels.Add(_clubPannel);
        placePannels.Add(_gymPannel);
        placePannels.Add(_libaryPannel);
    }

    void goToGym()
    {
        Debug.Log("Went to Gym");
        EnableHubPannel(false);
        _gymPannel.SetActive(true);
    }
    void goToWork()
    {
        Debug.Log("Went to Work");
        EnableHubPannel(false);
        _workPannel.SetActive(true);
    }
    void goToLib()
    {
        Debug.Log("Went to Lib");
        EnableHubPannel(false);
        _libaryPannel.SetActive(true);
    }
    void goToClub()
    {
        Debug.Log("Went to Club");
        EnableHubPannel(false);
        _clubPannel.SetActive(true);
    }


    private void EnableHubPannel(bool enable)
    {
        _hubPannel.SetActive(enable);
    }

    private void disablePlacePannels()
    {
        foreach (var item in placePannels)
        {
            item.SetActive(false);
        }
    }

    public void fn_ReturnToHub()
    {
        EnableHubPannel(true);
        disablePlacePannels();
    }
}
