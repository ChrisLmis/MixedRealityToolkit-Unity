﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.﻿

using Microsoft.MixedReality.Toolkit.Utilities.Editor;
using System.Linq;
using UnityEditor;

namespace Microsoft.MixedReality.Toolkit.Editor.SpatialAwareness
{
    [CustomEditor(typeof(Experimental.SpatialAwareness.MixedRealitySpatialAwarenessSceneUnderstandingObserverProfile))]
    public class MixedRealitySpatialAwarenessSceneUnderstandingObserverProfileInspector : BaseMixedRealityToolkitConfigurationProfileInspector
    {
        // BaseSpatialAwarenessObserverProfile

        private SerializedProperty startupBehavior;
        private SerializedProperty updateInterval;

        // MixedRealitySpatialAwarenessSceneUnderstandingObserverProfile

        private SerializedProperty autoUpdate;
        private SerializedProperty physicsLayer;
        private SerializedProperty surfaceTypes;
        private SerializedProperty instantiationBatchRate;
        private SerializedProperty defaultMaterial;
        private SerializedProperty shouldLoadFromFile;
        private SerializedProperty serializedScene;
        private SerializedProperty generateMeshes;
        private SerializedProperty generatePlanes;
        private SerializedProperty createGameObjects;
        private SerializedProperty generateEnvironmentMesh;
        private SerializedProperty inferRegions;
        private SerializedProperty firstUpdateDelay;
        private SerializedProperty levelOfDetail;
        private SerializedProperty usePersistentObjects;
        private SerializedProperty queryRadius;
        private SerializedProperty getOcclusionMask;
        private SerializedProperty occlusionMaskResolution;
        private SerializedProperty orientScene;

        private const string ProfileTitle = "Scene Understanding Observer Settings";
        private const string ProfileDescription = "Settings for high-level environment representation";

        protected override void OnEnable()
        {
            base.OnEnable();

            startupBehavior = serializedObject.FindProperty("startupBehavior");
            autoUpdate = serializedObject.FindProperty("autoUpdate");
            updateInterval = serializedObject.FindProperty("updateInterval");

            firstUpdateDelay = serializedObject.FindProperty("firstUpdateDelay");

            shouldLoadFromFile = serializedObject.FindProperty("shouldLoadFromFile");
            serializedScene = serializedObject.FindProperty("serializedScene");

            levelOfDetail = serializedObject.FindProperty("levelOfDetail");
            usePersistentObjects = serializedObject.FindProperty("usePersistentObjects");

            instantiationBatchRate = serializedObject.FindProperty("instantiationBatchRate");
            defaultMaterial = serializedObject.FindProperty("defaultMaterial");
            generatePlanes = serializedObject.FindProperty("generatePlanes");
            generateMeshes = serializedObject.FindProperty("generateMeshes");
            createGameObjects = serializedObject.FindProperty("createGameObjects");
            generateEnvironmentMesh = serializedObject.FindProperty("generateEnvironmentMesh");

            physicsLayer = serializedObject.FindProperty("physicsLayer");
            surfaceTypes = serializedObject.FindProperty("surfaceTypes");
            inferRegions = serializedObject.FindProperty("inferRegions");
            queryRadius = serializedObject.FindProperty("queryRadius");
            getOcclusionMask = serializedObject.FindProperty("getOcclusionMask");
            occlusionMaskResolution = serializedObject.FindProperty("occlusionMaskResolution");
            orientScene = serializedObject.FindProperty("orientScene");
        }

        public override void OnInspectorGUI()
        {
            RenderProfileHeader(ProfileTitle, ProfileDescription, target, true, BackProfileType.SpatialAwareness);

            //using (new GUIEnabledWrapper(!IsProfileLock((BaseMixedRealityProfile)target)))
            using (new GUIEnabledWrapper())
            {
                serializedObject.Update();

                EditorGUILayout.LabelField("Life cycle", EditorStyles.boldLabel);
                {
                    EditorGUILayout.PropertyField(startupBehavior);
                    EditorGUILayout.PropertyField(autoUpdate);
                    EditorGUILayout.PropertyField(updateInterval);
                    EditorGUILayout.PropertyField(firstUpdateDelay);
                }
                EditorGUILayout.Space();

                EditorGUILayout.LabelField("Observer", EditorStyles.boldLabel);
                {
                    EditorGUILayout.PropertyField(surfaceTypes);
                    EditorGUILayout.PropertyField(queryRadius);
                    EditorGUILayout.PropertyField(levelOfDetail);
                    EditorGUILayout.PropertyField(usePersistentObjects);
                    EditorGUILayout.PropertyField(inferRegions);
                    EditorGUILayout.PropertyField(generatePlanes);
                    EditorGUILayout.PropertyField(generateMeshes);
                    EditorGUILayout.PropertyField(generateEnvironmentMesh);
                    EditorGUILayout.PropertyField(getOcclusionMask);
                    EditorGUILayout.PropertyField(occlusionMaskResolution);
                }
                EditorGUILayout.Space();

                EditorGUILayout.LabelField("Observer Debugging", EditorStyles.boldLabel);
                {
                    EditorGUILayout.PropertyField(shouldLoadFromFile);
                    EditorGUILayout.PropertyField(serializedScene);
                    EditorGUILayout.PropertyField(orientScene);
                    EditorGUILayout.PropertyField(createGameObjects);
                    EditorGUILayout.PropertyField(instantiationBatchRate);
                    EditorGUILayout.PropertyField(physicsLayer);
                    EditorGUILayout.PropertyField(defaultMaterial);
                }

                serializedObject.ApplyModifiedProperties();
            }
        }

        protected override bool IsProfileInActiveInstance()
        {
            var profile = target as BaseMixedRealityProfile;

            return MixedRealityToolkit.IsInitialized && profile != null &&
                   MixedRealityToolkit.Instance.HasActiveProfile &&
                   MixedRealityToolkit.Instance.ActiveProfile.SpatialAwarenessSystemProfile != null &&
                   MixedRealityToolkit.Instance.ActiveProfile.SpatialAwarenessSystemProfile.ObserverConfigurations != null &&
                   MixedRealityToolkit.Instance.ActiveProfile.SpatialAwarenessSystemProfile.ObserverConfigurations.Any(s => s.ObserverProfile == profile);
        }
    }
}