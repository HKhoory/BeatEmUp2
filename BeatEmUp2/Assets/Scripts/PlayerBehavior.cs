using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{

    [SerializeField] private float hSpeed;
    [SerializeField] private float vSpeed;
    [SerializeField] private GameObject sprite;
    [SerializeField] private GameObject puncher;
    [SerializeField] private GameObject kicker;
    [SerializeField] private Rigidbody2D _rb2D;
    [SerializeField] private float cooldown;
    private float cooldownStore;
    [SerializeField] private bool isPunching;
    [SerializeField] private bool isKicking;
    [SerializeField] private int health;
    [SerializeField] private float healthCooldown;
    private float healthCooldownStore;

    void Start()
    {
        _rb2D.GetComponent<Rigidbody2D>();
        sprite.SetActive(true);
        puncher.SetActive(false);
        kicker.SetActive(false);
        cooldownStore = cooldown;
        isPunching = false;
        isKicking = false;
        healthCooldownStore = healthCooldown;
    }



    void Update()
    {

        if (health <= 0)
        {
            Destroy(gameObject);
        }

        healthCooldown -= Time.deltaTime;
        if (puncher == null)
        {
            Debug.Log("NOOOOO");
            return;
        }

        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");


        _rb2D.velocity = new Vector2(xAxis * vSpeed, yAxis * hSpeed);

        if (Input.GetKey(KeyCode.L) && !isKicking)
        {

            isPunching = true;

        }
        else if (Input.GetKey(KeyCode.K) && !isPunching) {

            isKicking = true;
        
        }

        if (isPunching)
        {
            sprite.SetActive(false);
            puncher.SetActive(true);
            
            cooldown -= Time.deltaTime;

            if (cooldown <= 0f)
            {
                puncher.SetActive(false);
                cooldown = cooldownStore;
                isPunching = false;
                sprite.SetActive(true);
            }
            
        }

        if (isKicking)
        {
            sprite.SetActive(false);
            kicker.SetActive(true);

            cooldown -= Time.deltaTime;

            if (cooldown <= 0f)
            {
                kicker.SetActive(false);
                cooldown = cooldownStore;
                isKicking = false;
                sprite.SetActive(true);
            }
        }

        if (_rb2D.velocity.x < 0)
        {
            transform.localScale = new Vector2(-1, 1);
        }
        else if (_rb2D.velocity.x > 0)
        {
            transform.localScale = new Vector2(1, 1);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {

            float minDistance;

            minDistance = Vector2.Distance(collision.transform.position, transform.position);

            if (minDistance <= 0.2f)
            {
                if (healthCooldown <= 0f)
                {
                    health--;
                    healthCooldown = healthCooldownStore;
                }
            }
        }
    }

}
