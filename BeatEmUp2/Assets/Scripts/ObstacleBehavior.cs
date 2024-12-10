using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehavior : MonoBehaviour
{

    [SerializeField] private Rigidbody2D _rb2D;

    [SerializeField] private float speed;
    [SerializeField] private float frequency;
    [SerializeField] private bool dir;
    private float frequencyStore;

    void Start()
    {
        dir = true;
        _rb2D = GetComponent<Rigidbody2D>();
        frequencyStore = frequency;
    }

    
    void Update()
    {
        frequency -= Time.deltaTime;
        if (dir)
        {
            //_rb2D.velocity = new Vector2(_rb2D.velocity.x, speed * Time.deltaTime);
            transform.position = new Vector2(transform.position.x, transform.position.y + speed * Time.deltaTime);
         
            if (frequency <= 0)
            {
                frequency = frequencyStore;
                dir = false;
            }
        }
        else if ( !dir)
        {
            //_rb2D.velocity = new Vector2(_rb2D.velocity.x, -speed * Time.deltaTime);
            transform.position = new Vector2(transform.position.x, transform.position.y - speed * Time.deltaTime);

            if (frequency <= 0)
            {
                dir = true;
                frequency = frequencyStore;
            }
        }
    }
}
