﻿#pragma checksum "..\..\..\BaseWindows\Account.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "3291D836E9C8D0B2027848F52A51B58CC4F81680D35789EBE8E5E93DBD20DC38"
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
    /// Account
    /// </summary>
    public partial class Account : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 56 "..\..\..\BaseWindows\Account.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button userButton;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\BaseWindows\Account.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox nameUser;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\BaseWindows\Account.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addMoneyButton;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\..\BaseWindows\Account.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addButton;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\..\BaseWindows\Account.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label userLogin;
        
        #line default
        #line hidden
        
        
        #line 109 "..\..\..\BaseWindows\Account.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label userMoney;
        
        #line default
        #line hidden
        
        
        #line 124 "..\..\..\BaseWindows\Account.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox userMail;
        
        #line default
        #line hidden
        
        
        #line 143 "..\..\..\BaseWindows\Account.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox userMobilePhone;
        
        #line default
        #line hidden
        
        
        #line 162 "..\..\..\BaseWindows\Account.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox userFIO;
        
        #line default
        #line hidden
        
        
        #line 181 "..\..\..\BaseWindows\Account.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox userPasport;
        
        #line default
        #line hidden
        
        
        #line 194 "..\..\..\BaseWindows\Account.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button saveButton;
        
        #line default
        #line hidden
        
        
        #line 221 "..\..\..\BaseWindows\Account.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox RealtyList;
        
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
            System.Uri resourceLocater = new System.Uri("/Realty;component/basewindows/account.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\BaseWindows\Account.xaml"
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
            this.userButton = ((System.Windows.Controls.Button)(target));
            
            #line 57 "..\..\..\BaseWindows\Account.xaml"
            this.userButton.Click += new System.Windows.RoutedEventHandler(this.userButton_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.nameUser = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.addMoneyButton = ((System.Windows.Controls.Button)(target));
            
            #line 71 "..\..\..\BaseWindows\Account.xaml"
            this.addMoneyButton.Click += new System.Windows.RoutedEventHandler(this.addMoneyButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.addButton = ((System.Windows.Controls.Button)(target));
            
            #line 85 "..\..\..\BaseWindows\Account.xaml"
            this.addButton.Click += new System.Windows.RoutedEventHandler(this.addButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.userLogin = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.userMoney = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.userMail = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.userMobilePhone = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.userFIO = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.userPasport = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            this.saveButton = ((System.Windows.Controls.Button)(target));
            
            #line 194 "..\..\..\BaseWindows\Account.xaml"
            this.saveButton.Click += new System.Windows.RoutedEventHandler(this.saveButton_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.RealtyList = ((System.Windows.Controls.ListBox)(target));
            
            #line 224 "..\..\..\BaseWindows\Account.xaml"
            this.RealtyList.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.RealtyList_MouseDoubleClick);
            
            #line default
            #line hidden
            
            #line 225 "..\..\..\BaseWindows\Account.xaml"
            this.RealtyList.MouseRightButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.RealtyList_MouseRightButtonDown);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 236 "..\..\..\BaseWindows\Account.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
