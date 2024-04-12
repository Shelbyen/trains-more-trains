using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public static class TimeManager
{
    // This is really the only blurb of code you need to implement a Unity singleton
    private static int day = 1;
    private static int second;
    private static float time_scale = 1; //1 minute in seconds
    private static Dictionary<int, string> months = new Dictionary<int, string>()
    {
        {1, "€нвар€"}, 
        { 2, "феврал€"}, 
        { 3, "марта"}, 
        { 4, "апрел€"}, 
        { 5, "ма€"}, 
        { 6, "июн€"}, 
        { 7, "июл€"}, 
        { 8, "августа"}, 
        { 9, "сент€бр€"}, 
        { 10, "окт€бр€"}, 
        { 11, "но€бр€"}, 
        { 12, "декабр€"}
    };
    
    public static int GetDay()
    {
        return day;
    }

    public static int GetSecond()
    {
        return second;
    }

    public static string ReturnCurentDate()
    {
        int m = day / 28 + 1;
        return day % 28 + " " + months[m];
    }

    public static float Scale()
    {
        return time_scale;
    }

    public static void SetScale(float scale)
    {
        time_scale = scale;
    }

    public static void AddSecond()
    {
        second += 1;
        if (second == 1440)
        {
            second = 0;
            day += 1;
        }
    }

    public static string CalculateTime(int time)
    {
        int h = time / 60;
        int min = (time % 60);
        if (min.ToString().Length == 1) return h + ":" + "0" + min;
        else return h + ":" + min;
    }
    public static string ReturnCurent()
    {
        return CalculateTime(second);
    }
    public static string CalculateDate(int date)
    {
        int m = date / 28 + 1;
        return date % 28 + " " + months[m] + " 2024";
    }
}