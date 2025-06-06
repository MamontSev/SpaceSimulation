using System;
using System.Collections.Generic;

using UnityEngine;


#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
#endif

namespace SpaceSimulation.Data.RewardResource
{
	[Serializable]
	public class RewardResource
	{
		public RewardResource( RewardResourceType _selfType )
		{
			SelfType = _selfType;
		}

		public readonly RewardResourceType SelfType;

		[SerializeField]
		private GameObject _prefab;
		public GameObject Prafab => _prefab;

		//private float 
	}
	[CreateAssetMenu(menuName = "Data/RewardResourceData" , fileName = "RewardResourceData.asset")]
	public class RewardResourceData:ScriptableObject
	{
		public List<RewardResource> ItemList = new();



		


#if UNITY_EDITOR

		public void CheckState()
		{
			foreach( RewardResourceType type in Enum.GetValues(typeof(RewardResourceType)) )
			{
				bool contain = false;
				foreach( var item in ItemList )
				{
					if( item.SelfType == type )
					{
						contain = true;
						break;
					}
				}
				if( contain == false )
				{
					ItemList.Add(new RewardResource(type));
				}
			}
		}

		[CustomPropertyDrawer(typeof(RewardResource))]
		private class RowItemDrawer:PropertyDrawer
		{

			// Draw the property inside the given rect
			public override void OnGUI( Rect position , SerializedProperty property , GUIContent label )
			{
				float x = position.x;
				float y = position.y;
				float w = position.width;
				float h = position.height;
				Rect r = new Rect(x , y , w , h);

				EditorGUI.indentLevel = 1;

				float px = position.x;
				float py = position.y;
				float width = 100.0f;
				float height = position.height;

				width = 150.0f;
				Rect valueRect = new Rect(px , py , width , height);
				int k = property.FindPropertyRelative("_selfType").enumValueIndex;
			//	EditorGUI.LabelField(valueRect , $"{(TaskType)k}");
				px += width;

				width = 120.0f;
				valueRect = new Rect(px , py , width , height);
				EditorGUI.PropertyField(valueRect , property.FindPropertyRelative("_item") , GUIContent.none);
				px += width;

			}
		}



		[CustomEditor(typeof(RewardResourceData))]
		class RewardResourceDataCustomizer:Editor
		{
			public override void OnInspectorGUI()
			{
				if( GUI.changed )
				{
					EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
				}
				DrawDefaultInspector();
				RewardResourceData mt = (RewardResourceData)target;
				Undo.RegisterCompleteObjectUndo(mt , "Player name change");


				if( GUILayout.Button("CheckState" , GUILayout.ExpandWidth(false)) )
				{
					mt.CheckState();
				}

				if( GUI.changed )
				{
					EditorUtility.SetDirty(this);
					EditorSceneManager.MarkSceneDirty(UnityEngine.SceneManagement.SceneManager.GetActiveScene());
				}
			}

		}


#endif
	}
}







