﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaManaPlayer : MonoBehaviour
{
    public float vida = 100;

    public Image barraVida;
    public Text quantidadeVida;
     

    // Start is called before the first frame update
    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
        barraVida.fillAmount = vida / 100;
        quantidadeVida.text = (int)vida + " HP ";
        if (vida <= 0)
        {
            Destroy(gameObject);
           
        }
        if (vida > 100)
        {
            vida = 100;
        }
        if (vida < 0)
        {
            vida = 0;
        }

    }

    private void OnTriggerEnter(Collider other)
    {


        if (other.tag == ("coletavelVida") && (CompareTag("player")))
        {
            vida += 20;
        }
        if (other.tag == ("pedregulho") && (CompareTag("player")))
        {
            vida -= 25;
           
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == ("inimigoFraco"))
        {
            vida -= 10;
           
        }
        if (collision.collider.tag == ("inimigoTerra"))
        {
            vida -= 15;
            
        }
    }
}
