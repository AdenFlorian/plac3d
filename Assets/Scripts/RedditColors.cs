using UnityEngine;
using System.Collections.Generic;

public static class RedditColors
{
	public static Dictionary<int, Color> intToColorMap = new Dictionary<int, Color>()
    {
        {0, new Color32(255, 255, 255, 255)},   // white
        {1, new Color32(228, 228, 228, 255)},   // lightgray
        {2, new Color32(136, 136, 136, 255)},   // darkgray
        {3, new Color32(34, 34, 34, 255)},      // black
        {4, new Color32(255, 167, 209, 255)},   // lightpink
        {5, new Color32(229, 0, 0, 255)},       // red
        {6, new Color32(229, 149, 0, 255)},     // orange
        {7, new Color32(160, 106, 66, 255)},    // brown
        {8, new Color32(229, 217, 0, 255)},     // yellow
        {9, new Color32(148, 224, 68, 255)},    // lightgreen
        {10, new Color32(2, 190, 1, 255)},      // green
        {11, new Color32(0, 211, 221, 255)},    // cyan
        {12, new Color32(0, 131, 199, 255)},    // grayblue
        {13, new Color32(0, 0, 234, 255)},      // blue
        {14, new Color32(207, 110, 228, 255)},  // pink
        {15, new Color32(130, 0, 128, 255)}     // purple
    };
}
