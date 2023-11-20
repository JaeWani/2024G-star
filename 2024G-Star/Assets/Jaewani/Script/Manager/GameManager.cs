using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    public GameObject Player { get {return player;}}

    private void Awake()
    {
        Singleton.Register(this);
    }
    private void Start()
    {

    }

    private void Update()
    {

    }
}
