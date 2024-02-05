using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    private LineRenderer currentLine;
    private List<Vector3> linePositions = new List<Vector3>();
    private Vector3 startPosition;

    public void StartNewLine(Vector3 position)
    {
        if (startPosition == new Vector3 (0f, 0f, 0f)){
            startPosition =  position;
        }
        else{
            GameObject lineObject = new GameObject("Line");
            currentLine = lineObject.AddComponent<LineRenderer>();
            currentLine.positionCount = 2;
            currentLine.useWorldSpace = true;

            currentLine.startWidth = 0.06f;  
            currentLine.endWidth = 0.06f;

            Vector3 endPosition = position;
            linePositions.Clear();
            linePositions.Add(new Vector3(startPosition.x, startPosition.y, startPosition.z));
            linePositions.Add(new Vector3(endPosition.x, endPosition.y, endPosition.z));

            currentLine.SetPositions(linePositions.ToArray());
            startPosition = new Vector3(endPosition.x, endPosition.y, endPosition.z);
        }
    }

}
