using UnityEditor;
using UnityEngine;

namespace Puzzle
{
    [CustomEditor(typeof(MekanikPuzzleListrikPararel))]
    public class MekanikPuzzleListrikPararelEditor : Editor
    {
        void OnEnable()
        {
            SerializedProperty jumlahSambungan = serializedObject.FindProperty("JumlahSambungan");
            jumlahSambungan.intValue = Mathf.Clamp(jumlahSambungan.intValue, 1, 5); // Ensure it's between 1 and 5
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            SerializedProperty jumlahSambungan = serializedObject.FindProperty("JumlahSambungan");

            EditorGUILayout.PropertyField(jumlahSambungan);            

            byte jumlah = (byte)jumlahSambungan.intValue;

            // Draw lists conditionally based on JumlahSambungan
            ShowList("SaklarSambunganI", 1, jumlah);
            ShowList("SaklarSambunganII", 2, jumlah);
            ShowList("SaklarSambunganIII", 3, jumlah);
            ShowList("SaklarSambunganIV", 4, jumlah);
            ShowList("SaklarSambunganV", 5, jumlah);

            EditorGUILayout.PropertyField(serializedObject.FindProperty("triggerCompletes"), true);    
            serializedObject.ApplyModifiedProperties();
        }

        private void ShowList(string propertyName, byte index, byte jumlahSambungan)
        {
            if (index <= jumlahSambungan)
            {
                SerializedProperty list = serializedObject.FindProperty(propertyName);
                EditorGUILayout.PropertyField(list, true);
            }
            else
            {
                // Hide list if not within range
                EditorGUILayout.LabelField(propertyName + " (Hidden)");
            }
        }
    }
}
