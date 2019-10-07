using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DailyBonusController))]
public class DailyBonusControllerEditor : Editor
{
    private DailyBonusController main;

    public override void OnInspectorGUI()
    {
        main = (DailyBonusController) target;

        Undo.RecordObject(main, "Bonus");

        EditorGUILayout.BeginVertical();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("arrow Pointer", GUILayout.Width(100));
        main.arrow = (Transform) EditorGUILayout.ObjectField(main.arrow, typeof(Transform));
        EditorGUILayout.EndHorizontal();

        if (GUILayout.Button("Add", GUILayout.Width(100)))
        {
            main.BonusItems.Add(new BonusItem());
        }

        EditorGUILayout.EndVertical();

        int total_probability = 0;
        foreach (BonusItem reward in main.BonusItems)
            total_probability += reward.ProbabilityPercent;

        for (int i = 0; i < main.BonusItems.Count; i++)
        {
            EditorGUILayout.BeginHorizontal(EditorStyles.textArea);
            EditorGUILayout.BeginVertical();
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("X", GUILayout.Width(50)))
            {
                main.BonusItems.Remove(main.BonusItems[i]);
            }

            EditorGUILayout.LabelField(i + "---", EditorStyles.boldLabel, GUILayout.Width(30));

            main.BonusItems[i].name = EditorGUILayout.TextField(main.BonusItems[i].name, GUILayout.MaxWidth(245));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField(
                "Probability (" + (100f * main.BonusItems[i].ProbabilityPercent / total_probability).ToString("F2") +
                "%)", GUILayout.MaxWidth(130));
            main.BonusItems[i].ProbabilityPercent = Mathf.RoundToInt(EditorGUILayout.Slider(main.BonusItems[i].ProbabilityPercent, 1, 100, GUILayout.MaxWidth(200)));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Angle", GUILayout.MaxWidth(130));
            main.BonusItems[i].Angle = Mathf.RoundToInt(EditorGUILayout.Slider(main.BonusItems[i].Angle, 0, 360, GUILayout.MaxWidth(200)));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.Space();
            EditorGUILayout.EndVertical();
            EditorGUILayout.EndHorizontal();
        }

        EditorUtility.SetDirty(main);
    }
}
