# particle-sim-unity
ParticleSimUnity is a package for particle physics simulation in Unity, utilizing Geant4.

素粒子シミュレーションをUnityで実行できるようにしたPackageです。Geant4を用いています。

## How to Install
### en
1. In the Package Manager, select `Add package from git URL...` and import using this URL: [`https://github.com/VMelville/particle-sim-unity.git`](https://github.com/VMelville/particle-sim-unity.git).
2. Navigate to [https://geant4.web.cern.ch/download](https://geant4.web.cern.ch/download) and download at least the following datasets: `G4EMLOW`, `G4ENSDFSTATE`, `G4PARTICLEXS`, `G4SAIDDATA`, and `PhotonEvaporation5.7`. Then, add these to your project.
3. The directory containing these datasets should have the `GEANT4_DATA_DIR` environment variable set. See the [reference](https://geant4-userdoc.web.cern.ch/UsersGuides/InstallationGuide/html/postinstall.html) for more details. Alternatively, you can set this within your C# code, as shown in this [example](https://github.com/VMelville/subatomic-canvas/blob/main/Assets/SubatomicCanvas/Scripts/MainLifetimeScope.cs).
4. As of now, it's crucial to execute `ParticleSim.Simulator.Init()` first when using this package. If not done, the Unity Editor might crash! We aim to enhance its user-friendliness in the future.

For practical examples of usage, kindly refer to the separate project, [SubatomicCanvas](https://github.com/VMelville/subatomic-canvas/).

### jp
1. Package Managerの `Add package from git URL...` から、[`https://github.com/VMelville/particle-sim-unity.git`](https://github.com/VMelville/particle-sim-unity.git) を指定してImportしてください。
2. https://geant4.web.cern.ch/download にアクセスし、Datasetsのうち少なくとも `G4EMLOW` `G4ENSDFSTATE` `G4PARTICLEXS` `G4SAIDDATA` `PhotonEvaporation5.7` をダウンロードして、プロジェクトに追加してください。
3. この追加されたデータセットのあるディレクトリは `GEANT4_DATA_DIR` という環境変数が設定される必要があります（[参考](https://geant4-userdoc.web.cern.ch/UsersGuides/InstallationGuide/html/postinstall.html)）。C#コード上で追加する方法もあります（[例](https://github.com/VMelville/subatomic-canvas/blob/main/Assets/SubatomicCanvas/Scripts/MainLifetimeScope.cs)）。
4. 現状、このPackageは `ParticleSim.Simulator.Init()` を最初に実行する必要があります。（そうでないと、Unity Editorがクラッシュしてしまいます！）将来的にはもう少しユーザーフレンドリーにするつもりです。

実際の使用例については、別プロジェクトである [SubatomicCanvas](https://github.com/VMelville/subatomic-canvas/) を是非参考にしてください。

## License

### Geant4

Copyright (c) 2023 The Geant4 Collaboration. All rights reserved.

Licensed under The Geant4 Software License (https://geant4.web.cern.ch/download/license).

This product includes software developed by Members of the Geant4 Collaboration (http://cern.ch/geant4).
