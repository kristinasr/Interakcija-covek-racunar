﻿#pragma checksum "..\..\..\Views\NetworkDataView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "998636B077E30FE91096572C79E485B001A792D878A7C7AC6B5C6891B8276882"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using NetworkService;
using NetworkService.Model;
using NetworkService.ViewModel;
using NetworkService.Views;
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
using System.Windows.Interactivity;
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


namespace NetworkService.Views {
    
    
    /// <summary>
    /// NetworkDataView
    /// </summary>
    public partial class NetworkDataView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 77 "..\..\..\Views\NetworkDataView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton Lower;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\Views\NetworkDataView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton Higher;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\Views\NetworkDataView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton Equal;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\..\Views\NetworkDataView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxId;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\..\Views\NetworkDataView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboBoxFilter;
        
        #line default
        #line hidden
        
        
        #line 95 "..\..\..\Views\NetworkDataView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonSearch;
        
        #line default
        #line hidden
        
        
        #line 96 "..\..\..\Views\NetworkDataView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonReset;
        
        #line default
        #line hidden
        
        
        #line 101 "..\..\..\Views\NetworkDataView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox ValidValuesOnlyCheckbox;
        
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
            System.Uri resourceLocater = new System.Uri("/NetworkService;component/views/networkdataview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\NetworkDataView.xaml"
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
            this.Lower = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 2:
            this.Higher = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 3:
            this.Equal = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 4:
            this.TextBoxId = ((System.Windows.Controls.TextBox)(target));
            
            #line 83 "..\..\..\Views\NetworkDataView.xaml"
            this.TextBoxId.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextBoxId_TextChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ComboBoxFilter = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.ButtonSearch = ((System.Windows.Controls.Button)(target));
            return;
            case 7:
            this.ButtonReset = ((System.Windows.Controls.Button)(target));
            return;
            case 8:
            this.ValidValuesOnlyCheckbox = ((System.Windows.Controls.CheckBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

