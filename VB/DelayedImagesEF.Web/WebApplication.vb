﻿Imports System
Imports DevExpress.ExpressApp
Imports System.ComponentModel
Imports DevExpress.ExpressApp.Web
Imports System.Collections.Generic
Imports DevExpress.ExpressApp.EF
Imports DelayedImagesEF.Module.BusinessObjects
Imports System.Data.Common

Namespace DelayedImagesEF.Web
    ' For more typical usage scenarios, be sure to check out http://documentation.devexpress.com/#Xaf/DevExpressExpressAppWebWebApplicationMembersTopicAll
    Partial Public Class DelayedImagesEFAspNetApplication
        Inherits WebApplication

        Private module1 As DevExpress.ExpressApp.SystemModule.SystemModule
        Private module2 As DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule
        Private module3 As DelayedImagesEF.Module.DelayedImagesEFModule
        Private module4 As DelayedImagesEF.Module.Web.DelayedImagesEFAspNetModule

        Public Sub New()
            InitializeComponent()
        End Sub
        Protected Overrides Sub CreateDefaultObjectSpaceProvider(ByVal args As CreateCustomObjectSpaceProviderEventArgs)
            If args.Connection IsNot Nothing Then
                args.ObjectSpaceProvider = New EFObjectSpaceProvider(GetType(DelayedImagesEFDbContext), TypesInfo, Nothing, CType(args.Connection, DbConnection))
            Else
                args.ObjectSpaceProvider = New EFObjectSpaceProvider(GetType(DelayedImagesEFDbContext), TypesInfo, Nothing, args.ConnectionString)
            End If
        End Sub
        Private Sub DelayedImagesEFAspNetApplication_DatabaseVersionMismatch(ByVal sender As Object, ByVal e As DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs) Handles MyBase.DatabaseVersionMismatch
#If EASYTEST Then
            e.Updater.Update()
            e.Handled = True
#Else
            If System.Diagnostics.Debugger.IsAttached Then
                e.Updater.Update()
                e.Handled = True
            Else
                Dim message As String = "The application cannot connect to the specified database, because the latter doesn't exist or its version is older than that of the application." & ControlChars.CrLf & "This error occurred  because the automatic database update was disabled when the application was started without debugging." & ControlChars.CrLf & "To avoid this error, you should either start the application under Visual Studio in debug mode, or modify the " & "source code of the 'DatabaseVersionMismatch' event handler to enable automatic database update, " & "or manually create a database using the 'DBUpdater' tool." & ControlChars.CrLf & "Anyway, refer to the following help topics for more detailed information:" & ControlChars.CrLf & "'Update Application and Database Versions' at http://www.devexpress.com/Help/?document=ExpressApp/CustomDocument2795.htm" & ControlChars.CrLf & "'Database Security References' at http://www.devexpress.com/Help/?document=ExpressApp/CustomDocument3237.htm" & ControlChars.CrLf & "If this doesn't help, please contact our Support Team at http://www.devexpress.com/Support/Center/"

                If e.CompatibilityError IsNot Nothing AndAlso e.CompatibilityError.Exception IsNot Nothing Then
                    message &= ControlChars.CrLf & ControlChars.CrLf & "Inner exception: " & e.CompatibilityError.Exception.Message
                End If
                Throw New InvalidOperationException(message)
            End If
#End If
        End Sub
        Private Sub InitializeComponent()
            Me.module1 = New DevExpress.ExpressApp.SystemModule.SystemModule()
            Me.module2 = New DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule()
            Me.module3 = New DelayedImagesEF.Module.DelayedImagesEFModule()
            Me.module4 = New DelayedImagesEF.Module.Web.DelayedImagesEFAspNetModule()
            DirectCast(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            ' 
            ' DelayedImagesEFAspNetApplication
            ' 
            Me.ApplicationName = "DelayedImagesEF"
            Me.CollectionsEditMode = DevExpress.ExpressApp.Editors.ViewEditMode.Edit
            Me.Modules.Add(Me.module1)
            Me.Modules.Add(Me.module2)
            Me.Modules.Add(Me.module3)
            Me.Modules.Add(Me.module4)
            DirectCast(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
    End Class
End Namespace
