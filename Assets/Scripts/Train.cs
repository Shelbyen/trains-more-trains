using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    [SerializeField] private int stopPosition;
    [SerializeField] private AnimationCurve animationCurve;
    [SerializeField] private bool isLeaving = false;
    [SerializeField] private bool isStop = false;
    [SerializeField] private int stopTime;

    private void Awake()
    {
        stopTime = Random.Range(5, 20);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isStop)
        {
            return;
        }

        if (!isLeaving)
        {
            transform.Translate(new Vector3(animationCurve.Evaluate(stopPosition - transform.position.x) * Time.fixedDeltaTime, 0));
            if (transform.position.x >= stopPosition)
            {
                isLeaving = true;
                isStop = true;
                StartCoroutine(WaitPassengers());
            }
        }
        else
        {
            transform.Translate(new Vector3(animationCurve.Evaluate(transform.position.x - stopPosition) * Time.fixedDeltaTime, 0));
        }
    }

    private IEnumerator WaitPassengers()
    {
        float progress = 0;
        while (progress <= stopTime)
        {
            yield return new WaitForFixedUpdate();
            progress += Time.fixedDeltaTime / TimeManager.TimeInstance().Scale();
        }
        isStop = false;
    }
}
