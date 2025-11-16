using UnityEngine;

public class ClickAppMessages : IClickApp
{
    [SerializeField] private GameObject MessageUiPrefab;
    public void ClickOnApplication(GameObject AppUIContainer, GameObject UIprefab)
    {
        Debug.Log("AppUIContainer = " + AppUIContainer);
        Debug.Log("UIprefab = " + UIprefab);
        GameObject OpenApp = Object.Instantiate(UIprefab, AppUIContainer.transform);
    }
}
