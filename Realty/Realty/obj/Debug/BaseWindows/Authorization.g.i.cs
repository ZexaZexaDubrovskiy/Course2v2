﻿#pragma checksum "..\..\..\BaseWindows\Authorization.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "99D38EE42A1ED7A2EFA5AADF284BCAB7686918FEA791F2C0E2A370E2BC56B2E5"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Realty.BaseWindows;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Realty.BaseWindows {
    
    
    /// <summary>
    /// Authorization
    /// </summary>
    public partial class Authorization : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 49 "..\..\..\BaseWindows\Authorization.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox userLogin;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\BaseWindows\Authorization.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox userPassword;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\BaseWindows\Authorization.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox userConfirmPassword;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\BaseWindows\Authorization.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button PasswordButton;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\BaseWindows\Authorization.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textButton;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\..\BaseWindows\Authorization.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button signInButton;
        
        #line default
        #line hidden
        
        
        #line 102 "..\..\..\BaseWindows\Authorization.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label ButtonSignUp;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Realty;component/basewindows/authorization.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\BaseWindows\Authorization.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.userLogin = ((System.Windows.Controls.TextBox)(target));
            
            #line 52 "..\..\..\BaseWindows\Authorization.xaml"
            this.userLogin.LostFocus += new System.Windows.RoutedEventHandler(this.userLogin_LostFocus);
            
            #line default
            #line hidden
            
            #line 53 "..\..\..\BaseWindows\Authorization.xaml"
            this.userLogin.GotFocus += new System.Windows.RoutedEventHandler(this.userLogin_GotFocus);
            
            #line default
            #line hidden
            return;
            case 2:
            this.userPassword = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.userConfirmPassword = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 4:
            this.PasswordButton = ((System.Windows.Controls.Button)(target));
            
            #line 72 "..\..\..\BaseWindows\Authorization.xaml"
            this.PasswordButton.Click += new System.Windows.RoutedEventHandler(this.PasswordButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.textButton = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.signInButton = ((System.Windows.Controls.Button)(target));
            
            #line 88 "..\..\..\BaseWindows\Authorization.xaml"
            this.signInButton.Click += new System.Windows.RoutedEventHandler(this.signInButton_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ButtonSignUp = ((System.Windows.Controls.Label)(target));
            
            #line 105 "..\..\..\BaseWindows\Authorization.xaml"
            this.ButtonSignUp.PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.ButtonSignUp_PreviewMouseDown);
            
            #line default
            #line hidden
            
            #line 106 "..\..\..\BaseWindows\Authorization.xaml"
            this.ButtonSignUp.MouseEnter += new System.Windows.Input.MouseEventHandler(this.ButtonSignUp_MouseEnter);
            
            #line default
            #line hidden
            
            #line 107 "..\..\..\BaseWindows\Authorization.xaml"
            this.ButtonSignUp.MouseLeave += new System.Windows.Input.MouseEventHandler(this.ButtonSignUp_MouseLeave);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

