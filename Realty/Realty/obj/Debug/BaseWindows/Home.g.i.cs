﻿#pragma checksum "..\..\..\BaseWindows\Home.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "651D7C404C335ABC4BC2E16F55FD40E61BA5EC99B395E54182762BA5560EF985"
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
    /// Home
    /// </summary>
    public partial class Home : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 48 "..\..\..\BaseWindows\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label NewsLabel;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\BaseWindows\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label commentsLabel;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\BaseWindows\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label aboutLabel;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\..\BaseWindows\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button userButton;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\..\BaseWindows\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox nameUser;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\..\BaseWindows\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image CenterItem;
        
        #line default
        #line hidden
        
        
        #line 99 "..\..\..\BaseWindows\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image LeftItem;
        
        #line default
        #line hidden
        
        
        #line 100 "..\..\..\BaseWindows\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image RightItem;
        
        #line default
        #line hidden
        
        
        #line 107 "..\..\..\BaseWindows\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buyButton;
        
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
            System.Uri resourceLocater = new System.Uri("/Realty;component/basewindows/home.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\BaseWindows\Home.xaml"
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
            this.NewsLabel = ((System.Windows.Controls.Label)(target));
            
            #line 49 "..\..\..\BaseWindows\Home.xaml"
            this.NewsLabel.PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.NewsLabel_PreviewMouseDown);
            
            #line default
            #line hidden
            
            #line 50 "..\..\..\BaseWindows\Home.xaml"
            this.NewsLabel.MouseEnter += new System.Windows.Input.MouseEventHandler(this.NewsLabel_MouseEnter);
            
            #line default
            #line hidden
            
            #line 51 "..\..\..\BaseWindows\Home.xaml"
            this.NewsLabel.MouseLeave += new System.Windows.Input.MouseEventHandler(this.NewsLabel_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 2:
            this.commentsLabel = ((System.Windows.Controls.Label)(target));
            
            #line 61 "..\..\..\BaseWindows\Home.xaml"
            this.commentsLabel.PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.commentsLabel_PreviewMouseDown);
            
            #line default
            #line hidden
            
            #line 62 "..\..\..\BaseWindows\Home.xaml"
            this.commentsLabel.MouseEnter += new System.Windows.Input.MouseEventHandler(this.commentsLabel_MouseEnter);
            
            #line default
            #line hidden
            
            #line 63 "..\..\..\BaseWindows\Home.xaml"
            this.commentsLabel.MouseLeave += new System.Windows.Input.MouseEventHandler(this.commentsLabel_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 3:
            this.aboutLabel = ((System.Windows.Controls.Label)(target));
            
            #line 73 "..\..\..\BaseWindows\Home.xaml"
            this.aboutLabel.PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.aboutLabel_PreviewMouseDown);
            
            #line default
            #line hidden
            
            #line 74 "..\..\..\BaseWindows\Home.xaml"
            this.aboutLabel.MouseEnter += new System.Windows.Input.MouseEventHandler(this.aboutLabel_MouseEnter);
            
            #line default
            #line hidden
            
            #line 75 "..\..\..\BaseWindows\Home.xaml"
            this.aboutLabel.MouseLeave += new System.Windows.Input.MouseEventHandler(this.aboutLabel_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 4:
            this.userButton = ((System.Windows.Controls.Button)(target));
            
            #line 81 "..\..\..\BaseWindows\Home.xaml"
            this.userButton.Click += new System.Windows.RoutedEventHandler(this.userButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.nameUser = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.CenterItem = ((System.Windows.Controls.Image)(target));
            
            #line 98 "..\..\..\BaseWindows\Home.xaml"
            this.CenterItem.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.CenterItem_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 7:
            this.LeftItem = ((System.Windows.Controls.Image)(target));
            
            #line 99 "..\..\..\BaseWindows\Home.xaml"
            this.LeftItem.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.LeftItem_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 8:
            this.RightItem = ((System.Windows.Controls.Image)(target));
            
            #line 100 "..\..\..\BaseWindows\Home.xaml"
            this.RightItem.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.RightItem_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 9:
            this.buyButton = ((System.Windows.Controls.Button)(target));
            
            #line 108 "..\..\..\BaseWindows\Home.xaml"
            this.buyButton.Click += new System.Windows.RoutedEventHandler(this.buyButton_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 130 "..\..\..\BaseWindows\Home.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

