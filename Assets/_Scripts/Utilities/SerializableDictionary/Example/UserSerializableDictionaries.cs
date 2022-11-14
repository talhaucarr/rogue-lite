using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class IntFloatDictionary : SerializableDictionary<int, float> { }

[Serializable]
public class StringStringDictionary : SerializableDictionary<string, string> {}

[Serializable]
public class StringIntDictionary : SerializableDictionary<string, int> { }

[Serializable]
public class IntSpriteDictionary : SerializableDictionary<int, Sprite> { }
[Serializable]
public class StringAnimationClipDictionary : SerializableDictionary<string, AnimationClip> { }

[Serializable]
public class ObjectColorDictionary : SerializableDictionary<UnityEngine.Object, Color> {}

[Serializable]
public class ColorArrayStorage : SerializableDictionary.Storage<Color[]> {}

[Serializable]
public class AnimationClipStorage : SerializableDictionary.Storage<AnimationClip[]> {}

[Serializable]
public class StringColorArrayDictionary : SerializableDictionary<string, Color[], ColorArrayStorage> {}
[Serializable]
public class StringAnimationClipArrayDictionary : SerializableDictionary<string, AnimationClip[], AnimationClipStorage> {}

[Serializable]
public class MyClass
{
    public int i;
    public string str;
}

[Serializable]
public class QuaternionMyClassDictionary : SerializableDictionary<Quaternion, MyClass> {}

[Serializable]
public class Vector2IntToIntDictionary : SerializableDictionary<Vector2Int, int> { }

[Serializable]
public class Vector2IntToGameObject : SerializableDictionary<Vector2Int, GameObject> { }