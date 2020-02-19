﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    NavMeshAgent agent;
    Transform target;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("player").transform;
    }

    public void SeguirOPlayer()
    {
        agent.destination = target.position;
    }
    // Update is called once per frame
    void Update()
    {
        SeguirOPlayer();

    }
}