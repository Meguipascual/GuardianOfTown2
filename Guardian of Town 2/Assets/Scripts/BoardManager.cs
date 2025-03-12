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
    [SerializeField] private PlayerController _player;
    private Grid _grid;
    private Tilemap _tileMap;
    private CellData[,] _boardData;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Init()
    {
        _tileMap = GetComponentInChildren<Tilemap>();
        _grid = GetComponentInChildren<Grid>();
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

    public Vector3 CellToWorld (Vector2Int cellIndex)
    {
        return _grid.GetCellCenterWorld((Vector3Int) cellIndex);
    }

    public CellData GetCellData(Vector2Int cellIndex)
    {
        if (cellIndex.x < 0 || cellIndex.x >= _width
            || cellIndex.y < 0 || cellIndex.y >= _height)
        {
            return null;
        }

        return _boardData[cellIndex.x, cellIndex.y];
    }
}
