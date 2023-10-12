﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MISA.Web06.RESTful.Domain.Resource.Exception {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class ExceptionMsgVN {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ExceptionMsgVN() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MISA.Web06.RESTful.Domain.Resource.Exception.ExceptionMsgVN", typeof(ExceptionMsgVN).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
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
        ///   Looks up a localized string similar to Mã.
        /// </summary>
        public static string Code {
            get {
                return ResourceManager.GetString("Code", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} đã tồn tại.
        /// </summary>
        public static string ConflictOfDev {
            get {
                return ResourceManager.GetString("ConflictOfDev", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} đã tồn tại, vui lòng kiểm tra lại!.
        /// </summary>
        public static string ConflictOfUser {
            get {
                return ResourceManager.GetString("ConflictOfUser", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} phải nhỏ hơn ngày hiện tại..
        /// </summary>
        public static string DateLessThanNow {
            get {
                return ResourceManager.GetString("DateLessThanNow", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Mã nhân viên.
        /// </summary>
        public static string EmployeeCode {
            get {
                return ResourceManager.GetString("EmployeeCode", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ID nhân viên.
        /// </summary>
        public static string EmployeeId {
            get {
                return ResourceManager.GetString("EmployeeId", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Không thể tải excel, lỗi trong quá trình khởi tạo.
        /// </summary>
        public static string ExportExcelOfDev {
            get {
                return ResourceManager.GetString("ExportExcelOfDev", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Không thể tải excel, vui lòng thử lại sau.
        /// </summary>
        public static string ExportExcelOfUser {
            get {
                return ResourceManager.GetString("ExportExcelOfUser", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ID.
        /// </summary>
        public static string ID {
            get {
                return ResourceManager.GetString("ID", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} không được phép lớn hơn {1} ký tự..
        /// </summary>
        public static string MaxLength {
            get {
                return ResourceManager.GetString("MaxLength", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Không tìm thấy {0}.
        /// </summary>
        public static string NotFoundOfDev {
            get {
                return ResourceManager.GetString("NotFoundOfDev", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Không tìm thấy {0}, vui lòng kiểm tra lại!.
        /// </summary>
        public static string NotFoundOfUser {
            get {
                return ResourceManager.GetString("NotFoundOfUser", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Chỉ cho phép từ giá trị {0} đến {1}..
        /// </summary>
        public static string Range {
            get {
                return ResourceManager.GetString("Range", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} không đúng định dạng..
        /// </summary>
        public static string RegexExpression {
            get {
                return ResourceManager.GetString("RegexExpression", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} là bắt buộc..
        /// </summary>
        public static string Required {
            get {
                return ResourceManager.GetString("Required", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Có lỗi từ phía server, vui lòng chờ một vài phút để chúng tôi xử lý.
        /// </summary>
        public static string Server {
            get {
                return ResourceManager.GetString("Server", resourceCulture);
            }
        }
    }
}