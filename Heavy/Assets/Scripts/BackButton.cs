using Unity.VisualScripting;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void DeleteAllMessages()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Message");

        foreach (GameObject obj in objs)
        {
            Destroy(obj);
        }
    }



}
