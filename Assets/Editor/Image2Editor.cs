
using UnityEngine;
using UnityEditor;
using UnityEditor.UI;

[CustomEditor(typeof(Image2))]
public class Image2Editor : ImageEditor
{
	public new Image2 target;

	private SerializedProperty _spFlipHor;
	private SerializedProperty _spFlipVer;
	private GUIContent _gcFlipHor;
	private GUIContent _gcFlipVer;

	protected override void OnEnable()
	{
		base.OnEnable();

		target = base.target as Image2;

		_spFlipHor = serializedObject.FindProperty("flipHor");
		_spFlipVer = serializedObject.FindProperty("flipVer");
		_gcFlipHor = EditorGUIUtility.TrTextContent("ˮƽ��ת", null);
		_gcFlipVer = EditorGUIUtility.TrTextContent("��ֱ��ת", null);
	}

	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		EditorGUILayout.PropertyField(_spFlipHor, _gcFlipHor);
		EditorGUILayout.PropertyField(_spFlipVer, _gcFlipVer);

		if (GUI.changed)
		{
			EditorUtility.SetDirty(target);
		}
		serializedObject.ApplyModifiedProperties();
	}
}
