using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum PlayerState
    {
        Playing,
        Inventory
    }

    public static GameManager instance;

    [Header("컴포넌트")]
    public GameObject Player;

    public Camera mainCamera;

    [Header("상태")]
    [SerializeField] private PlayerState currentPlayerState;
    public PlayerState CurrentPlayerState
    {
        get => currentPlayerState; 
        set
        {
            currentPlayerState = value;
            SetMousePointerVisible();
        }
    }


    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);


    }
    private void Start()
    {
        mainCamera = Camera.main;

        SetMousePointerVisible();
    }

    private void Update()
    {

    }

    private void SetMousePointerVisible() 
    {
        if (currentPlayerState == PlayerState.Playing) Cursor.visible = false;
        else if (currentPlayerState == PlayerState.Inventory) Cursor.visible = true;
    }
}
