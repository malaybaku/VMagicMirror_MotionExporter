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

## Install

Import `.unitypackage` on Releases page.

## How to Use for VMagicMirror

[Japanese](https://malaybaku.github.io/VMagicMirror/tips/use_custom_motion)

[English](https://malaybaku.github.io/VMagicMirror/en/tips/use_custom_motion)


## How to Use for General Purpose

### JP

バージョン: Unity 2019.4.x (推奨バージョン: 2019.4.14f)

- エクスポート: エディタ上で適当なGameObjectに`MotionExporter`コンポーネントをアタッチし、エクスポートしたいクリップを指定して`Export`ボタンをクリックすることで、`StreamingAssets`以下にファイルがエクスポートされます。
- インポート: エクスポートされたデータを`MotionImporter`で読み込んで`DeserializedMotion`を生成します。
- 実行: `DeserializedMotion`が`AnimationClip`の代替となり、`HumanoidAnimationSetter`が`Animator`の代替となります。

実際にアニメーションをインポート、実行する例として`MotionTestPlay`スクリプトが入っています。このスクリプトの動作を次のようにして確認できます。

- エクスポート作業を行い、`StreamingAssets`以下にファイルを出力する
- `Assets/Baku/VMagicMirror_MotionExporter/Scenes/MotionExporter`を開く
- 適当なヒューマノイドモデルをシーン上に配置する
- `MotionTestPlay`コンポーネントを次のように設定する
    - `FileName`: エクスポートしたファイルの名称
    - `Target`: シーン上に配置したヒューマノイド
    - `OnlyUpperBody`: 上半身のモーションだけ再生したい場合は`true` 
- エディタ上で実行する。または、シーンをビルドして実行する


### EN 

Version: Unity 2019.4.x (recommended2019.4.14f)

- Export: Add `MotionExporter` component to some GameObject on the scene, and set AnimationClip to export, then click `Export` on the component to save the data in `StreamingAssets` folder.
- Import: `MotionImporter` class translate serialized json to `DeserializedMotion`.
- Run: `DeseiralizedMotion` works like `AnimationClip` and `HumanoidAnimationSetter` is an alternative of `Animator`.

`MotionTestPlay` scripts is an example, and you can test it by following steps.

- Follow Export step to get output file in `StreamingAssets` folder.
- Open `Assets/Baku/VMagicMirror_MotionExporter/Scenes/MotionExporter`
- Put a humanoid model on the scene
- Setup `MotionTestPlay`
    - `FileName`: Exported file name
    - `Target`: Humanoid object in the scene
    - `OnlyUpperBody`: Turn on if you want to play only upper body motion
- Run in editor, or build to play.


## OSS License

*NOTE*: If you are using just `.unitypackage` in Releases you can ignore the license note of UniVRM. The original project (before exported) contains UPM definition to import UniVRM, so if you clone the project itself you will use UniVRM.

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
