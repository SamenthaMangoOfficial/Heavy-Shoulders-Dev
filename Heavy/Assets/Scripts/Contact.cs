using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Contact
{
    public string name { get; set; }
    public string lastMessageTime { get; set; }
    public string lastMessagePreview { get; set; }

    public static List<Contact> ContactsList;

    public Contact() { }

    public Contact(string contactName, string messageDateTime, string messagePreview)
    {
        name = contactName;
        lastMessageTime = messageDateTime;
        lastMessagePreview = messagePreview;
    }

    public static void GetContactFromFile()
    {

        TextAsset jsonFile = Resources.Load<TextAsset>("ContactList");
        if (jsonFile == null)
        {
            Debug.LogError("ContactList.json not found in Resources!");
            return;
        }

        ContactsList = JsonConvert.DeserializeObject<List<Contact>>(jsonFile.text);



    }

    public static string LimitTo(string s, int maxLength)
    {
        string text;
        if (string.IsNullOrEmpty(s)) return s;
        text = s.Length > maxLength ? s.Substring(0, maxLength) + "..." : s  ;
        return text;
    }

}
