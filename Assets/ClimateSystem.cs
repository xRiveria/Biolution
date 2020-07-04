using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClimateSystem : MonoBehaviour
{
    [Header("Seasonal Information")]
    [SerializeField] private Seasons currentSeason;
    private enum Seasons { Spring = 0, Summer = 1, Autumn = 2, Winter = 3 }

    [Header("Yearly Information")]
    [SerializeField] private uint currentYear;

    [Header("Date Information")]
    [SerializeField] private uint currentDay;

    [Header("Time Information")]
    private float timeTicker;
    [SerializeField] private double secondTicker;
    [SerializeField] private int currentHour;
    [SerializeField] private int currentMinute;

    [Header("UI Information")]
    [SerializeField] Text timeInformationText;





    private void Awake()
    {
        currentSeason = Seasons.Spring;
        currentYear = 1;
        currentDay = 1;
        currentHour = 00;
        currentMinute = 00;
        secondTicker = 00.5f;

        timeInformationText.text = "Year " + currentYear.ToString() + ", " + "Day " + currentDay.ToString() + ", " + currentHour.ToString() + ":0" + currentMinute.ToString();
    }

    private void Update()
    {
        timeTicker += Time.deltaTime;

        if (timeTicker >= secondTicker)
        {
            currentMinute += 1;

            if (currentMinute == 60)
            {
                currentHour += 1;
                currentMinute = 0;
            }
            timeTicker = 0;

            if (currentMinute < 10)
            {
                timeInformationText.text = "Year " + currentYear.ToString() + ", " + "Day " + currentDay.ToString() + ", " + currentHour.ToString() + ":0" + currentMinute.ToString();
            }
            else
            {
                timeInformationText.text = "Year " + currentYear.ToString() + ", " + "Day " + currentDay.ToString() + ", " + currentHour.ToString() + ":" + currentMinute.ToString();
            }
        }
    }

}
