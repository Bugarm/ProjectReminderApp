using UnityEngine;

public class GameData : MonoBehaviour
{
    private static Camera _myCamera;

    public static float CurrentMasterVolume { get; set; }

    public static Vector3 MousePos => GetMousePos();

    private static Vector3 GetMousePos()
    {
        var mousePos = _myCamera.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0f, 0f, 10f);
        return mousePos;
    }
}