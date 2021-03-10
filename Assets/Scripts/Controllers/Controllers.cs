using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Controllers : SingletonBehaviour<Controllers>
    {
        [SerializeField] protected Component[] m_ControllersPrefabs;

        private static Dictionary<Type, Component> m_ControllersDictionary;

        public static bool TryGet<T>(out T controller)
            where T : Component
        {
            controller = null;
            if (m_ControllersDictionary.TryGetValue(typeof(T), out Component component))
                controller = component as T;
            return controller != null;
        }

        public static T Get<T>()
            where T : Component
        {
            if (TryGet(out T controller))
                return controller;
            return null;
        }

        protected override void Awake()
        {
            base.Awake();

            for (int i = 0; m_ControllersPrefabs != null && i < m_ControllersPrefabs.Length; i++)
            {
                var controllerPrefab = m_ControllersPrefabs[i];
                var controller = Instantiate(controllerPrefab, transform);

                m_ControllersDictionary[controller.GetType()] = controller;
            }
        }
    }
}