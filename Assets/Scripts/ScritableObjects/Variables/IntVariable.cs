using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Variable/Int")]
public class IntVariable : ScriptableObject, ISerializationCallbackReceiver
{
	public int initialValue;

	[NonSerialized] public int value;

	public void OnBeforeSerialize() {
	}

	public void OnAfterDeserialize() {
		value = initialValue;
	}
}
