using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public string PlayerName { get; set; }

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }

        Instance = this;
    }

    public void Play()
    {
        throw new System.NotImplementedException();
    }

    public void Quit()
    {
        throw new System.NotImplementedException();
    }
}
