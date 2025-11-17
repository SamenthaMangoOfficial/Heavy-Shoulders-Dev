using UnityEditor;
using UnityEngine;

public class ClickAppExit : IClickApp
{
    public void ClickOnApplication(GameObject AppUIContainer, GameObject UIprefab)
    {
        if (AppUIContainer.transform.childCount > 0)
        {
            Transform child = AppUIContainer.transform.GetChild(0);
            GameObject.Destroy(child.gameObject);
        }
    }
}
