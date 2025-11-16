using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ContactManager : MonoBehaviour
{
    private const int Max_Preview_Length = 15;
    public event Action<Contact> ContactClicked;
    [SerializeField] private GameObject contactPrefab;
    private List<GameObject> ContactObjectList;

    void Start()
    {
        Contact.GetContactFromFile();
        loadContacts();
    }

    void Update()
    {
        
    }

    private void loadContacts()
    {
        List<Message> contactMessages;
        GameObject newContact;
        string lastMessage;
        
        foreach (Contact c in Contact.ContactsList)
        {
            
            newContact = Instantiate(contactPrefab, transform);

            Transform n = newContact.transform.Find("Contact_Name");
            Transform d = newContact.transform.Find("Time_Preview");
            Transform p = newContact.transform.Find("Message_Preview");

            TextMeshProUGUI name = n.GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI date = d.GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI preview = p.GetComponent<TextMeshProUGUI>();


            name.text = c.name;
            date.text = c.lastMessageTime;

            contactMessages = Message.FillMessageList(c);
            if (contactMessages!= null) 
            {
                lastMessage = contactMessages[contactMessages.Count - 1].Text;
                preview.text = Contact.LimitTo(lastMessage, Max_Preview_Length);
            }
            else
            {
                preview.text = "Start chatting!";
            }

            Button btn = newContact.GetComponent<Button>();
            btn.onClick.AddListener(() => OnContactClicked(c, btn.gameObject));

        }
    }

    private void UpdateContact(Contact c, GameObject newContact)
    {
        newContact.transform.SetSiblingIndex(0);
        LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)transform);
        Contact.ContactsList.Remove(c);
        Contact.ContactsList.Insert(0, c);
    }


    private void OnContactClicked(Contact c, GameObject newContact)
    {
        ContactClicked?.Invoke(c);
        UpdateContact(c, newContact);
    }

}