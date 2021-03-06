using System;
using System.Collections.Generic;
using UnityEngine;
using Common;

namespace Game
{
    public class Controllers : SingletonBehaviour<Controllers>
    {
        [SerializeField] protected Component[] m_Controllers;

        private static Dictionary<Type, Component> m_ControllersDictionary;

        public static T Get<T>() where T : Component
        {
            var type = typeof(T);
            if (m_ControllersDictionary.TryGetValue(type, out Component component))
            {
                return component as T;
            }
            if (Instance.m_Controllers.TryFind(c => c is T, out component))
            {
                m_ControllersDictionary[type] = component;
                return component as T;
            }
            return default;
        }
    }
}