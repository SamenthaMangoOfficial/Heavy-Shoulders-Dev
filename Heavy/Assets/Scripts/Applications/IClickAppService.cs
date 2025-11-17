using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IClickAppService : MonoBehaviour
{
    private GameObject AppUIContainer;
    [SerializeField] List<GameObject> UiPrefabList;
    private GameObject SelectedPrefab;
    void Start()
    {
        AppUIContainer = GameObject.Find("AppUiContainer");
    }


    private static readonly Dictionary<EnumApp, IClickApp> Strategies = new()
    {
        [EnumApp.Messages] = new ClickAppMessages(),
        [EnumApp.Photos] = new ClickAppPhotos(),
        [EnumApp.Maps] = new ClickAppMaps(),
        [EnumApp.Weather] = new ClickAppWeather(),
        [EnumApp.Calendar] = new ClickAppCalendar(),
        [EnumApp.Mail] = new ClickAppMail(),
        [EnumApp.Camera] = new ClickAppCamera(),
        [EnumApp.Wallet] = new ClickAppWallet(),
        [EnumApp.Settings] = new ClickAppSettings(),
        [EnumApp.Music] = new ClickAppMusic(),
        [EnumApp.Exit] = new ClickAppExit()
    };

    public void SelectApplication()
    {
        string appName = transform.Find("AppName").GetComponent<TextMeshProUGUI>().text;

        if (Enum.TryParse(appName, out EnumApp result))
        {
            
            if (Strategies.TryGetValue(result, out var strategie))
            {
                if (result != EnumApp.Exit) 
                {
                    SelectedPrefab = UiPrefabList[(int)result];
                }

                strategie.ClickOnApplication(AppUIContainer, SelectedPrefab);
            }

        }
        else
        {
            Debug.LogWarning("Invalid enum: " + appName);
        }
    }

}



