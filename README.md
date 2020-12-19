# VMagicMirror_MotionExporter

## About

UnityのHumanoid Animationをエディターからシリアライズし、ランタイムでデシリアライズする処理を実装したプロジェクトです。

- AssetBundleを使うほどではない場面での使用を想定しています。
- UnityのAnimation Clipに依存し、それ以外のデータ規格には依存しません。

初期実装の時点ではUnity 2019.4のアニメーションデータに沿った情報をエクスポートするようになっています。


A project to serialize Unity Humanoid Motion on editor, and deserialize at runtime.

- Can be thought to be a ligher version of AssetBundle.
- Dependency is Unity Animation Clip data, and independent to other motion file format (like fbx).

In the first implementation data format is based on Unity 2019.4.14f1.

## How to Use for VMagicMirror

[Japanese](https://malaybaku.github.io/VMagicMirror/tips/use_custom_motion)

[English](https://malaybaku.github.io/VMagicMirror/en/tips/use_custom_motion)


## How to Use for General Purpose

### JP

バージョン: Unity 2019.4.x (推奨バージョン: 2019.4.14f)

- エクスポート: エディタ上で適当なGameObjectに`MotionExporter`コンポーネントをアタッチし、エクスポートしたいクリップを指定して`Export`ボタンをクリックすることで、`StreamingAssets`以下にファイルがエクスポートされます。
- インポート: エクスポートされたデータを`MotionImporter`に読み込ませることで`AnimationClip`を復元します。
- 実行: 復元したクリップ情報を`HumanoidAnimationSetter`コンポーネントがアタッチされたオブジェクトで再生しつつ、マッスル等のデータをヒューマノイドモデルに転写します。

実際にアニメーションをインポート、実行する例として`MotionTestPlay`スクリプトが入っています。

- 適当なヒューマノイドモデルをシーン上に配置する
- 空のGameObjectを作成し、`HumanoidAnimationSetter`と`MotionTestPlay`コンポーネントを追加
- `MotionTestPlay`コンポーネントを以下のように設定
    - `FileName`: エクスポートしたファイルの名称
    - `Source`: このオブジェクト自身
    - `Target`: ヒューマノイドモデル
- エディタ上、またはシーンをビルドして実行する

### EN 

Version: Unity 2019.4.x (recommended2019.4.14f)

- Export: Add `MotionExporter` component to some GameObject on the scene, and set AnimationClip to export, then click `Export` on the component to save the data in `StreamingAssets` folder.
- Import: `MotionImporter` class does it.
- Run: Play imported clip on a GameObject with `HumanoidAnimationSetter` component, and copy the pose data including Muscle to model.


`MotionTestPlay` script is an example to run animation. 

- Put a humanoid model onto the scene. Confirm the `Animator` component's `Animator Controller` is set `None`.
- Create an empty GameObject, and add `HumanoidAnimationSetter` component and `MotionTestPlay` component to it.
- Setup `MotionTestPlay`:
    - `FileName`: Exported file name
    - `Source`: Self
    - `Target`: Humanoid model object
- Play on the editor, or play by build the scene.


## OSS License

[UniVRM](https://github.com/vrm-c/UniVRM)

MIT License

Copyright (c) 2020 VRM Consortium
Copyright (c) 2018 Masataka SUMI for MToon

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.


[Simple Animation](https://github.com/Unity-Technologies/SimpleAnimation)

MIT License

Copyright (c) 2017 Unity Technologies

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.