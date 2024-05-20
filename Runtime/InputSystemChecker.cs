#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.PackageManager;
using UnityEditor.PackageManager.Requests;

[InitializeOnLoad]
public class InputSystemChecker
{
    private const string InputSystemPackageName = "com.unity.inputsystem";
    private const string ScriptingDefineSymbol = "USE_INPUT_SYSTEM";

    static InputSystemChecker()
    {
        CheckInputSystemPackage();
    }

    private static void CheckInputSystemPackage()
    {
        ListRequest listRequest = Client.List();
        EditorApplication.update += () =>
        {
            if (listRequest.IsCompleted)
            {
                EditorApplication.update -= () => { };
                if (listRequest.Status == StatusCode.Success)
                {
                    bool packageFound = false;
                    foreach (var package in listRequest.Result)
                    {
                        if (package.name == InputSystemPackageName)
                        {
                            packageFound = true;
                            break;
                        }
                    }
                    UpdateScriptingDefineSymbols(packageFound);
                }
            }
        };
    }

    private static void UpdateScriptingDefineSymbols(bool packageFound)
    {
        BuildTargetGroup buildTargetGroup = EditorUserBuildSettings.selectedBuildTargetGroup;
        string defines = PlayerSettings.GetScriptingDefineSymbolsForGroup(buildTargetGroup);
        if (packageFound)
        {
            if (!defines.Contains(ScriptingDefineSymbol))
            {
                defines += ";" + ScriptingDefineSymbol;
                PlayerSettings.SetScriptingDefineSymbolsForGroup(buildTargetGroup, defines);
            }
        }
        else
        {
            if (defines.Contains(ScriptingDefineSymbol))
            {
                defines = defines.Replace(ScriptingDefineSymbol, string.Empty);
                PlayerSettings.SetScriptingDefineSymbolsForGroup(buildTargetGroup, defines);
            }
        }
    }
}
#endif
