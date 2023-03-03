using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constant
{
    public static Color gridHighlight = new Color((206 / 255f), (187 / 255f), (227 / 255f), (255 / 255f)); // #CEBBE3 206, 187, 227
    public static Color gridColor = new Color((255 / 255f), (255 / 255f), (255 / 255f), (255 / 255f)); // #CEBBE3 206, 187, 227


    public static Vector3[,] posValue = new Vector3[3, 3] {
        {new Vector3(40, 47, 0), new Vector3(130, 47, 0), new Vector3(220, 47, 0) },
        {new Vector3(40, 137, 0), new Vector3(130, 137, 0), new Vector3(220, 137, 0) },
        {new Vector3(40, 227, 0), new Vector3(130, 227, 0), new Vector3(220, 227, 0) },
    }; // 位置信息的值
}
