using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{

    [SerializeField] private Rigidbody2D _rb2D;
    [SerializeField] private GameObject player;
    [SerializeField] private float hSpeed;
    [SerializeField] private float vSpeed;
    [SerializeField] private int health;
    [SerializeField] private float forceValue;
    [SerializeField] private GameObject spin;
    [SerializeField] private SpriteRenderer _sprite;
    [SerializeField] private bool isPunched;
    [SerializeField] private float cooldown;
    private float cooldownStore;

    // Start is called before the first frame update
    void Start()
    {
        _rb2D.GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        _sprite = spin.GetComponent<SpriteRenderer>();
        cooldownStore = cooldown;
        isPunched = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (health <= 0)
        {
            Destroy(gameObject);
        }

        Vector2 dir = player.transform.position - transform.position;

        dir.Normalize();

        if (!isPunched)
        _rb2D.velocity = new Vector2(vSpeed * dir.x, hSpeed * dir.y);
        else
        {
            _rb2D.MoveRotation(900f * Time.deltaTime);
            spin.transform.Rotate( new Vector3(0, 0, 900f * Time.deltaTime));
            cooldown -= Time.deltaTime;
            if (cooldown < 0f)
            {
                cooldown = cooldownStore;
                isPunched = false;
            }

        }


        if (_rb2D.velocity.x > 0f)
        {
            _sprite.flipX = true;
        }
        else
        {
            _sprite.flipX = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Punch"))
        {
            isPunched = true;
            health--;
            if (transform.position.x < player.transform.position.x)
            {
                _rb2D.AddForce(new Vector2(-forceValue, 0));
            }
            else
            {
                _rb2D.AddForce(new Vector2(forceValue, 0));
            }

            

        }

    }

}
