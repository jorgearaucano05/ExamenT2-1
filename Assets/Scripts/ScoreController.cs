using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public Text ScoreText;
    public Text MOroText;
    public Text MBronceText;
    public Text MPlataText;
    
    // Start is called before the first frame update
    private int _score = 0;
    private int _oro = 0;
    private int _bronce = 0;
    private int _plata = 0;

    private void Start()
    {
        ScoreText.text = "PUNTAJE: " + _score;
        MOroText.text = "MONEDA ORO: " + _oro;
        MBronceText.text = "MONEDA BRONCE: " + _bronce;
        MPlataText.text = "MONEDA PLATA: " + _plata;
    }

    public int GetScore()
    {
        return this._score;
    }

    public void PlusScore(int score)
    {
        this._score += score;
        ScoreText.text = "PUNTAJE: " + _score;

    }
    
    public int GetOro()
    {
        return this._oro;
    }

    public void PlusOro(int oro)
    {
        this._oro += oro;
        MOroText.text = "MONEDA ORO: " + _oro;

    }
    public int GetBronce()
    {
        return this._bronce;
    }

    public void PlusBronce(int bronce)
    {
        this._bronce += bronce;
        MBronceText.text = "MONEDA BRONCE: " + _bronce;

    }
    public int GetPlata()
    {
        return this._plata;
    }

    public void PlusPlata(int plata)
    {
        this._plata += plata;
        MPlataText.text = "MONEDA PLATA: " + _plata;

    }
    
}
