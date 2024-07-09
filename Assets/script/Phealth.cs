using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phealth : MonoBehaviour
{
    public int maxHealth = 5;
    public int health;

    
    public float damageInterval = 1.0f;
    private float nextDamageTime;

    public GameObject WIN;
    public GameObject BackStage;
    public GameObject LOSE;

    void Start()
    {
        health = maxHealth;
    }

    void Update()
    {
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Respawn();
           
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "END")
        {
            WIN.SetActive(true);
            BackStage.SetActive(true);
        }

        if (collision.tag == "fall")
        {
            Respawn();
        }
    }

    public void Respawn()
    {
        if (CheckpointManager.LastCheckpointPosition != Vector3.zero)
        {  
            transform.position = CheckpointManager.LastCheckpointPosition;
        }
        else
        {
            transform.position = Vector3.zero;
        }
    }
}

