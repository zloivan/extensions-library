# Unity Extensions Library


Unity Extensions Library is a growing collection of handy extension methods, helpers, attributes, and other utilities designed to enhance and simplify your Unity development workflow. Whether you're a seasoned developer or just starting, this library aims to provide tools that will help streamline your coding process and add efficiency to your projects.

## Installation

1. Open your Unity project.
2. In the top menu, go to `Window` -> `Package Manager`.
3. Click on the `+` icon in the top left corner and select `Add package from git URL...`.
4. Enter the following URL: `https://github.com/zloivan/extensions-library.git`
5. Click `Add` to install the package.

## Overview
| Class | Method Name | Description |
| --- | --- | --- |
| `DirectoryInfo` | `HasSubDirectory` | Determines whether the directory has a given directory in its hierarchy of children |
| `DirectoryInfo` | `FindParentDirectoryWithName` | Finds a parent directory with a given name, or null if no such parent directory exists |
| `string` | `CanMakeRelative` | Returns a value indicating whether a path can be made relative to another |
| `string` | `MakeRelative` | Returns a path string to path that is relative to the parent path |
| `string` | `TryMakeRelative` | Tries to make a path that is relative from parent path to path |
| `string` | `Combine` | Combines two paths, and replaces all backslashes with forward slash |
| `ToggleGroup` | `GetToggles` | Retrieves the list of Toggle components within the specified ToggleGroup |
| `Vector3` | `ToVector2` | Converts a Vector3 to a Vector2 by taking only the x and y components |
| `Vector3` | `Abs` | Returns a new Vector3 with each component absolute |
| `Vector3` | `OnScreen` | Converts the Vector3 to screen coordinates using the specified Camera |
| `Vector3` | `With` | Returns a new Vector3 with the specified components, or the original components if no values are provided |
| `Mathf` | `Min` | Returns the minimum value from a collection of double values |
| `Mathf` | `Max` | Returns the maximum value from a collection of double values |
| `Mathf` | `PointDistanceToLine` | Distance from a point to a line |
| `Mathf` | `Hermite` | Returns a smooth value between start and end based on t |
| `Mathf` | `StackHermite` | Returns a smooth value between start and end based on t with multiple interpolations |
| `string` | `IsNullOrWhiteSpace` | Checks if a string is Null or white space |
| `string` | `IsNullOrEmpty` | Checks if a string is Null or empty |
| `string` | `IsBlank` | Checks if a string contains null, empty or white space |
| `string` | `OrEmpty` | Checks if a string is null and returns an empty string if it is |
| `string` | `Shorten` | Shortens a string to the specified maximum length |
| `string` | `Slice` | Slices a string from the start index to the end index |
| `string` | `ToPascalCase` | Converts snake_case or SCREAMING_SNAKE_CASE to PascalCase |
| `string` | `FromJson` | Deserializes the provided JSON string into an object of type T |
| `string` | `ToJson` | Serializes the provided object of type T into a JSON string |
| `LayerMask` | `Contains` (int) | Checks if the given layer number is contained in the LayerMask |
| `LayerMask` | `Contains` (GameObject) | Checks if the given GameObject's layer is contained in the LayerMask |
| `LayerMask` | `Contains` (Component) | Checks if the given Component's layer is contained in the LayerMask |
| `Vector3Int` | `ToVector2Int` | Converts a Vector3Int to a Vector2Int by discarding the z-coordinate |
| `PropertyInfo` | `IsAutoProperty` | Determines whether a property is an auto property |
| `RectInt` | `Intersection` | Computes the intersection of two RectInt objects |
| `IEnumerable<T>` | `ForEach` (Action) | Performs the specified action on each element of the IEnumerable |
| `IEnumerable<T>` | `ForEach` (Action with index) | Performs the specified action on each element of the IEnumerable, providing the index |
| `Component` | `GetOrAddComponent` | Gets or adds a component to the GameObject |
| `Transform` | `InRangeOf` | Checks if the transform is within a certain distance and optionally within a certain angle from the target |
| `Transform` | `Reset` | Resets the transform's position, scale, and rotation to their default values |
| `Transform` | `Children` | Gets an enumerable collection of the transform's children |
| `Transform` | `ActiveChildren` | Gets an enumerable collection of the transform's active children |
| `Transform` | `DestroyChildren` | Destroys all child game objects of the given transform |
| `Transform` | `DestroyChildrenImmediate` | Immediately destroys all child game objects of the given transform |
| `Transform` | `EnableChildren` | Enables all child game objects of the given transform |
| `Transform` | `DisableChildren` | Disables all child game objects of the given transform |
| `Transform` | `ForEveryChild` | Executes the specified action for every child of the given transform |
| `Transform` | `Move` | Moves the transform by a specific value in the X, Y, and Z axes |
| `Vector2Int` | `Abs` | Returns a new Vector2Int with the absolute values of the components |
| `Vector2Int` | `ToVector3Int` | Converts the Vector2Int to a Vector3Int with a zero z-component |
| `Vector2Int` | `ToVector3` | Converts the Vector2Int to a Vector3 with a zero z-component |
| `IList<T>` | `RandomObject` | Returns a random object from the list using Unity's Random.Range |
| `IList<T>` | `Clone` | Creates a new list that is a copy of the original list |
| `IList<T>` | `Swap` | Swaps two elements in the list at the specified indices |
| `IList<T>` | `Shuffle` | Shuffles the elements in the list using the Durstenfeld implementation of the Fisher-Yates algorithm |
| `GameObject` | `OrNull` | Returns the object itself if it exists, null otherwise |
| `GameObject` | `GetOrAddComponent` | Gets the specified component if it exists on the GameObject; otherwise, adds it |
| `GameObject` | `DestroyChildren` | Destroys all child GameObjects of the specified GameObject |
| `GameObject` | `EnableChildren` | Enables all child GameObjects of the specified GameObject |
| `GameObject` | `DisableChildren` | Disables all child GameObjects of the specified GameObject |
| `GameObject` | `ResetTransformation` | Resets the GameObject's transform's position, rotation, and scale to their default values |
| `GameObject` | `Path` | Returns the hierarchical path in the Unity scene hierarchy for this GameObject |
| `GameObject` | `PathFull` | Returns the full hierarchical path in the Unity scene hierarchy for this GameObject |
| `GameObject` | `SetLayersRecursively` | Recursively sets the provided layer for this GameObject and all of its descendants |
| `GameObject` | `HideInHierarchy` | Hides the GameObject in the Hierarchy view |
| `GameObject` | `Move` | Moves the specified GameObject in the Unity scene hierarchy |
| `RectTransform` | `GetWorldRect` | Gets the world space Rect of the RectTransform |
| `RectTransform` | `GetScreenRect` | Gets the screen space Rect of the RectTransform |
| `RectTransform` | `Move` | Moves the RectTransform by a specific value in the X and Y axes |
| `Vector2` | `Clamp` | Clamps the value of a Vector2 |
| `Vector2` | `RotatePoint` | Rotates a Vector2 by an angle |
| `Vector2` | `RotatePoint` (around point) | Rotates a Vector2 around a point by an angle |
| `Rect` | `ToRectInt` | Converts a Rect to RectInt |
| `Rect` | `SetWidth` | Sets the width of the rect |
| `Rect` | `SetHeight` | Sets the height of the rect |
| `Rect` | `SetSize` | Sets the size of the rect |
| `Rect` | `HorizontalPadding` | Adds horizontal padding to the rect |
| `Rect` | `VerticalPadding` | Adds vertical padding to the rect |
| `Rect` | `Padding` | Adds padding to the rect |
| `Rect` | `AlignLeft` | Aligns the rect to the left |
| `Rect` | `AlignCenter` | Aligns the rect to the center |
| `Rect` | `AlignRight` | Aligns the rect to the right |
| `Rect` | `AlignTop` | Aligns the rect to the top |
| `Rect` | `AlignMiddle` | Aligns the rect to the middle |
| `Rect` | `AlignBottom` | Aligns the rect to the bottom |
| `Rect` | `AlignCenterX` | Aligns the rect center on X axis |
| `Rect` | `AlignCenterY` | Aligns the rect center on Y axis |
| `Rect` | `AlignCenterXY` | Aligns the rect center on both axes |
| `Rect` | `Expand` | Expands the rect by the specified amount |
| `Rect` | `Split` | Splits the rect into multiple parts |
| `Rect` | `SplitVertical` | Splits the rect vertically into multiple parts |
| `Rect` | `SplitGrid` | Splits the rect into a grid pattern |
| `Rect` | `SplitTableGrid` | Splits the rect into a table grid pattern |
| `Rect` | `SetCenterX` | Sets the center X position of the rect |
| `Rect` | `SetCenterY` | Sets the center Y position of the rect |
| `Rect` | `SetCenter` | Sets the center position of the rect |
| `Rect` | `SetPosition` | Sets the position of the rect |
| `Rect` | `ResetPosition` | Resets the position of the rect |
| `Rect` | `AddPosition` | Adds to the position of the rect |
| `Rect` | `SetX` | Sets the X position of the rect |
| `Rect` | `AddX` | Adds to the X position of the rect |
| `Rect` | `SubX` | Subtracts from the X position of the rect |
| `Rect` | `SetY` | Sets the Y position of the rect |
| `Rect` | `AddY` | Adds to the Y position of the rect |
| `Rect` | `SubY` | Subtracts from the Y position of the rect |
| `Rect` | `SetMin` | Sets the minimum point of the rect |
| `Rect` | `AddMin` | Adds to the minimum point of the rect |
| `Rect` | `SubMin` | Subtracts from the minimum point of the rect |
| `Rect` | `SetMax` | Sets the maximum point of the rect |
| `Rect` | `AddMax` | Adds to the maximum point of the rect |
| `Rect` | `SubMax` | Subtracts from the maximum point of the rect |
| `Rect` | `SetXMin` | Sets the minimum X value of the rect |
| `Rect` | `AddXMin` | Adds to the minimum X value of the rect |
| `Rect` | `SubXMin` | Subtracts from the minimum X value of the rect |
| `Rect` | `SetXMax` | Sets the maximum X value of the rect |
| `Rect` | `AddXMax` | Adds to the maximum X value of the rect |
| `Rect` | `SubXMax` | Subtracts from the maximum X value of the rect |
| `Rect` | `SetYMin` | Sets the minimum Y value of the rect |
| `Rect` | `AddYMin` | Adds to the minimum Y value of the rect |
| `Rect` | `SubYMin` | Subtracts from the minimum Y value of the rect |
| `Rect` | `SetYMax` | Sets the maximum Y value of the rect |
| `Rect` | `AddYMax` | Adds to the maximum Y value of the rect |
| `Rect` | `SubYMax` | Subtracts from the maximum Y value of the rect |
| `Rect` | `MinWidth` | Sets a minimum width for the rect |
| `Rect` | `MaxWidth` | Sets a maximum width for the rect |
| `Rect` | `MinHeight` | Sets a minimum height for the rect |
| `Rect` | `MaxHeight` | Sets a maximum height for the rect |
| `Rect` | `ExpandTo` | Expands the rect to include the specified position |
| `Camera` | `GetViewportExtentsWithMargin` | Calculates and returns viewport extents with an optional margin |
| `Camera` | `ScreenToWorldPointWithMargin` | Converts screen coordinates to world coordinates considering the viewport margin |
