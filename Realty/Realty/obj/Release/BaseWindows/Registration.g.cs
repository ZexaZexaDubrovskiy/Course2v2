﻿#pragma checksum "..\..\..\BaseWindows\Registration.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "F477AFC6A0DF351F2DC5E68A3C36837E9A7C8F4868E8F6828297E84C3EDA952A"
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
    /// Registration
    /// </summary>
    public partial class Registration : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 45 "..\..\..\BaseWindows\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox userNewLogin;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\BaseWindows\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox userNewPassword;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\BaseWindows\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox userNewConfirmPassword;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\BaseWindows\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button PasswordButton;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\..\BaseWindows\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button signInButton;
        
        #line default
        #line hidden
        
        
        #line 103 "..\..\..\BaseWindows\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label userHaveAccount;
        
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
            System.Uri resourceLocater = new System.Uri("/Realty;component/basewindows/registration.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\BaseWindows\Registration.xaml"
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
            this.userNewLogin = ((System.Windows.Controls.TextBox)(target));
            
            #line 48 "..\..\..\BaseWindows\Registration.xaml"
            this.userNewLogin.LostFocus += new System.Windows.RoutedEventHandler(this.userNewLogin_LostFocus);
            
            #line default
            #line hidden
            
            #line 49 "..\..\..\BaseWindows\Registration.xaml"
            this.userNewLogin.GotFocus += new System.Windows.RoutedEventHandler(this.userNewLogin_GotFocus);
            
            #line default
            #line hidden
            return;
            case 2:
            this.userNewPassword = ((System.Windows.Controls.TextBox)(target));
            
            #line 59 "..\..\..\BaseWindows\Registration.xaml"
            this.userNewPassword.LostFocus += new System.Windows.RoutedEventHandler(this.userNewPassword_LostFocus);
            
            #line default
            #line hidden
            
            #line 60 "..\..\..\BaseWindows\Registration.xaml"
            this.userNewPassword.GotFocus += new System.Windows.RoutedEventHandler(this.userNewPassword_GotFocus);
            
            #line default
            #line hidden
            return;
            case 3:
            this.userNewConfirmPassword = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 4:
            this.PasswordButton = ((System.Windows.Controls.Button)(target));
            
            #line 70 "..\..\..\BaseWindows\Registration.xaml"
            this.PasswordButton.Click += new System.Windows.RoutedEventHandler(this.PasswordButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.signInButton = ((System.Windows.Controls.Button)(target));
            
            #line 89 "..\..\..\BaseWindows\Registration.xaml"
            this.signInButton.Click += new System.Windows.RoutedEventHandler(this.signInButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.userHaveAccount = ((System.Windows.Controls.Label)(target));
            
            #line 106 "..\..\..\BaseWindows\Registration.xaml"
            this.userHaveAccount.PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.userHaveAccount_PreviewMouseDown);
            
            #line default
            #line hidden
            
            #line 107 "..\..\..\BaseWindows\Registration.xaml"
            this.userHaveAccount.MouseEnter += new System.Windows.Input.MouseEventHandler(this.userHaveAccount_MouseEnter);
            
            #line default
            #line hidden
            
            #line 108 "..\..\..\BaseWindows\Registration.xaml"
            this.userHaveAccount.MouseLeave += new System.Windows.Input.MouseEventHandler(this.userHaveAccount_MouseLeave);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

