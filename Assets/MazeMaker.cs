using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeMaker : MonoBehaviour
{
    [SerializeField] int timePerStep = 0;
    [SerializeField] int columns;
    [SerializeField] GameObject cellPrefab;

    List<Cell> grid = new List<Cell>();
    List<GameObject> maze = new List<GameObject>();

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            StartCoroutine("MakeMaze");
        }
    }

    IEnumerator MakeMaze()
    {
        // show loading message

        MakeGrid();

        Stack<Cell> stack = new Stack<Cell>();

        // Choose the initial cell, mark it as visited and push it to the stack
        Cell first = grid[Random.Range(0, grid.Count)];
        first.visited = true;
        stack.Push(first);

        // While the stack is not empty
        while (stack.Count > 0)
        {
            // Pop a cell from the stack and make it a current cell
            Cell current = stack.Pop();

            // If the current cell has any neighbours which have not been visited
            // Choose one of the unvisited neighbours
            Cell unvisitedNeighbor = GetUnvisitedNeighbor(current);
            if (unvisitedNeighbor != null)
            {
                // Push the current cell to the stack
                stack.Push(current);

                // Remove the wall between the current cell and the chosen cell
                RemoveWalls(current, unvisitedNeighbor);

                // Mark the chosen cell as visited and push it to the stack
                unvisitedNeighbor.visited = true;
                stack.Push(unvisitedNeighbor);
            }

            DrawCell(current);
            yield return new WaitForSeconds(timePerStep);
        }

        // Let player know the maze is ready
        Debug.Log("Done! You can play now.");
    }

    void MakeGrid()
    {
        grid.Clear();
        for (int i = 0; i < columns * columns; i++)
        {
            Cell newCell = new Cell();
            newCell.index = i;
            grid.Add(newCell);
        }
        DrawGrid();
    }

    void DrawGrid()
    {
        DeleteMaze();
        for(int i = 0; i < columns; i++)
        {
            for(int j = 0; j < columns; j++)
            {
                Vector3 pos = new Vector3(j *4, 0, i*4);
                GameObject cellGraphic = Instantiate(cellPrefab, pos, Quaternion.identity);
                cellGraphic.GetComponent<CellGraphic>().CellData = grid[i * columns + j];
                maze.Add(cellGraphic);
            }
        }
    }


    void DrawCell(Cell cell)
    {
        maze[cell.index].GetComponent<CellGraphic>().CellData = cell;
    }

    void DeleteMaze()
    {
        foreach(GameObject cell in maze)
        {
            Destroy(cell);
        }
        maze.Clear();
    }

    void RemoveWalls(Cell current, Cell next)
    {
        int difference = current.index - next.index;

        if(difference == -columns)
        {
            current.top = true;
            next.bottom = true;
        } else if(difference == -1)
        {
            current.right = true;
            next.left = true;
        } else if(difference == columns)
        {
            current.bottom = true;
            next.top = true;
        } else if(difference == 1)
        {
            current.left = true;
            next.right = true;
        }
    }

    List<int> GetNeighborIndexes(Cell cell)
    {
        List<int> indexes = new List<int>();
        if (cell.index < grid.Count - 1 - columns)
            indexes.Add(cell.index + columns);
        if (cell.index % columns != 0)
            indexes.Add(cell.index - 1);
        if (cell.index >= columns)
            indexes.Add(cell.index - columns);
        if (cell.index % columns != columns - 1)
            indexes.Add(cell.index + 1);
        return indexes;
    }

    Cell GetUnvisitedNeighbor(Cell cell)
    {
        List<Cell> neighbors = new List<Cell>();
        List<int> indexes = GetNeighborIndexes(cell);
        foreach(int index in indexes)
                neighbors.Add(grid[index]);

        List<Cell> unvisited = new List<Cell>();
        foreach(Cell neighbor in neighbors)
        {
            if (!neighbor.visited)
                unvisited.Add(neighbor);
        }

        if(unvisited.Count > 0)
        {
            int i = unvisited.Count - 1;
            i = Random.Range(0, unvisited.Count);
            return unvisited[i];
        }

        return null;
    }

}

