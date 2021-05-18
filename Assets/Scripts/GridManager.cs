using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public float[,] Grid;
    public float vertical, horizontal, columns, rows;

    void Start()
    {
        //vertical = (float)Camera.main.orthographicSize;
        //horizontal = vertical * (Screen.height / Screen.width);
        //columns = horizontal * 2;
        //rows = vertical * 2;
        Grid = new float[Mathf.RoundToInt(columns), Mathf.RoundToInt(rows)];
        SpawnTile();
    }

    private void SpawnTile()
    {
        for (float x = 0; x < columns; x += size)
        {
            for (float y = 0; y < rows; y += size)
            {
                //GameObject g = new GameObject("X :" + x + "Y :" + y);
                //g.transform.position = GetPointOnGrid(new Vector3(x - (horizontal - 0.5f), y - (vertical - 0.5f)));
                //var s = g.AddComponent<SpriteRenderer>();
                //s.sprite = sprite;
                var point = GetPointOnGrid(new Vector3(x - (horizontal - 0.5f), y - (vertical - 0.5f)));
                pointOnGrid.transform.position = point;
                Instantiate(square, pointOnGrid.transform.position, Quaternion.identity);
            }
        }

        
        

    }


    [SerializeField]
    private float size;
    public GameObject square;
    public Transform pointOnGrid;
    //public Sprite sprite;

    //    void Start()
    //    {
    //        DrawGrid();
    //    }

    public Vector3 GetPointOnGrid(Vector3 position)
    {
        position -= transform.position;
        int x = Mathf.RoundToInt(position.x / size);
        int y = Mathf.RoundToInt(position.y / size);
        int z = Mathf.RoundToInt(position.z / size);

        Vector3 result = new Vector3((float)x * size, (float)y * size, (float)z * size);
        result += transform.position;
        return result;
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.green;
    //    for (float x = 0; x < 10; x += size)
    //    {
    //        for (float y = 0; y < 10; y += size)
    //        {
    //            var point = GetPointOnGrid(new Vector3((x - 2.8f), (y - 5f), 0f));
    //            Gizmos.DrawSphere(point, 0.1f);

    //        }
    //    }
    //}
    //private void DrawGrid()
    //{
    //    for (float x = 0; x < 15; x += size)
    //    {
    //        for (float y = 0; y < 15; y += size)
    //        {
    //            var point = GetPointOnGrid(new Vector3((x - 2.8f), (y - 5f), 0f));
    //            pointOnGrid.transform.position = point;
    //            //Instantiate(square, pointOnGrid.transform.position, Quaternion.identity);
    //            GameObject g = new GameObject("Grid");
    //            g.transform.position = point;
    //            var s = g.AddComponent<SpriteRenderer>();
    //            s.sprite = sprite;


    //        }
    //    }
    //}




}
