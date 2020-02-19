﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Magia : MonoBehaviour
{
    // Variaveis das habilidades
    public bool bolaFogo = false;
    public bool raio = false;
    public bool seiLa = false;


    public GameObject player;

    //variaveis para spawn de habilidades
    public GameObject fireBall;
    public GameObject choque;
    public GameObject naoSei;

    public Transform cagadorDeMagia;


    protected RaycastHit hit;

    public LayerMask hitavel;

    // Start is called before the first frame update




    // Variaveis para CoolDown

    public float manaRegenSegundo = 3f;
    public float manaMax = 100f;
    public float updatedMana = 100f;
    public float custoManaFogo = 10f;
    public float custoManaRaio = 15f;
    public float custoManaNaoSei = 20f;
    public Text quantidadeMana;
    public Image barraMana;

    public Transform ataqueBasico;
    public Transform ataquePoint;

    public Transform raizes;
    public Transform raizesPoint;

    public float tempoAtaque;
    private float waitFireRate = 1;
    public bool podeAtacar = true;
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        barraMana.fillAmount = updatedMana / 100;
        quantidadeMana.text = (int)updatedMana + " Mana ";
        updatedMana += manaRegenSegundo * Time.deltaTime;

        if (updatedMana > manaMax)
        {
            updatedMana = 100;
        }
        if (updatedMana < 0)
        {
            updatedMana = 0;
        }




        SkillCheck();
        Atacando();
        TempoTiro();

    }




    void SkillCheck()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            bolaFogo = true;
            raio = false;
            seiLa = false;

        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            bolaFogo = false;
            raio = true;
            seiLa = false;

        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            bolaFogo = false;
            raio = false;
            seiLa = true;


        }

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            bolaFogo = false;
            raio = false;
            seiLa = false;
        }



    }


    void Atacando()
    {
        if ((Input.GetMouseButtonDown(0)) && (!EventSystem.current.IsPointerOverGameObject()))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100, hitavel) && (bolaFogo) && (updatedMana >= custoManaFogo))
            {
                Instantiate(fireBall, new Vector3(hit.point.x, 20, hit.point.z), Quaternion.Euler(hit.normal));
                updatedMana -= custoManaFogo;
            }
            if (Physics.Raycast(ray, out hit, 100, hitavel) && (raio) && (updatedMana >= custoManaRaio))
            {
                Instantiate(choque, new Vector3(hit.point.x, 20, hit.point.z), Quaternion.Euler(hit.normal));
                updatedMana -= custoManaRaio;
            }
            if (Physics.Raycast(ray, out hit, 100, hitavel) && (seiLa) && (updatedMana >= custoManaNaoSei))
            {
                Instantiate(raizes, raizesPoint.position, raizesPoint.rotation);
                updatedMana -= custoManaNaoSei;
            }



        }
        if ((Input.GetMouseButtonDown(1)) && (!EventSystem.current.IsPointerOverGameObject()))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100, hitavel) && (podeAtacar))
            {
                Instantiate(ataqueBasico, ataquePoint.position, ataquePoint.rotation);
                podeAtacar = false;
                waitFireRate = 1f;

            }
        }
    }
    void TempoTiro()
    {
        if (!podeAtacar)
        {
            waitFireRate += waitFireRate * Time.deltaTime;
        }

        if (waitFireRate >= tempoAtaque)
        {
            podeAtacar = true;
        }
    }

}


