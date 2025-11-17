using System;
using UnityEngine;

public class TimeCycle
{
   private String _currentDate;
   private String CurrentDate 
   {
        get => _currentDate;   
        set
        {
            DateTime parsed;

            if (DateTime.TryParse(value, out parsed))
                _currentDate = parsed.ToString("yyyy-MM-dd");
            else
                Debug.LogError("Invalid date format or value: " + value);
        }
    }
    private string _timeOfDay;

    public string timeOfDay
    {
        get => _timeOfDay;
        set
        {
            DateTime parsed;

            if (DateTime.TryParse(value, out parsed))
                _timeOfDay = parsed.ToString("HH:mm tt");
            else
                Debug.LogError("Invalid time format or value: " + value);
        }
    }






}
