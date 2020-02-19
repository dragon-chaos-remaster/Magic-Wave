﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InimigoTerra : MonoBehaviour
{
    NavMeshAgent agent;
    Transform target;

    public float disShot;
    public GameObject pedregulho;
    public Transform shootPoint;
    bool isShooting;

    public float minAtirar;
    public float maxAtirar;

    public float damping;

    public int dFogo;
    public int dRaio;
    public int dNaoSei;
    public int dAtaqueBasico;
    public int dFogoArea;

    TomaDano dano;

    Snared snare;
    public float duracaoSnare;
    // Start is called before the first frame update
    void Start()
    {

        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("player").transform;
        dano = GetComponent<TomaDano>();
        snare = GetComponent<Snared>();
    }

    void OlhandoProPlayer()
    {
        Vector3 targetPos = new Vector3(target.position.x, transform.position.y, target.position.z);
        transform.LookAt(targetPos);
    }
    // Update is called once per frame
    void Update()
    {
        snare.Desnare(duracaoSnare);
        agent.destination = target.position;

        OlhandoProPlayer();

        float distance = Vector3.Distance(transform.position, target.position);
        if (distance <= disShot)
        {
            if (!isShooting)
            {
                InvokeRepeating("Shoot", Random.Range(minAtirar, maxAtirar), Random.Range(minAtirar, maxAtirar));
                isShooting = true;
            }
        }
        else
        {
            CancelInvoke("Shoot");
            isShooting = false;

        }


    }
    void Shoot()
    {
        Instantiate(pedregulho, shootPoint.position, shootPoint.rotation);
    }


    void OnTriggerEnter(Collider other)
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