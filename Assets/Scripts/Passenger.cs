using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passenger : Human
{
    [SerializeField] private string flight;
    [SerializeField] private bool documents;
    [SerializeField] private int mood;
    [SerializeField] private int folly;

    private void Awake()
    {
        
    }

    //���� mood < 50 - ��� � ����� ��� ����
    //folly �������� �� ���� ��������� ���������
}
