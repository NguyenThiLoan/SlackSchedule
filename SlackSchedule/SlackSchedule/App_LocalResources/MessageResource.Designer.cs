﻿//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン:4.0.30319.42000
//
//     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
//     コードが再生成されるときに損失したりします。
// </auto-generated>
//------------------------------------------------------------------------------

namespace SlackSchedule.App_LocalResources {
    using System;
    
    
    /// <summary>
    ///   ローカライズされた文字列などを検索するための、厳密に型指定されたリソース クラスです。
    /// </summary>
    // このクラスは StronglyTypedResourceBuilder クラスが ResGen
    // または Visual Studio のようなツールを使用して自動生成されました。
    // メンバーを追加または削除するには、.ResX ファイルを編集して、/str オプションと共に
    // ResGen を実行し直すか、または VS プロジェクトをビルドし直します。
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class MessageResource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal MessageResource() {
        }
        
        /// <summary>
        ///   このクラスで使用されているキャッシュされた ResourceManager インスタンスを返します。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("SlackSchedule.App_LocalResources.MessageResource", typeof(MessageResource).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   厳密に型指定されたこのリソース クラスを使用して、すべての検索リソースに対し、
        ///   現在のスレッドの CurrentUICulture プロパティをオーバーライドします。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   {0} đã tồn tại trong database. に類似しているローカライズされた文字列を検索します。
        /// </summary>
        public static string error_Duplicate {
            get {
                return ResourceManager.GetString("error_Duplicate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   {0} không đúng định dạng. に類似しているローカライズされた文字列を検索します。
        /// </summary>
        public static string error_Format {
            get {
                return ResourceManager.GetString("error_Format", resourceCulture);
            }
        }
        
        /// <summary>
        ///   {0} bắt buột nhập. に類似しているローカライズされた文字列を検索します。
        /// </summary>
        public static string error_Required {
            get {
                return ResourceManager.GetString("error_Required", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Đã xóa thành công. に類似しているローカライズされた文字列を検索します。
        /// </summary>
        public static string info_DataDeleted {
            get {
                return ResourceManager.GetString("info_DataDeleted", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Dữ liệu không tồn tại. に類似しているローカライズされた文字列を検索します。
        /// </summary>
        public static string info_DataNotExist {
            get {
                return ResourceManager.GetString("info_DataNotExist", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Đã lưu thông tin thành công. に類似しているローカライズされた文字列を検索します。
        /// </summary>
        public static string info_DataSaved {
            get {
                return ResourceManager.GetString("info_DataSaved", resourceCulture);
            }
        }
    }
}