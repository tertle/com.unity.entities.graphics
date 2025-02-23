# Entities Graphics Fork

This fork provides performance optimizations, quick fixes, and improvements to the entities package. It will never add new features. Therefore, as long as you don't depend on some obscure behavior, you should always be able to switch between the official package and this fork without any issues.

## Changes

## Fixes

- Fake compile errors.
- Safety issue in OnPerformCulling.

## Changed

- Cache entities graphics type handles.

# Entities Graphics

Entities Graphics provides systems and components for rendering [ECS](https://docs.unity3d.com/Packages/com.unity.entities@latest) entities. Entities Graphics is not a render pipeline: it is a system that collects the data necessary for rendering ECS entities, and sends this data to Unity's existing rendering architecture.