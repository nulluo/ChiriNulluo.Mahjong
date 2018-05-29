Imports System.ComponentModel

Namespace Tiles


    ''' <summary>
    ''' <c>Tile</c>の集合を表すクラス。<c>BindingList</c>を継承しており、コントロールへのデータバインドやソートが可能
    ''' </summary>
    Public Class Pile
        Inherits BindingList(Of Tile)
        Implements INotifyPropertyChanged



        ''' <summary>
        ''' 指定したIDに一致する牌を山の先頭から検索し、最初に見つかった牌の参照を返す。
        ''' </summary>
        ''' <param name="id">検索する牌のID</param>
        ''' <returns>見つかった牌の参照。一致する牌が存在しない場合、Nothingを返す。</returns>
        Public Function SearchTile(id As String) As Tile
            Dim _foundTile = Me.Items.FirstOrDefault(Function(_tile) _tile.ID = id)
            Return _foundTile

        End Function


#Region "ソートの実現"

        ’’’<summary>
        ’’’ソート済みかどうか
        ’’’ </summary>
        Private isSorted As Boolean

        '''<summary>
        '''並べ替え操作の方向
        '''</summary>
        Private sortDirection As ListSortDirection = ListSortDirection.Ascending

        '''<summary>
        '''ソートを行う抽象化プロパティ
        ''' </summary>
        Private Property sortProperty As PropertyDescriptor


        ''' <summary>
        ''' リストがソートをサポートしているかどうかを示す値を取得します。
        ''' </summary>
        Protected Overrides ReadOnly Property SupportsSortingCore As Boolean
            Get
                Return True
            End Get
        End Property

        '''<summary>
        '''リストがソートされたかどうかを示す値を取得します。
        '''</summary>
        Protected Overrides ReadOnly Property IsSortedCore As Boolean
            Get
                Return Me.isSorted
            End Get
        End Property

        '''<summary>
        '''ソートされたリストの並べ替え操作の方向を取得します。
        ''' </summary>
        Protected Overrides ReadOnly Property SortDirectionCore As ListSortDirection
            Get
                Return Me.sortDirection
            End Get
        End Property

        ''' <summary>
        ''' ソートに利用する抽象化プロパティを取得します。
        ''' </summary>
        Protected Overrides ReadOnly Property SortPropertyCore As PropertyDescriptor
            Get
                Return Me.sortProperty
            End Get
        End Property

        '''  <summary>
        '''  ApplySortCore で適用されたソートに関する情報を削除します。
        '''</summary>
        Protected Overrides Sub RemoveSortCore()
            Me.sortDirection = ListSortDirection.Ascending
            Me.isSorted = False
        End Sub

        ''' <summary>
        ''' 指定されたプロパティおよび方向でソートを行います。
        ''' </summary>
        ''' <param name="prop">抽象化プロパティ</param>
        ''' <param name="direction">並べ替え操作の方向</param>
        Protected Overrides Sub ApplySortCore(prop As PropertyDescriptor, direction As ListSortDirection)

            ' ソートに使う情報を記録
            Me.sortProperty = prop
            Me.sortDirection = direction

            '// ソートを行うリストを取得
            Dim _items = DirectCast(Me.Items, List(Of Tile))

            If Items Is Nothing Then
                Return
            End If

            '// ソート処理
            _items.Sort(AddressOf Me.Compare)

            'ソート完了を記録
            Me.isSorted = True

            'ListChanged イベントを発生させます
            Me.OnListChanged(New ListChangedEventArgs(ListChangedType.Reset, -1))
        End Sub

        ''' <summary>
        ''' 比較処理を行います。
        ''' </summary>
        ''' <param name="left">左側の値</param>
        ''' <param name="right">右側の値</param>
        ''' <returns>比較結果</returns>
        Private Function Compare(left As Tile, right As Tile) As Integer
            '// 比較を行う
            Dim result = Me.OnComparison(left, right)

            '// 昇順の場合 そのまま、降順の場合 反転させる
            If Me.sortDirection = ListSortDirection.Ascending Then
                Return result
            Else
                Return -result
            End If

        End Function

        'UNIMPLEMENTED：https://garafu.blogspot.jp/2016/09/cs-sorablebindinglist.html　を真似したが、このサンプルコードはTileに限らない任意の型でのソートを実現する方法なので、本クラスでは、ここまで任意のプロパティへ対応するコーディングは必要ない気がする
        ''' <summary>
        ''' 昇順として比較処理を行います。
        ''' </summary>
        ''' <param name="left">左側の値</param>
        ''' <param name="right">右側の値</param>
        ''' <returns>比較結果</returns>
        Private Function OnComparison(left As Tile, right As Tile) As Integer

            Dim leftValue As Object = If(left Is Nothing, Nothing, Me.sortProperty.GetValue(left))
            Dim rightValue As Object = If(right Is Nothing, Nothing, Me.sortProperty.GetValue(right))

            If leftValue Is Nothing Then
                Return If(rightValue Is Nothing, 0, -1)
            End If

            If rightValue Is Nothing Then
                Return 1
            End If

            If TypeOf leftValue Is IComparable Then
                Return DirectCast(leftValue, IComparable).CompareTo(rightValue)
            End If

            If leftValue.Equals(rightValue) Then
                Return 0
            End If

            Return leftValue.ToString().CompareTo(rightValue.ToString())

        End Function
#End Region

        ''' <summary>
        ''' ID順にソートを行います。
        ''' </summary>
        Public Sub Sort()
            Dim propertyDescriptors As PropertyDescriptorCollection = TypeDescriptor.GetProperties(GetType(Tile))

            Me.ApplySortCore(propertyDescriptors("ID"), ListSortDirection.Ascending)
        End Sub

#Region "データバインディングの実現"

        ''' <summary>
        ''' プロパティ値が変更されたときに発生します。
        ''' </summary>
        Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged


        ''' <summary>
        ''' リストまたはリスト内の項目が変更された場合に発生します。
        ''' </summary>
        ''' <param name="sender">イベントを発生させた<c>Pile</c>オブジェクト</param>
        ''' <param name="e">イベントの関連情報</param>
        Private Sub Pile_ListChanged(sender As Object, e As ListChangedEventArgs) Handles Me.ListChanged
            RaiseEvent PropertyChanged(sender, New PropertyChangedEventArgs(NameOf(Items)))
        End Sub

#End Region



    End Class

End Namespace