using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    [SerializeField] private Vector2 stopPosition;
    [SerializeField] private AnimationCurve animationCurve;
    [SerializeField] private bool isLeaving = false;
    [SerializeField] private bool isStop = false;

    // Update is called once per frame
    void Update()
    {
        if (isStop)
        {
            return;
        }

        if (!isLeaving)
        {
            transform.Translate(new Vector3(animationCurve.Evaluate(stopPosition.x - transform.position.x), 0));
            if (transform.position.x > stopPosition.x)
            {
                isLeaving = true;
                isStop = true;
                StartCoroutine(WaitPassengers());
            }
        }
        else
        {
            transform.Translate(new Vector3(animationCurve.Evaluate(transform.position.x - stopPosition.x), 0));
        }
    }

    private IEnumerator WaitPassengers()
    {
        yield return new WaitForSeconds(Random.Range(5, 15));
        isStop = false;
    }
}
