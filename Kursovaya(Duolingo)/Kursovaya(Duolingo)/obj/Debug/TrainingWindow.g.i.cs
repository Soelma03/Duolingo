﻿#pragma checksum "..\..\TrainingWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "7EF1679C238A701A519EADB6DFDB2DE268A393C3687B78CFD4D4452F4B68C81E"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Kursovaya_Duolingo_;
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


namespace Kursovaya_Duolingo_ {
    
    
    /// <summary>
    /// TrainingWindow
    /// </summary>
    public partial class TrainingWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\TrainingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label TrainingWordLabel;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\TrainingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Answer1Button;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\TrainingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Answer2Button;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\TrainingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Answer3Button;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\TrainingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Answer4Button;
        
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
            System.Uri resourceLocater = new System.Uri("/Kursovaya(Duolingo);component/trainingwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\TrainingWindow.xaml"
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
            this.TrainingWordLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.Answer1Button = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\TrainingWindow.xaml"
            this.Answer1Button.Click += new System.Windows.RoutedEventHandler(this.CheckTrainingAnswer_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Answer2Button = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\TrainingWindow.xaml"
            this.Answer2Button.Click += new System.Windows.RoutedEventHandler(this.CheckTrainingAnswer_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Answer3Button = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\TrainingWindow.xaml"
            this.Answer3Button.Click += new System.Windows.RoutedEventHandler(this.CheckTrainingAnswer_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Answer4Button = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\TrainingWindow.xaml"
            this.Answer4Button.Click += new System.Windows.RoutedEventHandler(this.CheckTrainingAnswer_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

