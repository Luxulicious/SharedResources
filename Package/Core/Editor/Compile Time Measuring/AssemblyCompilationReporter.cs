using System;
using UnityEditor;
using UnityEditor.Compilation;
using UnityEngine;

namespace Editor
{
    [InitializeOnLoad]
    public class AssemblyCompilationReporter : UnityEditor.Editor
    {
        [InitializeOnLoadMethod]
        private static void Init()
        {
            CompilationPipeline.assemblyCompilationStarted += CompilationPipelineOnAssemblyCompilationStarted;
            CompilationPipeline.assemblyCompilationFinished += CompilationPipelineOnAssemblyCompilationFinished;
        }

        private static void CompilationPipelineOnAssemblyCompilationFinished(string s,
            CompilerMessage[] compilerMessages)
        {
            var startTimeInTicks = PlayerPrefs.GetString($"CompileStartTime{s}");
            var startTime = new DateTime(Convert.ToInt64(startTimeInTicks));

            var compileTime = DateTime.Now - startTime;

            Debug.Log($"=== CompilationPipeline Assembly Finished {s} ({compileTime.ToString("s\\.fff")}s)");

            foreach (var compilerMessage in compilerMessages)
            {
                switch (compilerMessage.type)
                {
                    case CompilerMessageType.Error:
                        Debug.LogError(
                            $"==== {compilerMessage.file}[{compilerMessage.line}:{compilerMessage.column}] {compilerMessage.message}");
                        break;
                    case CompilerMessageType.Warning:
                        Debug.LogWarning(
                            $"==== {compilerMessage.file}[{compilerMessage.line}:{compilerMessage.column}] {compilerMessage.message}");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        private static void CompilationPipelineOnAssemblyCompilationStarted(string s)
        {
            PlayerPrefs.SetString($"CompileStartTime{s}", Convert.ToString(DateTime.Now.Ticks));
        }


        static bool isTrackingTime;
        static double startTime;

        static AssemblyCompilationReporter()
        {
            EditorApplication.update += Update;
            startTime = PlayerPrefs.GetFloat("CompileStartTime", 0);
            if (startTime > 0)
            {
                isTrackingTime = true;
            }
        }


        static void Update()
        {
            if (EditorApplication.isCompiling && !isTrackingTime)
            {
                startTime = EditorApplication.timeSinceStartup;
                PlayerPrefs.SetFloat("CompileStartTime", (float)startTime);
                isTrackingTime = true;
            }
            else if (!EditorApplication.isCompiling && isTrackingTime)
            {
                var finishTime = EditorApplication.timeSinceStartup;
                isTrackingTime = false;
                var compileTime = finishTime - startTime;
                PlayerPrefs.DeleteKey("CompileStartTime");
                Debug.Log("Script compilation time: \n" + compileTime.ToString("0.000") + "s");
            }
        }
    }
}