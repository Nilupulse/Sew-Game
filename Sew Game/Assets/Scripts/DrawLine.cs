using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    public GameObject linePrefab;
    public GameObject currentLine;
    public LineRenderer lineRenderer;
    public EdgeCollider2D edgCollider;
    public List<Vector2> fingerPositions = new List<Vector2>();
    Color lineColour;
    public bool canDraw;
    // Start is called before the first frame update
    public static DrawLine Instance;

 
    void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (canDraw)
        {
            if (Input.GetMouseButtonDown(0))
            {
                CreateLine();
            }
            if (Input.GetMouseButton(0))
            {
                Vector2 tempFingerPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (Vector2.Distance(tempFingerPos, fingerPositions[fingerPositions.Count - 1]) > .1f)
                {
                    UpdateLine(tempFingerPos);
                }
            }
        }
        
    }
    void CreateLine() 
    {
        currentLine = Instantiate(linePrefab, Vector3.zero, Quaternion.identity);
        lineRenderer = currentLine.GetComponent<LineRenderer>();        
        edgCollider = currentLine.GetComponent<EdgeCollider2D>();
        lineRenderer.SetColors(GetLineColour(), GetLineColour());
        fingerPositions.Clear();
        fingerPositions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        fingerPositions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        lineRenderer.SetPosition(0,fingerPositions[0]);
        lineRenderer.SetPosition(1, fingerPositions[1]);
        edgCollider.points = fingerPositions.ToArray();
    }
    Color GetLineColour() 
    {
        return lineColour;
    }
    public void SetColor(int colorID) 
    {

        if (colorID == 1)
        {
            lineColour = Color.green;
        }
        else if (colorID == 2)
        {
            lineColour = Color.red;
        }
        else if (colorID == 3)
        {
            lineColour = Color.blue;
        }
    }
    void UpdateLine(Vector2 newFingerPos) 
    {
        fingerPositions.Add(newFingerPos);
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount-1,newFingerPos);
        edgCollider.points = fingerPositions.ToArray();
    }
}
