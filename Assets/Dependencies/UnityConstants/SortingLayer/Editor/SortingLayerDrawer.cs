using System;
using UnityEditor;
using UnityEngine;

namespace HouraiTeahouse {

    [CustomPropertyDrawer(typeof(SortingLayerAttribute))]
    public class SortingLayerDrawer : PropertyDrawer {

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            string[] sortingLayerNames = SortingLayerHelper.SortingLayerNames;
            if (property.propertyType != SerializedPropertyType.Integer) {
                EditorGUI.HelpBox(position,
                    string.Format("{0} is not an integer but has [SortingLayer].", property.name),
                    MessageType.Error);
            }
            else if (sortingLayerNames != null) {
                EditorGUI.BeginProperty(position, label, property);

                // Look up the layer name using the current layer ID
                string oldName = SortingLayerHelper.GetSortingLayerNameFromID(property.intValue);

                // Use the name to look up our array index into the names list
                int oldLayerIndex = Array.IndexOf(sortingLayerNames, oldName);

                // Show the popup for the names
                int newLayerIndex = EditorGUI.Popup(position, label.text, oldLayerIndex, sortingLayerNames);

                // If the index changes, look up the ID for the new index to store as the new ID
                if (newLayerIndex != oldLayerIndex) {
                    property.intValue = SortingLayerHelper.GetSortingLayerIDForIndex(newLayerIndex);
                }

                EditorGUI.EndProperty();
            }
            else {
                EditorGUI.BeginProperty(position, label, property);
                int newValue = EditorGUI.IntField(position, label.text, property.intValue);
                if (newValue != property.intValue) {
                    property.intValue = newValue;
                }
                EditorGUI.EndProperty();
            }
        }

    }

}