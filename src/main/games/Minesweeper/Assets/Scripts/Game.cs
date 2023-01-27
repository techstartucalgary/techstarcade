using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    static public int width = 16;
    static public int height = 16;
    static public int mineCount = width * height / 5;

    private Board board;
    private Cell[,] state;

    private void Awake() {
        board = GetComponentInChildren<Board>();
    }

    private void Start() {
        NewGame();
    }

    private void NewGame() {
        state = new Cell[width, height];
        GenerateCells();
        GenerateMines();
        GenerateNumbers();
        Camera.main.transform.position = new Vector3(width / 4f, height / 4f, -10f);
        board.Draw(state);
    }

    private void GenerateCells() {
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                Cell cell = new Cell();
                cell.position = new Vector3Int(x, y, 0);
                cell.type = Cell.Type.Empty;
                state[x, y] = cell;
            }
        }
    }

    private void GenerateMines() {
        for (int i = 0; i < mineCount; i++) {
            int x = Random.Range(0, width);
            int y = Random.Range(0, height);

            while (state[x,y].type == Cell.Type.Mine) {
                x++;

                if (x >= width) {
                    x = 0;
                    y++;

                    if (y >= height) {
                        y = 0;
                    }
                }
            }

            state[x, y].type = Cell.Type.Mine;
        }
    }

    private void GenerateNumbers() {
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                Cell cell = state[x, y];

                if (cell.type == Cell.Type.Mine) {
                    continue;
                }

                cell.number = CountMines(x, y);

                if (cell.number > 0) {
                    cell.type = Cell.Type.Number;
                }

                state[x, y] = cell;
            }
        }
    }

    private void RevealAllCells() {
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                state[x,y].revealed = true;
            }
        }
        board.Draw(state);
    }

    private int CountMines(int cellX, int cellY) {
        int count = 0;
        
        for (int adjacentX = -1; adjacentX <= 1; adjacentX++) {
            for (int adjacentY = -1; adjacentY <= 1; adjacentY++) {
                if (adjacentX == 0 && adjacentY == 0) {
                    continue;
                }

                int x = cellX + adjacentX;
                int y = cellY + adjacentY;

                if (GetCell(x, y).type == Cell.Type.Mine) count++;
            }
        }
        return count;
    }

    private void Update() {
        if (Input.GetMouseButtonDown(1)) {
            Flag();
        }
        else if (Input.GetMouseButtonDown(0)) {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int cellPosition = board.tilemap.WorldToCell(worldPosition);
            Reveal(cellPosition.x, cellPosition.y);
        }
    }

    private void Flag() {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int cellPosition = board.tilemap.WorldToCell(worldPosition);
        Cell cell = GetCell(cellPosition.x, cellPosition.y);

        if (cell.type == Cell.Type.Invalid || cell.revealed) {
            return;
        }

        cell.flagged = !cell.flagged;
        state[cellPosition.x, cellPosition.y] = cell;
        board.Draw(state);
    }

    private void Reveal(int xPos, int yPos) {
        Cell cell = GetCell(xPos, yPos);

        if (cell.type == Cell.Type.Invalid || cell.revealed || cell.flagged) {
            return;
        }
        else if (cell.type == Cell.Type.Mine) {
            cell.exploded = true;
            RevealAllCells();
        }

        cell.revealed = true;

        state[xPos, yPos] = cell;
        board.Draw(state);

        if (cell.type == Cell.Type.Empty) {
            for (int adjacentX = -1; adjacentX <= 1; adjacentX++) {
                for (int adjacentY = -1; adjacentY <= 1; adjacentY++) {
                    if (adjacentX == 0 && adjacentY == 0) {
                        continue;
                    }

                    int x = xPos + adjacentX;
                    int y = yPos + adjacentY;

                    Reveal(x, y);
                }
            }
        }
    }

    private Cell GetCell(int x, int y) {
        if (IsValid(x, y)) {
            return state[x, y];
        }
        else {
            return new Cell();
        }
    }

    private bool IsValid(int x, int y) {
        return x >= 0 && x < width && y >= 0 && y < height;
    }
}
