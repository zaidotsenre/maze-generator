using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze : MonoBehaviour
{
    [SerializeField] GameObject cellPrefab;
    [SerializeField] float cellSize = 4;

    List<GameObject> cells;
    
    public void Make(int size)
    {
        Blueprint blueprint = new Blueprint(size);
        cells = new List<GameObject>();
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Vector3 pos = new Vector3(j * cellSize, 0, i * cellSize);
                GameObject cell = Instantiate(cellPrefab, pos, Quaternion.identity);
                cell.GetComponent<CellGraphic>().CellData = blueprint.Cells[i * size + j];
                cells.Add(cell);
            }
        }
    }

    public void Delete()
    {
        if(cells != null)
        {
            foreach (GameObject cell in cells)
                Destroy(cell);
            cells.Clear();
        } 
    }
}
