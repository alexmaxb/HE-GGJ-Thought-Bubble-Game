using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathLibrary : MonoBehaviour
{
    public Path[] paths;

    public Path GetPathByKey(string key) {
        foreach (var path in paths) {
            if (path.key == key) {
                return path;
            }
        }

        return null;
    }
}
