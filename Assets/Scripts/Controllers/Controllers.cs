using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Controllers : SingletonBehaviour<Controllers>
    {
        [SerializeField] protected Component[] m_Controllers;

        private static Dictionary<Type, Component> m_ControllersDictionary;
        
        [SerializeField] protected CameraController m_CameraControllerPrefab;

        private static CameraController m_CameraController;

        public static CameraController CameraController
        {
            get
            {
                if (m_CameraController == null)
                    m_CameraController = Instantiate(Instance.m_CameraControllerPrefab, Instance.transform);
                return m_CameraController;
            }
        }
    }
}