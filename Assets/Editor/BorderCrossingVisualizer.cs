using Animals.Conditions;
using UnityEditor;
using UnityEngine;

namespace Zoo.Editor
{
    [InitializeOnLoad]
    public static class BorderDataVisualizer
    {
        static bool subscribed = false;

        static BorderDataVisualizer()
        {
            // Delay subscription until Editor is fully initialized
            EditorApplication.delayCall += EnsureSubscribed;
        }

        static void EnsureSubscribed()
        {
            if (subscribed) return;
            SceneView.duringSceneGui += OnSceneGUI;
            subscribed = true;
        }

        private static void OnSceneGUI(SceneView sceneView)
        {
            if (Application.isPlaying) return;

            Handles.zTest = UnityEngine.Rendering.CompareFunction.LessEqual;

            string[] guids = AssetDatabase.FindAssets("t:BorderCrossingCondition");
            foreach (string guid in guids)
            {
                var path = AssetDatabase.GUIDToAssetPath(guid);
                var data = AssetDatabase.LoadAssetAtPath<BorderCrossingCondition>(path);
                if (data == null)
                    continue;

                Handles.color = Color.red;

                Vector3 half = new Vector3(data.Size.x / 2, 0, data.Size.z / 2);
                Vector3 c = data.Center;

                Vector3[] verts =
                {
                    c + new Vector3(-half.x, 0, -half.z),
                    c + new Vector3(-half.x, 0,  half.z),
                    c + new Vector3( half.x, 0,  half.z),
                    c + new Vector3( half.x, 0, -half.z),
                };

                Handles.DrawAAPolyLine(3, verts[0], verts[1], verts[2], verts[3], verts[0]);
                Handles.Label(c + Vector3.up * 0.5f, data.name, EditorStyles.boldLabel);
            }
        }
    }
}