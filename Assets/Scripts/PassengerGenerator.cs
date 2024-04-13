using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassengerGenerator : MonoBehaviour
{
    public Transform spawnPos;
    public GameObject Pref;
    public GameObject baseTargetPlace;
    public FlightGenerator generator;

    private void Awake()
    {
        StartCoroutine(gener());
    }

    private IEnumerator gener()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            if (Random.Range(0, 10) == 1)
            {
                generator = GetComponent<FlightGenerator>();
                GameObject man = Instantiate(Pref, transform.parent);
                man.transform.position = spawnPos.position;
                Passenger passenger = man.GetComponent<Passenger>();
                passenger.SetTargetPlace(baseTargetPlace);
                passenger.Move(baseTargetPlace.transform.position);

            }
        }
    }
}
