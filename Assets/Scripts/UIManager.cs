using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Multimeter multimeter;
    [SerializeField] private TextMeshProUGUI multimeterData;
    [SerializeField] private TextMeshProUGUI multimeterAspect_V;
    [SerializeField] private TextMeshProUGUI multimeterAspect_Omega;
    [SerializeField] private TextMeshProUGUI multimeterAspect_A;
    [SerializeField] private TextMeshProUGUI multimeterAspect_V1;
    
    void Update()
    {
        switch (multimeter.GetPosition())
        {
            case 0:
                multimeterData.text = "0";
                multimeterAspect_V.text = "V 0";
                multimeterAspect_Omega.text = "Ω 0";
                multimeterAspect_A.text = "A 0";
                multimeterAspect_V1.text = "V~ 0";
                break;
            
            case 1:
                var voltage = Math.Round(Math.Sqrt(multimeter.GetResistance() * multimeter.GetPower()), 2);
                multimeterData.text = $"{voltage}";
                multimeterAspect_V.text = $"V {voltage}";
                multimeterAspect_Omega.text = "Ω 0";
                multimeterAspect_A.text = "A 0";
                multimeterAspect_V1.text = "V~ 0";
                break;
            
            case 2:
                multimeterData.text = "0.01";
                multimeterAspect_V.text = "V 0";
                multimeterAspect_Omega.text = "Ω 0";
                multimeterAspect_A.text = "A 0";
                multimeterAspect_V1.text = "V~ 0.01";
                break;
            
            case 3:
                var amperage = Math.Round(Math.Sqrt(multimeter.GetPower() / multimeter.GetResistance()), 2);
                multimeterData.text = $"{amperage}";
                multimeterAspect_V.text = "V 0";
                multimeterAspect_Omega.text = "Ω 0";
                multimeterAspect_A.text = $"A {amperage}";
                multimeterAspect_V1.text = "V~ 0";
                break;
            
            case 4:
                multimeterData.text = $"{multimeter.GetResistance()}";
                multimeterAspect_V.text = "V 0";
                multimeterAspect_Omega.text = $"Ω {multimeter.GetResistance()}";
                multimeterAspect_A.text = "A 0";
                multimeterAspect_V1.text = "V~ 0";
                break;
        }
    }

}
