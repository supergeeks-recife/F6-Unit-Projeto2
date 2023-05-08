using System;
using UnityEngine;
using UnityEngine.Events;


//Separamos os nossos eventos personalizados em um único arquivo para facilitar a manutenção


[Serializable]
public class FloatEvent : UnityEvent<float> { }

[Serializable]
public class IntEvent : UnityEvent<int> { }

[Serializable]
public class BoolEvent : UnityEvent<bool> { }

[Serializable]
public class StringEvent : UnityEvent<string> { }

[Serializable]
public class GameObjectEvent : UnityEvent<GameObject> { }

[Serializable]
public class InputEvent : UnityEvent<float, float> { }
