using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class GameManager : MonoBehaviour
{
    [SerializeField] private BoardManager _boardManager;
    [SerializeField] private PlayerController _playerController;
    public TurnManager TurnManager { get; private set; }

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TurnManager = new TurnManager();
        _boardManager.Init();
        _playerController.Spawn(_boardManager, new Vector2Int(1, 1));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
