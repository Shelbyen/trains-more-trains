using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Van : MonoBehaviour
{
    [SerializeField] private int capacity = Random.Range(10, 50);
    [SerializeField] private int passengers;
}
