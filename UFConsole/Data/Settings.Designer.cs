﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UFConsole.Data {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.6.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool isSafeMode {
            get {
                return ((bool)(this["isSafeMode"]));
            }
            set {
                this["isSafeMode"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool isUpdateInfo {
            get {
                return ((bool)(this["isUpdateInfo"]));
            }
            set {
                this["isUpdateInfo"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("LightGray")]
        public global::System.Drawing.Color ConsoleTextColor {
            get {
                return ((global::System.Drawing.Color)(this["ConsoleTextColor"]));
            }
            set {
                this["ConsoleTextColor"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("50, 50, 100")]
        public global::System.Drawing.Color ConsoleBackgroundColor {
            get {
                return ((global::System.Drawing.Color)(this["ConsoleBackgroundColor"]));
            }
            set {
                this["ConsoleBackgroundColor"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("LightGray")]
        public global::System.Drawing.Color InputTextColor {
            get {
                return ((global::System.Drawing.Color)(this["InputTextColor"]));
            }
            set {
                this["InputTextColor"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("70, 70, 100")]
        public global::System.Drawing.Color InputBackgroundColor {
            get {
                return ((global::System.Drawing.Color)(this["InputBackgroundColor"]));
            }
            set {
                this["InputBackgroundColor"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("70, 70, 100")]
        public global::System.Drawing.Color SidebarBackgroundColor {
            get {
                return ((global::System.Drawing.Color)(this["SidebarBackgroundColor"]));
            }
            set {
                this["SidebarBackgroundColor"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("White")]
        public global::System.Drawing.Color TopBarTextColor {
            get {
                return ((global::System.Drawing.Color)(this["TopBarTextColor"]));
            }
            set {
                this["TopBarTextColor"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("20, 20, 20")]
        public global::System.Drawing.Color TopBarBackgroundColor {
            get {
                return ((global::System.Drawing.Color)(this["TopBarBackgroundColor"]));
            }
            set {
                this["TopBarBackgroundColor"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Black")]
        public global::System.Drawing.Color SidebarTextColor {
            get {
                return ((global::System.Drawing.Color)(this["SidebarTextColor"]));
            }
            set {
                this["SidebarTextColor"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("100")]
        public int FormOpacity {
            get {
                return ((int)(this["FormOpacity"]));
            }
            set {
                this["FormOpacity"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::System.Drawing.Color FormColorKey {
            get {
                return ((global::System.Drawing.Color)(this["FormColorKey"]));
            }
            set {
                this["FormColorKey"] = value;
            }
        }
    }
}
