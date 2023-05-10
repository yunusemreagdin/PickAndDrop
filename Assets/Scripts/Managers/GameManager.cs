using System;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    #region UnityFuncs.
    
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        layerNumber = LayerMask.GetMask("holdLayer");
    }

    #endregion
   
    #region VARS

    [Header("Player Attributes")]
    public PlayerData DATA;
    public float throwForce = 500f;
    public GameObject player;
    
    [Header("Ray and Item")]
    public Transform holdPosition;
    
    [Header("Canvas Controller")]
    public GameObject inGameUI,endGameUI;
    
    [Header("Total Score Attributes")]
    public int totalScore;
    public TextMeshProUGUI totalScoreTxt;
    
    [Header("Others(isim bulamadım)")]
    [HideInInspector] public int layerNumber;
    public CarryDesk desk;
    public GameState _gameState = GameState.InGame;
    
   

    #endregion
}
