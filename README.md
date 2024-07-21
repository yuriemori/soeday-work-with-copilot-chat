# Program.cs 解説

## 概要

このプログラムは、ユーザーから従業員の情報を入力してもらい、その情報を基に`Employee`オブジェクトを作成し、それをリストに追加するという処理を行います。その後、リストの内容を`DataTable`に変換します。

## 詳細

### Mainメソッド

プログラムのエントリーポイントです。ここでは以下の処理を行います。

1. `Employee`オブジェクトのリストを作成します。
2. ユーザーからの入力を受け取ります。入力する情報は以下の通りです。
   - First Name
   - Last Name
   - Age
   - Department
   - Address
   - Phone Number
   - Hire Date
   - Salary
   - Email
   - Position
3. 入力されたEmailが有効かどうかを`IsEmailValid`メソッドで検証します。無効な場合はエラーメッセージを表示して処理を終了します。
4. 入力された情報を基に`Employee`オブジェクトを作成し、リストに追加します。
5. リストの内容を`DataTable`に変換します。

### IsEmailValidメソッド

入力されたEmailが有効かどうかを検証するメソッドです。以下の条件を満たす場合に有効と判断します。

- Emailがnullでない
- Emailに全角文字が含まれていない
- Emailが正規表現`^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$`に一致する

### ContainsFullWidthCharactersメソッド

文字列に全角文字が含まれているかどうかを判定するメソッドです。全角文字のUnicode範囲は`0xFF00`から`0xFFEF`までと定義しています。

### Employeeクラス

従業員の情報を保持するクラスです。以下のプロパティを持っています。

- FirstName
- LastName
- Age
- Department
- Address
- PhoneNumber
- HireDate
- Salary
- Email
- Position

また、`ToDataTable`メソッドを持っており、`Employee`オブジェクトのリストを`DataTable`に変換する処理を行います。ただし、登録できるデータは10件までと制限しています。

