﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Microsoft.MixedReality.Toolkit.Experimental.SpatialAwareness;
using UnityEngine;

namespace Microsoft.MixedReality.Toolkit.Experimental.SpatialAwareness
{
    public interface IWindowsMixedRealitySceneUnderstanding
    {
        /// <returns></returns>
        bool TryGetOcclusionMask(System.Guid quadId, ushort textureWidth, ushort textureHeight, out byte[] mask);

        bool TryFindCentermostPlacement(SpatialAwarenessSceneObject.Quad onQuad, Vector2 forSize, out Vector2 bestLocationOnPlane);
    }
}