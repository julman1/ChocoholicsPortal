﻿#pragma checksum "..\..\PortalWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7E07ACF7379DFC4A4D89203F8780362A083C3D43"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ChocoholicsPortal;
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


namespace ChocoholicsPortal {
    
    
    /// <summary>
    /// PortalWindow
    /// </summary>
    public partial class PortalWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\PortalWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\PortalWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\PortalWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_Copy;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\PortalWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_Copy1;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\PortalWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_Copy2;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\PortalWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_Copy3;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\PortalWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_Copy4;
        
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
            System.Uri resourceLocater = new System.Uri("/ChocoholicsPortal;component/portalwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\PortalWindow.xaml"
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
            this.label = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.button = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\PortalWindow.xaml"
            this.button.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.button_Copy = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\PortalWindow.xaml"
            this.button_Copy.Click += new System.Windows.RoutedEventHandler(this.Button_Copy_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.button_Copy1 = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\PortalWindow.xaml"
            this.button_Copy1.Click += new System.Windows.RoutedEventHandler(this.Button_Copy1_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.button_Copy2 = ((System.Windows.Controls.Button)(target));
            return;
            case 6:
            this.button_Copy3 = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\PortalWindow.xaml"
            this.button_Copy3.Click += new System.Windows.RoutedEventHandler(this.Button_Copy3_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.button_Copy4 = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\PortalWindow.xaml"
            this.button_Copy4.Click += new System.Windows.RoutedEventHandler(this.Button_Copy4_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

