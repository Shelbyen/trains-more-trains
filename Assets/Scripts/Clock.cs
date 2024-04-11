using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class Clock : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI time;
    [SerializeField] private TextMeshProUGUI date;
    private float progress;

    private void Awake()
    {
        StartCoroutine(Second());
    }

    private IEnumerator Second()
    {
        while (true)
        {
            yield return new WaitForFixedUpdate();
            progress += Time.fixedDeltaTime / TimeManager.TimeInstance().Scale();
            if (progress >= 1)
            {
                TimeManager.TimeInstance().AddSecond();
                time.text = TimeManager.TimeInstance().ReturnCurent();
                date.text = TimeManager.TimeInstance().ReturnCurentDate();
                progress = 0;
            }
        }
    }

    public void SetScale(float scale)
    {
        TimeManager.TimeInstance().SetScale(scale);
    }
}
