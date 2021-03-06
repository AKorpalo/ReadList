﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASPNetMVC_Client.ReadListNS {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ReadList", Namespace="http://schemas.datacontract.org/2004/07/ReadListApp")]
    [System.SerializableAttribute()]
    public partial class ReadList : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AuthorNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string BookTitleField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int RatingField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime ReadingDateField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string AuthorName {
            get {
                return this.AuthorNameField;
            }
            set {
                if ((object.ReferenceEquals(this.AuthorNameField, value) != true)) {
                    this.AuthorNameField = value;
                    this.RaisePropertyChanged("AuthorName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string BookTitle {
            get {
                return this.BookTitleField;
            }
            set {
                if ((object.ReferenceEquals(this.BookTitleField, value) != true)) {
                    this.BookTitleField = value;
                    this.RaisePropertyChanged("BookTitle");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Page {
            get {
                return this.PageField;
            }
            set {
                if ((this.PageField.Equals(value) != true)) {
                    this.PageField = value;
                    this.RaisePropertyChanged("Page");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Rating {
            get {
                return this.RatingField;
            }
            set {
                if ((this.RatingField.Equals(value) != true)) {
                    this.RatingField = value;
                    this.RaisePropertyChanged("Rating");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime ReadingDate {
            get {
                return this.ReadingDateField;
            }
            set {
                if ((this.ReadingDateField.Equals(value) != true)) {
                    this.ReadingDateField = value;
                    this.RaisePropertyChanged("ReadingDate");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="MyCompany.com", ConfigurationName="ReadListNS.IReadListContract")]
    public interface IReadListContract {
        
        [System.ServiceModel.OperationContractAttribute(Action="MyCompany.com/IReadListContract/GetAllReadLists", ReplyAction="MyCompany.com/IReadListContract/GetAllReadListsResponse")]
        ASPNetMVC_Client.ReadListNS.ReadList[] GetAllReadLists();
        
        [System.ServiceModel.OperationContractAttribute(Action="MyCompany.com/IReadListContract/GetAllReadLists", ReplyAction="MyCompany.com/IReadListContract/GetAllReadListsResponse")]
        System.Threading.Tasks.Task<ASPNetMVC_Client.ReadListNS.ReadList[]> GetAllReadListsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="MyCompany.com/IReadListContract/GetById", ReplyAction="MyCompany.com/IReadListContract/GetByIdResponse")]
        ASPNetMVC_Client.ReadListNS.ReadList GetById(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="MyCompany.com/IReadListContract/GetById", ReplyAction="MyCompany.com/IReadListContract/GetByIdResponse")]
        System.Threading.Tasks.Task<ASPNetMVC_Client.ReadListNS.ReadList> GetByIdAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="MyCompany.com/IReadListContract/FindByAuthorOrTitle", ReplyAction="MyCompany.com/IReadListContract/FindByAuthorOrTitleResponse")]
        ASPNetMVC_Client.ReadListNS.ReadList[] FindByAuthorOrTitle(string search);
        
        [System.ServiceModel.OperationContractAttribute(Action="MyCompany.com/IReadListContract/FindByAuthorOrTitle", ReplyAction="MyCompany.com/IReadListContract/FindByAuthorOrTitleResponse")]
        System.Threading.Tasks.Task<ASPNetMVC_Client.ReadListNS.ReadList[]> FindByAuthorOrTitleAsync(string search);
        
        [System.ServiceModel.OperationContractAttribute(Action="MyCompany.com/IReadListContract/InsertReadList", ReplyAction="MyCompany.com/IReadListContract/InsertReadListResponse")]
        string InsertReadList(string authorName, string bookTitle, System.DateTime readingDate, int page, int rating);
        
        [System.ServiceModel.OperationContractAttribute(Action="MyCompany.com/IReadListContract/InsertReadList", ReplyAction="MyCompany.com/IReadListContract/InsertReadListResponse")]
        System.Threading.Tasks.Task<string> InsertReadListAsync(string authorName, string bookTitle, System.DateTime readingDate, int page, int rating);
        
        [System.ServiceModel.OperationContractAttribute(Action="MyCompany.com/IReadListContract/DeleteById", ReplyAction="MyCompany.com/IReadListContract/DeleteByIdResponse")]
        string DeleteById(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="MyCompany.com/IReadListContract/DeleteById", ReplyAction="MyCompany.com/IReadListContract/DeleteByIdResponse")]
        System.Threading.Tasks.Task<string> DeleteByIdAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="MyCompany.com/IReadListContract/UpdateReadList", ReplyAction="MyCompany.com/IReadListContract/UpdateReadListResponse")]
        string UpdateReadList(ASPNetMVC_Client.ReadListNS.ReadList newReadList);
        
        [System.ServiceModel.OperationContractAttribute(Action="MyCompany.com/IReadListContract/UpdateReadList", ReplyAction="MyCompany.com/IReadListContract/UpdateReadListResponse")]
        System.Threading.Tasks.Task<string> UpdateReadListAsync(ASPNetMVC_Client.ReadListNS.ReadList newReadList);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IReadListContractChannel : ASPNetMVC_Client.ReadListNS.IReadListContract, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ReadListContractClient : System.ServiceModel.ClientBase<ASPNetMVC_Client.ReadListNS.IReadListContract>, ASPNetMVC_Client.ReadListNS.IReadListContract {
        
        public ReadListContractClient() {
        }
        
        public ReadListContractClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ReadListContractClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ReadListContractClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ReadListContractClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public ASPNetMVC_Client.ReadListNS.ReadList[] GetAllReadLists() {
            return base.Channel.GetAllReadLists();
        }
        
        public System.Threading.Tasks.Task<ASPNetMVC_Client.ReadListNS.ReadList[]> GetAllReadListsAsync() {
            return base.Channel.GetAllReadListsAsync();
        }
        
        public ASPNetMVC_Client.ReadListNS.ReadList GetById(int id) {
            return base.Channel.GetById(id);
        }
        
        public System.Threading.Tasks.Task<ASPNetMVC_Client.ReadListNS.ReadList> GetByIdAsync(int id) {
            return base.Channel.GetByIdAsync(id);
        }
        
        public ASPNetMVC_Client.ReadListNS.ReadList[] FindByAuthorOrTitle(string search) {
            return base.Channel.FindByAuthorOrTitle(search);
        }
        
        public System.Threading.Tasks.Task<ASPNetMVC_Client.ReadListNS.ReadList[]> FindByAuthorOrTitleAsync(string search) {
            return base.Channel.FindByAuthorOrTitleAsync(search);
        }
        
        public string InsertReadList(string authorName, string bookTitle, System.DateTime readingDate, int page, int rating) {
            return base.Channel.InsertReadList(authorName, bookTitle, readingDate, page, rating);
        }
        
        public System.Threading.Tasks.Task<string> InsertReadListAsync(string authorName, string bookTitle, System.DateTime readingDate, int page, int rating) {
            return base.Channel.InsertReadListAsync(authorName, bookTitle, readingDate, page, rating);
        }
        
        public string DeleteById(int id) {
            return base.Channel.DeleteById(id);
        }
        
        public System.Threading.Tasks.Task<string> DeleteByIdAsync(int id) {
            return base.Channel.DeleteByIdAsync(id);
        }
        
        public string UpdateReadList(ASPNetMVC_Client.ReadListNS.ReadList newReadList) {
            return base.Channel.UpdateReadList(newReadList);
        }
        
        public System.Threading.Tasks.Task<string> UpdateReadListAsync(ASPNetMVC_Client.ReadListNS.ReadList newReadList) {
            return base.Channel.UpdateReadListAsync(newReadList);
        }
    }
}
