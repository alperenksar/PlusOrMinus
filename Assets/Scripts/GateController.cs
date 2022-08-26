using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GateController : MonoBehaviour
{

    [SerializeField] TMP_Text _gateNumberText = null;

    [SerializeField]
    private enum GateType
    {

        PositiveGate,

        NegativeGate,

    }

    [SerializeField] private GateType type;

    [SerializeField] private int _gateNumber = 0;

    void Start()
    {
        RandomGateNumber();
    }

    private void RandomGateNumber()
    {
        switch(type)
        {
            case GateType.PositiveGate:
                _gateNumber = Random.Range(1, 10);
                _gateNumberText.text = _gateNumber.ToString();
                break;

            case GateType .NegativeGate:
                _gateNumber = Random.Range(-10, -1);
                _gateNumberText.text = _gateNumber.ToString();
                break;


        }
    }

    public int GetGateNumber()
    {
        return _gateNumber;
    }

    
}
