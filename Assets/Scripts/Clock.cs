using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class Clock : MonoBehaviour
{
    private FlightGenerator generator;
    [SerializeField] private TextMeshProUGUI time;
    [SerializeField] private TextMeshProUGUI date;
    private float progress;

    private void Awake()
    {
        generator = FindObjectsOfType<FlightGenerator>()[0];
        StartCoroutine(Second());
    }

    private IEnumerator Second()
    {
        while (true)
        {
            yield return new WaitForFixedUpdate();
            progress += Time.fixedDeltaTime / TimeManager.Scale();
            if (progress >= 1)
            {
                TimeManager.AddSecond();
                time.text = TimeManager.ReturnCurent();
                date.text = TimeManager.ReturnCurentDate();
                progress = 0;
                generator.CheckTimepoint(TimeManager.GetSecond());
            }
        }
    }

    public void SetScale(float scale)
    {
        TimeManager.SetScale(scale);
    }
}
