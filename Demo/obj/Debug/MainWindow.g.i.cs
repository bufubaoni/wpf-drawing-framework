﻿#pragma checksum "..\..\MainWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "1E263E09D87EA23E28CB4973350F70FF"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using Map;
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


namespace Demo {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem menuItem_Open;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnWholeMap;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnTranslate;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnScale;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnMax;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnMin;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPick;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSelect;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnReversSelect;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Map.MainCanvas mainCanvas;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Map.PointVisualHost m_PointVisualHost;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Map.LineVisualHost m_LineVisualHost;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblCoordinate;
        
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
            System.Uri resourceLocater = new System.Uri("/Demo;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainWindow.xaml"
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
            this.menuItem_Open = ((System.Windows.Controls.MenuItem)(target));
            
            #line 16 "..\..\MainWindow.xaml"
            this.menuItem_Open.Click += new System.Windows.RoutedEventHandler(this.menuItem_Open_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnWholeMap = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\MainWindow.xaml"
            this.btnWholeMap.Click += new System.Windows.RoutedEventHandler(this.btnWholeMap_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnTranslate = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\MainWindow.xaml"
            this.btnTranslate.Click += new System.Windows.RoutedEventHandler(this.btnTranslate_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnScale = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\MainWindow.xaml"
            this.btnScale.Click += new System.Windows.RoutedEventHandler(this.btnScale_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnMax = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\MainWindow.xaml"
            this.btnMax.Click += new System.Windows.RoutedEventHandler(this.btnMax_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnMin = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\MainWindow.xaml"
            this.btnMin.Click += new System.Windows.RoutedEventHandler(this.btnMin_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnPick = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\MainWindow.xaml"
            this.btnPick.Click += new System.Windows.RoutedEventHandler(this.btnPick_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnSelect = ((System.Windows.Controls.Button)(target));
            
            #line 45 "..\..\MainWindow.xaml"
            this.btnSelect.Click += new System.Windows.RoutedEventHandler(this.btnSelect_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btnReversSelect = ((System.Windows.Controls.Button)(target));
            
            #line 49 "..\..\MainWindow.xaml"
            this.btnReversSelect.Click += new System.Windows.RoutedEventHandler(this.btnReversSelect_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.mainCanvas = ((Map.MainCanvas)(target));
            
            #line 56 "..\..\MainWindow.xaml"
            this.mainCanvas.MouseMove += new System.Windows.Input.MouseEventHandler(this.mainCanvas_MouseMove);
            
            #line default
            #line hidden
            return;
            case 11:
            this.m_PointVisualHost = ((Map.PointVisualHost)(target));
            return;
            case 12:
            this.m_LineVisualHost = ((Map.LineVisualHost)(target));
            return;
            case 13:
            this.lblCoordinate = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
