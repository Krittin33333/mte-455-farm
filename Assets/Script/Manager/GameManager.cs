using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private int day = 0;
    public int Day { get { return day; } set { day = value; } }

    [SerializeField] private float dayTimer = 0f;
    [SerializeField] private float secondsPerDay = 5f;

     void Awake()
    {
        instance = this;
    }
     void Update()
    {
        CheckTimeForDay();
    }
    private void CheckTimeForDay()
    {
        dayTimer += Time.deltaTime;

        if (dayTimer > secondsPerDay)
        {
            dayTimer = 0f;
            day++;
            MainUI.instance.UpdateDayText();
            TechManager.instance.CheckAllResearch();
            MainUI.instance.UpdateTechBtns();
        }
    }
}
