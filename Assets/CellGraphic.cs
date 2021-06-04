using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellGraphic : MonoBehaviour
{
    [SerializeField] GameObject topWall;
    [SerializeField] GameObject rightWall;
    [SerializeField] GameObject bottomWall;
    [SerializeField] GameObject leftWall;

    [SerializeField] MeshRenderer floorRenderer;

    public Cell CellData 
    { 
        set 
        { 
            cellData = value;
            topWall.SetActive(!cellData.top);
            rightWall.SetActive(!cellData.right);
            bottomWall.SetActive(!cellData.bottom);
            leftWall.SetActive(!cellData.left);
        } 
    }
    Cell cellData;

    private void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
            floorRenderer.material.color = Color.blue;
    }
}
