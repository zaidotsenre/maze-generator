using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze : MonoBehaviour
{
    [SerializeField] GameObject cellPrefab;
    [SerializeField] int mazeSize = 25;
    [SerializeField] float cellSize = 4;

    List<GameObject> cells;

    private void Start()
    {
        Make(new Blueprint(mazeSize));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Delete();
            Make(new Blueprint(25));
        }       
    }

    void Make(Blueprint blueprint)
    {
        cells = new List<GameObject>();
        for (int i = 0; i < blueprint.Size; i++)
        {
            for (int j = 0; j < blueprint.Size; j++)
            {
                Vector3 pos = new Vector3(j * cellSize, 0, i * cellSize);
                GameObject cell = Instantiate(cellPrefab, pos, Quaternion.identity);
                cell.GetComponent<CellGraphic>().CellData = blueprint.Cells[i * blueprint.Size + j];
                cells.Add(cell);
            }
        }
    }

    void Delete()
    {
        foreach (GameObject cell in cells)
            Destroy(cell);
        cells.Clear();
    }
}
