using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Event/IntEvent")]
public class IntEvent : ScriptableObjectBase {
	public UnityAction<int> onEventRaised;

	public void RaiseEvent(int value) {
		onEventRaised?.Invoke(value);

	}
}
