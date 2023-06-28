using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsManager : MonoBehaviour
{

    [SerializeField] MusicManger musicManger;
    [SerializeField] GameObject[] musicIcon;

    private void Start()
    {
        if(!GoToSceneScript.GetSound())
            UpdateValues();
    }

    public void OnMusicClick()
    {
        GoToSceneScript.ChangeSound();
        UpdateValues();
    }

    private void UpdateValues()
    {
        ChangeIcon();
        musicManger.UpdateMute();
    }

    private void ChangeIcon()
    {
        musicIcon[0].SetActive(!musicIcon[0].activeSelf);
        musicIcon[1].SetActive(!musicIcon[1].activeSelf);
    }

    public void CopyItchToClipbord()
    {
        UniClipboard.SetText("https://warguito.itch.io/xilogravura");
    }
}
