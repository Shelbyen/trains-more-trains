using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    [SerializeField] public Transform stopPosition;
    [SerializeField] private AnimationCurve animationCurve;
    [SerializeField] private bool isLeaving = false;
    [SerializeField] private bool isStop = false;
    [SerializeField] public int stopTime;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isStop)
        {
            return;
        }

        if (!isLeaving)
        {
            transform.Translate(new Vector3(animationCurve.Evaluate(stopPosition.position.x - transform.position.x) * Time.fixedDeltaTime / TimeManager.Scale(), 0));
            if (transform.position.x >= stopPosition.position.x)
            {
                isLeaving = true;
                isStop = true;
                StartCoroutine(WaitPassengers());
            }
        }
        else
        {
            transform.Translate(new Vector3(animationCurve.Evaluate(transform.position.x - stopPosition.position.x) * Time.fixedDeltaTime / TimeManager.Scale(), 0));
        }
    }

    private IEnumerator WaitPassengers()
    {
        float progress = 0;
        while (progress <= stopTime)
        {
            yield return new WaitForFixedUpdate();
            progress += Time.fixedDeltaTime / TimeManager.Scale();
        }
        isStop = false;
    }
}
