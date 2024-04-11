using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class TimeManager
{
    // This is really the only blurb of code you need to implement a Unity singleton
    private static TimeManager _TimeManager;
    private int day = 1;
    private int second;
    private float time_scale = 1; //1 minute in seconds
    private Dictionary<int, string> months = new Dictionary<int, string>()
    {
        {1, "������"}, 
        { 2, "�������"}, 
        { 3, "�����"}, 
        { 4, "������"}, 
        { 5, "���"}, 
        { 6, "����"}, 
        { 7, "����"}, 
        { 8, "�������"}, 
        { 9, "��������"}, 
        { 10, "�������"}, 
        { 11, "������"}, 
        { 12, "�������"}
    };
    
    public int GetDay()
    {
        return day;
    }

    public string ReturnCurentDate()
    {
        int m = day / 28 + 1;
        return day % 28 + " " + months[m];
    }

    public float Scale()
    {
        return time_scale;
    }

    public void SetScale(float scale)
    {
        time_scale = scale;
    }

    public void AddSecond()
    {
        second += 1;
        if (second == 1440)
        {
            second = 0;
            day += 1;
        }
    }

    public string CalculateTime(int time)
    {
        int h = time / 60;
        int min = (time % 60);
        if (min.ToString().Length == 1) return h + ":" + "0" + min;
        else return h + ":" + min;
    }
    public string ReturnCurent()
    {
        return CalculateTime(second);
    }
    public string CalculateDate(int date)
    {
        int m = date / 28 + 1;
        return date % 28 + " " + months[m] + " 2024";
    }

    public static TimeManager TimeInstance()
    {
        if (_TimeManager == null)
            {
                _TimeManager = new TimeManager();
            }
            return _TimeManager;
    }
}