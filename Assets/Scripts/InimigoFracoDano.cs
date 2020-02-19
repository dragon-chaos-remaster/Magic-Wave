﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoFracoDano : MonoBehaviour
{


    Freezer freezing;
    TomaDano dano;
    public int dFogo;
    public int dRaio;
    public int dNaoSei;
    public int dAtaqueBasico;
    public int dFogoArea;

    public float duracaoSnare;
    Snared snare;
    // Start is called before the first frame update
    void Start()
    {
        snare = GetComponent<Snared>();
        dano = GetComponent<TomaDano>();
    }

    // Update is called once per frame
    void Update()
    {
        snare.Desnare(duracaoSnare);
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "bolaFogo":
                dano.gameObject.GetComponent<TomaDano>().TomarDanos(dFogo);
                break;
            case "Raio":

                dano.gameObject.GetComponent<TomaDano>().TomarDanos(dRaio);
                break;
            case "NaoSei":
                snare.gameObject.GetComponent<Snared>().Snare();
                dano.gameObject.GetComponent<TomaDano>().TomarDanos(dNaoSei);

                break;
            case "ataqueBasico":

                dano.gameObject.GetComponent<TomaDano>().TomarDanos(dAtaqueBasico);
                break;
            case "pegaFogo":

                dano.gameObject.GetComponent<TomaDano>().TomarDanos(dFogoArea);
                break;



        }
    }




}