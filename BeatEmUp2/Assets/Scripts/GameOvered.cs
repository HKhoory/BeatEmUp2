using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOvered : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject gameoverscreen;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        gameoverscreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            gameoverscreen.SetActive(true);
        }
    }
}
