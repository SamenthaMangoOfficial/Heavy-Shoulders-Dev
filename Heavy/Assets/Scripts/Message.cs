using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Message 
{
    public string Sender { get; set; }
    public string Text { get; set; }

    //You should probably change this to a ENUM so you can simplify the method.

    public static List<Message> MessagesList;

    [SerializeField] private ContactManager contactManager;

    public static List<Message> FillMessageList(Contact c)
    {
        TextAsset jsonFile = Resources.Load<TextAsset>($"Chat_{c.name}");
        if (jsonFile == null)
        {
            Debug.LogError($"Chat_{c.name}.json not found in Resources!");
        }
        else
        {
            MessagesList = JsonConvert.DeserializeObject<List<Message>>(jsonFile.text);
            
        }
        return MessagesList;

    }
    //NEW MESSAGES SHOULD BE TRIGGERED FROM THE TIME / DAY FREMONT IS IN.
    //THEREFOR, THE PROGRAM SHOULD CHECK AT EVERY HOUR WETHER THERES A MESSAGE WITHIN
    //THAT TIME INSIDE THE JSON FILE (WITH timestamp)

}
