using UnityEngine;

public class ClickAppMaps : IClickApp
{
    public void ClickOnApplication(GameObject AppUIContainer, GameObject UIprefab)
    {
        GameObject OpenApp = Object.Instantiate(UIprefab, AppUIContainer.transform);

    }
}
