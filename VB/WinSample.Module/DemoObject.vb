Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Xpo

Namespace WinSample.Module

    <DefaultClassOptions>
    Public Class DemoObject
        Inherits BaseObject

        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub

        Private _dependentProperty As String

        Public Property DependentProperty As String
            Get
                Return _dependentProperty
            End Get

            Set(ByVal value As String)
                SetPropertyValue("DependentProperty", _dependentProperty, value)
            End Set
        End Property

        Private _independentProperty As Boolean

        <ImmediatePostData>
        Public Property IndependentProperty As Boolean
            Get
                Return _independentProperty
            End Get

            Set(ByVal value As Boolean)
                SetPropertyValue("IndependentProperty", _independentProperty, value)
            End Set
        End Property
    End Class
End Namespace
