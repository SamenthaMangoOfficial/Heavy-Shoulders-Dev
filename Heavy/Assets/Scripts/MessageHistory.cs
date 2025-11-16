using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MessageHistory : MonoBehaviour
{
    private string Sender { get; set; }
    private string Text { get; set; }

    //You should probably change this to a ENUM so you can simplify the method.
    [SerializeField] private GameObject RecipientTextPrefab;
    [SerializeField] private GameObject FremontTextPrefab;
    [SerializeField] private GameObject ContactContainer;

    [SerializeField] private ContactManager contactManager;


    void Start()
    {
        contactManager.ContactClicked += ShowMessageHistory;
        contactManager.ContactClicked += FillMessageHistory;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FillMessageHistory(Contact c)
    {
        List<Message> MessagesList;
        MessagesList = Message.FillMessageList(c);

        foreach (Message txt in MessagesList) 
        {
            GameObject newMsg;
            if (txt.Sender.Equals("R"))
            {
                 newMsg = Instantiate(RecipientTextPrefab, transform);
            }
            else
            {
                 newMsg = Instantiate(FremontTextPrefab, transform);
            }

            TextMeshProUGUI txtContent = newMsg.transform.Find("MessageBubble/Text").GetComponent<TextMeshProUGUI>();
            txtContent.text = txt.Text;

        }
    }

    private void ShowMessageHistory(Contact c)
    {
        ContactContainer.SetActive(false);
    }


    }
