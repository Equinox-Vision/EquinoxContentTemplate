# Equinox XR Asset Bundle development template

Unity version: 2021.1.4f1

This repository contains a Unity project which is set up to build assets for the [Equinox XR Augmented Reality platform](https://equinox.vision). Its purpose is to facilitate building of Asset Bundle files for Android and iOS platforms. Hence, the Unity installation where it is used must contain support for building Android and iOS projects.

This is a very much beta software. There be dragons.

## Tutorial: Creating a new asset for the Equinox XR platform

Fork this repository in GitHub, then clone it. Open it in Unity.

First check that assets are being built correctly, by using the `Assets -> Build All Asset Bundles` menu command.

Next, locate the `EquinoxPrefabsRoot` directory in the file system pane. There are two template files here:

* `EqPoiSpinningCube` prefab
* `PoiTypeSpinningCube` asset

Note the `EqPoi` and `PoiType` prefixes in their names. They are important.

Copy the two files (by holding down Ctrl and dragging the files) and name them accordingly for your asset. We'll use a `SpinningBall` name here, so the two copied files will be named:

* `EqPoiSpinningBall`
* `PoiTypeSpinningBall`

Select the `PoiTypeSpinningBall` asset and edit its properties. We'll change them like this:

* `Poi Type Name`: Spinning Ball
* `Assigned prefab`: you'll need to drag and drop the `EqPoiSpinningBall` prefab here
* `Poi Type`: leave at 10001
* `Poi Subtype`: 2

The type and subtype fields uniquely identify an asset within the Equinox XR platform.

Open the `EqPoiSpinningBall` prefab, and replace the Cube 3D mesh within it with a sphere. Adjust the material to be the same as the one used for the cube, and set the sphere's transform's Y coordinate to 0.5. For the sphere object, change its `Tag` to `PoiPrefab`. Save everything.

Now build the asset bundle with `Assets -> Build All Asset Bundles`.

The asset bundles will appear in the `Builds/Assets` folder under the repo checkout's root directory. Send them to Equinox Developers to be included in the platform.

## Animator triggers

(very much beta / under development)

Any animators set on any game objects can and will be triggered with the following triggers, when circumstances are right:

* `Touch` - when the user touches the prefab root collider
* `Correct` - when the user participates in a quiz or a game which has correct / incorrect semantics
* `Wrong` - when the user participates in a quiz or a game which has correct / incorrect semantics

These animator triggers gan do whatever animations are appropriate, including just hiding and showing (disabling / enabling) prefabs.

There is an example with an animator, some prefabs and animations in the `EquinoxPrefabSupport/Effects` folder. To use it, drop the `CorrectEffect` and `WrongEffect` prefabs (which you will need to heavily edit to include resources you need there) into the `EqPoi` prefab, and set its animator to the `CorrectWrongController`. When the object is used in a game context, it will behave as desiged.

## Some additional notes and information

* The `MessageCanvas` and `PhotoCanvas` prefabs in the asset are mandatory, and with their specific hierarchy structure, though you can style them as you wish.
* Adjust the collider on the `EqPoi` prefab as you like. It will determine which part of the object reacts to clicks (user's finger taps). In the future, a more complex interaction model will be available.
* Objects created in this way can participate in all Equinox XR interactions, such as audio attachments, animated GIFs and dialog trees.

## Contact us

Contact us at info@equinox.vision .

