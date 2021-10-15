# 開発者用 README

## 開発ルール

機能追加やバグの修正など、必ず Issue を立てる。  
1つの Issue に対して 1つの Pull Request を作成する。  

## ブランチ

### 種類

- master
  - リリース用
  - 直接 Push はしない

- develop
  - 開発用
  - 直接 Push はしない
  - ここを基準にブランチを切る・繋ぐ
  - merge の種類は`Squash and merge`を選択する

- topic branch
  - ここで各々が開発を行う
  - `develop`から切り、`develop`に繋ぐ
  - ブランチ名の命名は以下を参照

### トピックブランチのブランチ名

#### フォーマット

```
{Issue番号}-{Issueの内容}
```

#### 例

- `1-construct-environment`
- `2-fix-bug`

## コミットメッセージ

### フォーマット

```
{prefix}: {変更内容}

{変更理由}
```

### prefix

- feat: 新しい機能の追加
- refactor: リファクタリング
- fix: バグの修正
- docs: ドキュメントの変更
- style: 見た目の変更
- chore: ビルドやライブラリ関連

### 例

```
feat: ステージ選択ボタンの追加

ステージ選択画面へ遷移させるため
```
```
refactor: 関数の分割

可読性を上げるため
```

## ディレクトリ構成

```
└─ Assets
     ├─ MyGame       <- 外部ライブラリ以外の自作物はこのディレクトリ以下に置く
     │   ├─ Prefabs  <- プレハブを置く
     │   │   ├─ ExamplePrefab.prefab
     │   │   ├─ ExamplePrefab.prefab.meta
     │   │   └─ ...
     │   ├─ Scenes   <- シーンを置く
     │   │   ├─ ExampleScene.unity
     │   │   ├─ ExampleScene.unity.meta
     │   │   └─ ...
     │   └─ Scripts  <- C#スクリプトを置く
     │        ├─ ExampleScript.cs
     │        ├─ ExampleScript.cs.meta
     │        └─ ...
     ├─ 外部ライブラリ(その1)
     ├─ 外部ライブラリ(その2)
     └─ ...
```

## omnisharp の設定

[setup_omnisharp.md](setup_omnisharp.md) を参照
