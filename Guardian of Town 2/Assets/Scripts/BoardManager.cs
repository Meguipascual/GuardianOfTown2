using UnityEngine;
using UnityEngine.Tilemaps;

public class BoardManager : MonoBehaviour
{
    public class CellData
    {
        public bool Passable;
    }

    [SerializeField] private int _width;
    [SerializeField] private int _height;
    [SerializeField] private Tile[] _groundTiles;
    [SerializeField] private Tile[] _wallTiles;
    private Tilemap _tileMap;
    private CellData[,] _boardData;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _tileMap = GetComponentInChildren<Tilemap>();
        _boardData = new CellData[_width, _height];

        for (int y = 0; y < _height; ++y)
        {
            for (int x = 0; x < _width; ++x)
            {
                Tile tile;
                _boardData[x, y] = new CellData();

                if (x == 0 || y == 0 || x == _width - 1 || y == _height - 1)
                {
                    tile = _wallTiles[Random.Range(0, _wallTiles.Length)];
                    _boardData[x, y].Passable = false;
                }
                else
                {
                    tile = _groundTiles[Random.Range(0, _groundTiles.Length)];
                    _boardData[x, y].Passable = true;
                }

                _tileMap.SetTile(new Vector3Int(x, y, 0), tile);
            }
        }
    }
}
