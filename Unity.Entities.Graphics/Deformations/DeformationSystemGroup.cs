using Unity.Entities;
using UnityEngine.Rendering;

namespace Unity.Rendering
{
    /// <summary>
    /// Represents a system group that contains all systems that handle and execute mesh deformations such as skinning and blend shapes.
    /// </summary>
    [WorldSystemFilter(WorldSystemFilterFlags.Default | WorldSystemFilterFlags.Editor)]
    [UpdateInGroup(typeof(PresentationSystemGroup)), UpdateAfter(typeof(RegisterMaterialsAndMeshesSystem)), UpdateBefore(typeof(EntitiesGraphicsSystem))]
    public sealed partial class DeformationsInPresentation : ComponentSystemGroup
    {
        /// <summary>
        /// Called when this system is created.
        /// </summary>
        protected override void OnCreate()
        {
            if (UnityEngine.SystemInfo.graphicsDeviceType == GraphicsDeviceType.Null)
            {
                UnityEngine.Debug.LogWarning("Warning: No Graphics Device found. Deformation systems will not run.");
                Enabled = false;
            }

            base.OnCreate();
        }
    }


    [WorldSystemFilter(WorldSystemFilterFlags.Default | WorldSystemFilterFlags.Editor)]
    [UpdateInGroup(typeof(DeformationsInPresentation))]
    partial class PushMeshDataSystem : SystemBase { }

    [WorldSystemFilter(WorldSystemFilterFlags.Default | WorldSystemFilterFlags.Editor)]
    [UpdateInGroup(typeof(DeformationsInPresentation)), UpdateAfter(typeof(PushMeshDataSystem)), UpdateBefore(typeof(SkinningDeformationSystem))]
    partial class PushSkinMatrixSystem : SystemBase { }

    [WorldSystemFilter(WorldSystemFilterFlags.Default | WorldSystemFilterFlags.Editor)]
    [UpdateInGroup(typeof(DeformationsInPresentation)), UpdateAfter(typeof(PushMeshDataSystem)), UpdateBefore(typeof(BlendShapeDeformationSystem))]
    partial class PushBlendWeightSystem : SystemBase { }

    [WorldSystemFilter(WorldSystemFilterFlags.Default | WorldSystemFilterFlags.Editor)]
    [UpdateInGroup(typeof(DeformationsInPresentation)), UpdateAfter(typeof(PushMeshDataSystem))]
    partial class InstantiateDeformationSystem : SystemBase { }

    [WorldSystemFilter(WorldSystemFilterFlags.Default | WorldSystemFilterFlags.Editor)]
    [UpdateInGroup(typeof(DeformationsInPresentation)), UpdateAfter(typeof(InstantiateDeformationSystem))]
    partial class BlendShapeDeformationSystem : SystemBase { }

    [WorldSystemFilter(WorldSystemFilterFlags.Default | WorldSystemFilterFlags.Editor)]
    [UpdateInGroup(typeof(DeformationsInPresentation))]
    [UpdateAfter(typeof(BlendShapeDeformationSystem))]
    partial class SkinningDeformationSystem : SystemBase { }
}
