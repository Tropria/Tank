using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerManager : MonoBehaviour {

    public static int greenLayer = 15;
    public static int redLayer = 16;
    public static int blueLayer = 17;

    public static LayerMask GetEnemyLayer(Team team)
    {
        LayerMask lm = 0;
        switch(team)
        {
            case Team.Blue:
                lm = (1 << redLayer) | (1 << greenLayer);
                break;
            case Team.Red:
                lm = LayerMask.GetMask("Green") | LayerMask.GetMask("Blue");
                break;
            case Team.Green:
                lm = (1 << LayerMask.NameToLayer("Red")) | (1 << LayerMask.NameToLayer("Blue"));
                break;
        }
        return lm;
    }

}
