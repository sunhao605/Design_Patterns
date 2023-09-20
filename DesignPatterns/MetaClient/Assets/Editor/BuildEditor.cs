using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

public class BuildEditor : MonoBehaviour
{
    public static string path = "D:/exe/EMMetaClient";

    [MenuItem("Buildexe/windows")]
    public static void Build()
    {
        if (Directory.Exists(path))
        {
            Directory.Delete(path, true);
        }

        Directory.CreateDirectory(path);

        var buildOption = new BuildPlayerOptions();
        buildOption.target = BuildTarget.StandaloneWindows64;
        buildOption.scenes = new string[] { "Assets/Scenes/LoginScene.unity", 
            "Assets/Scenes/Sliver_10Floor.unity", 
            "Assets/Scenes/Gold_18Floor.unity", 
            "Assets/Scenes/LoadingScene.unity", 
            "Assets/Scenes/Gold_1Floor.unity", 
            "Assets/Scenes/MeetingRoom.unity",
         "Assets/Scenes/WanPingSquare.unity",
        "Assets/Scenes/CD_6Floor.unity",
        "Assets/Scenes/ShowRoom.unity"};
        buildOption.locationPathName = path + "/EMMeta.exe";
        BuildPipeline.BuildPlayer(buildOption);
    }
}
