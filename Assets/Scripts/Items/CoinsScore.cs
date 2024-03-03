using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinsScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private void Start()
    {
        SetScore();
    }
    public void SetScore()
    {
        _text.text = $"Ñoins: {PlayersMoney.moneyCount}";
    }
}
