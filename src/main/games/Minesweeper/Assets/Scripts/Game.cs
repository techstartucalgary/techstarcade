using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    private int width;
    private int height;
    private int mineCount;

    private Board board;
    private Cell[,] state;
    private bool firstClick;
    private bool lost;
    private bool won;

    public void easyMode() {
        mineCount = 10;
        width = 10;
        height = 10;
    }

    public void mediumMode() {
        mineCount = 32;
        width = 16;
        height = 16;
    }

    public void hardMode() {
        mineCount = 50;
        width = 20;
        height = 20;
    }

    private void Awake() {
        board = GetComponentInChildren<Board>();
    }

    private void Start() {
        NewGame();
    }

    public void NewGame() {
        firstClick = true;
        won = false;
        lost = false;
        state = new Cell[width, height];
        GenerateCells();
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

    private void GenerateMines(int xClick, int yClick) {
        for (int i = 0; i < mineCount; i++) {
            int x = Random.Range(0, width);
            int y = Random.Range(0, height);

            while (state[x,y].type == Cell.Type.Mine || ((xClick - 1 <= x && x <= xClick + 1) && (yClick - 1 <= y && y <= yClick + 1))) {
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

    private void RevealMineCells() {
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                if (state[x,y].type == Cell.Type.Mine) {
                    if (won) state[x,y].flagged = true;
                    state[x,y].revealed = true;
                }
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
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int cellPosition = board.tilemap.WorldToCell(worldPosition);

        if (!won && !lost) {
            DetectWin();
            HoverTint(cellPosition.x, cellPosition.y);
        }

        if (Input.GetMouseButtonDown(1)) {
            Flag(cellPosition.x, cellPosition.y);
        }
        else if (Input.GetMouseButtonDown(0)) {
            if (firstClick && IsValid(cellPosition.x, cellPosition.y)) {
                firstClick = false;
                GenerateMines(cellPosition.x, cellPosition.y);
                GenerateNumbers();
            }
            Cell cell = GetCell(cellPosition.x, cellPosition.y);
            if (cell.type == Cell.Type.Number && cell.revealed) NumberClick(cellPosition.x, cellPosition.y);
            else Reveal(cellPosition.x, cellPosition.y);
        }
    }

    private void Flag(int xPos, int yPos) {
        Cell cell = GetCell(xPos, yPos);

        if (cell.type == Cell.Type.Invalid || cell.revealed) {
            return;
        }

        cell.flagged = !cell.flagged;
        state[xPos, yPos] = cell;
        board.Draw(state);
    }

    private void Reveal(int xPos, int yPos) {
        Cell cell = GetCell(xPos, yPos);

        if (cell.type == Cell.Type.Invalid || cell.revealed || cell.flagged) {
            return;
        }
        else if (cell.type == Cell.Type.Mine) {
            cell.exploded = true;
            lost = true;
            RevealMineCells();
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

    private void NumberClick(int xPos, int yPos) {
        Cell cell = GetCell(xPos, yPos);
        int flagCount = 0;
        for (int adjacentX = -1; adjacentX <= 1; adjacentX++) {
            for (int adjacentY = -1; adjacentY <= 1; adjacentY++) {
                if (adjacentX == 0 && adjacentY == 0) {
                    continue;
                }

                int x = xPos + adjacentX;
                int y = yPos + adjacentY;
                    
                if (GetCell(x, y).flagged) flagCount++;
            }
        }

        if (cell.number == flagCount) {
            for (int adjacentX = -1; adjacentX <= 1; adjacentX++) {
                for (int adjacentY = -1; adjacentY <= 1; adjacentY++) {
                    if (adjacentX == 0 && adjacentY == 0) {
                        continue;
                    }

                    int x = xPos + adjacentX;
                    int y = yPos + adjacentY;
                        
                    if (!GetCell(x, y).flagged) Reveal(x, y);
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

    private void HoverTint(int xPos, int yPos) {
        Cell cell = GetCell(xPos, yPos);

        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                state[x,y].hovered = false;
            }
        }

        board.Draw(state);


        if (!cell.revealed && cell.type != Cell.Type.Invalid) {
            state[xPos, yPos].hovered = true;
            board.Draw(state);
        }
    }

    private void DetectWin() {
        int unrevealedCount = 0;
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                if (!state[x, y].revealed) unrevealedCount++;
            }
        }
        if (unrevealedCount == mineCount) {
            won = true;
            RevealMineCells();
        }
        else won = false;
    }
}
