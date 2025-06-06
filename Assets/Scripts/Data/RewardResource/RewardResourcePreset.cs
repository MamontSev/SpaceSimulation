using System;
using System.Collections.Generic;

using UnityEngine;
using SpaceSimulation.Core.RewardResource.Item;


#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
#endif

namespace SpaceSimulation.Data.RewardResource
{
	[CreateAssetMenu(menuName = "Data/RewardResourceData" , fileName = "RewardResourceData.asset")]
	public class RewardResourcePreset:ScriptableObject
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
				float width;
				float height = position.height;

				width = 100.0f;
				Rect valueRect = new Rect(px , py , width , height);
				int k = property.FindPropertyRelative("_selfType").enumValueIndex;
				EditorGUI.LabelField(valueRect , $"{(RewardResourceType)k}");
				px += width;


				width = 200.0f;
				valueRect = new Rect(px , py , width , height);
				EditorGUI.LabelField(valueRect , $"Prefab (RewardResourceItem)-");
				px += width;

				width = 150.0f;
				valueRect = new Rect(px , py , width , height);
				EditorGUI.ObjectField(valueRect , property.FindPropertyRelative("_prefab") ,typeof(RewardResourceItem) , GUIContent.none);
				px += width;

			}
		}



		[CustomEditor(typeof(RewardResourcePreset))]
		class RewardResourceDataCustomizer:Editor
		{
			public override void OnInspectorGUI()
			{
				if( GUI.changed )
				{
					EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
				}
				DrawDefaultInspector();
				RewardResourcePreset mt = (RewardResourcePreset)target;
				Undo.RegisterCompleteObjectUndo(mt , "RewardResourceDataCustomizer");


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







