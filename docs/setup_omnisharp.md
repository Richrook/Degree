# omnisharp の設定方法

## omnisharp とは

- c#スクリプトのフォーマッタ
- `omnisharp.json` ファイルの設定に従う
- vscode のフォーマット機能もあるけど、今回はこちらを使いたい

## vscode からの使用

- 必要な拡張機能を入れる
- 環境によって (特に Windows 以外の場合) モジュールが足りないなどあれば追加作業

### 拡張機能のインストール

- [C#](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp) (必須)
- [MonoBehaviour Snippets](https://marketplace.visualstudio.com/items?itemName=zrachod.mono-snippets) (任意)

拡張機能のタブの `RECOMMENDED` に表示されているはず

### 環境によって設定が必要かもしれない項目

#### Mono のインストール

1. [公式のダウンロードページ](https://www.mono-project.com/download/stable/)に従ってダウンロード・インストール
1. vscode の `settings.json` ファイルにて、`"omnisharp.useGlobalMono"`の値を適宜修正 (`"always"` に設定したらいいかな？)
1. vscode をリロード

#### .csproj ファイルの生成

1. Unity で `Edit` -> `Preferences` -> `External Tools` と進む (日本語だと `編集` -> `設定` -> `外部ツール` とかかな？)
1. `Generate .csproj files for:` 内のチェックボックスに全てチェックを入れ、その下の `Regenerate project files` ボタンを押下
1. vscode をリロード

### 設定確認

vscode をリロード後、OmniSharp のアイコンが表示されていて、`OmniSharp server is running` となっていれば OK
