using UnityEngine;

public class ClickAppMessages : IClickApp
{
    public void ClickOnApplication(GameObject AppUIContainer, GameObject UIprefab)
    {
        GameObject OpenApp = Object.Instantiate(UIprefab, AppUIContainer.transform);
    }
}
