﻿//------------------------------------------------------------------------------
// <auto-generated>
//     이 코드는 도구를 사용하여 생성되었습니다.
//     런타임 버전:4.0.30319.42000
//
//     파일 내용을 변경하면 잘못된 동작이 발생할 수 있으며, 코드를 다시 생성하면
//     이러한 변경 내용이 손실됩니다.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _20181107마지막_시험_클라.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Data", Namespace="http://schemas.datacontract.org/2004/07/WbService")]
    [System.SerializableAttribute()]
    public partial class Data : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MsgField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TargetField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TypeField;
        
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
        public string Msg {
            get {
                return this.MsgField;
            }
            set {
                if ((object.ReferenceEquals(this.MsgField, value) != true)) {
                    this.MsgField = value;
                    this.RaisePropertyChanged("Msg");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Target {
            get {
                return this.TargetField;
            }
            set {
                if ((object.ReferenceEquals(this.TargetField, value) != true)) {
                    this.TargetField = value;
                    this.RaisePropertyChanged("Target");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Type {
            get {
                return this.TypeField;
            }
            set {
                if ((object.ReferenceEquals(this.TypeField, value) != true)) {
                    this.TypeField = value;
                    this.RaisePropertyChanged("Type");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IAiService", CallbackContract=typeof(_20181107마지막_시험_클라.ServiceReference1.IAiServiceCallback), SessionMode=System.ServiceModel.SessionMode.Required)]
    public interface IAiService {
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IAiService/AiSettingMessage", ReplyAction="http://tempuri.org/IAiService/AiSettingMessageResponse")]
        bool AiSettingMessage(string msg, string target, string type);
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IAiService/AiSettingMessage", ReplyAction="http://tempuri.org/IAiService/AiSettingMessageResponse")]
        System.Threading.Tasks.Task<bool> AiSettingMessageAsync(string msg, string target, string type);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAiService/Join", ReplyAction="http://tempuri.org/IAiService/JoinResponse")]
        bool Join(bool state, string name, int Channel);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAiService/Join", ReplyAction="http://tempuri.org/IAiService/JoinResponse")]
        System.Threading.Tasks.Task<bool> JoinAsync(bool state, string name, int Channel);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, IsTerminating=true, IsInitiating=false, Action="http://tempuri.org/IAiService/Leave")]
        void Leave(int stunumber);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, IsTerminating=true, IsInitiating=false, Action="http://tempuri.org/IAiService/Leave")]
        System.Threading.Tasks.Task LeaveAsync(int stunumber);
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IAiService/SendMessage", ReplyAction="http://tempuri.org/IAiService/SendMessageResponse")]
        bool SendMessage(string msg);
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IAiService/SendMessage", ReplyAction="http://tempuri.org/IAiService/SendMessageResponse")]
        System.Threading.Tasks.Task<bool> SendMessageAsync(string msg);
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IAiService/GetDataList", ReplyAction="http://tempuri.org/IAiService/GetDataListResponse")]
        _20181107마지막_시험_클라.ServiceReference1.Data[] GetDataList();
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IAiService/GetDataList", ReplyAction="http://tempuri.org/IAiService/GetDataListResponse")]
        System.Threading.Tasks.Task<_20181107마지막_시험_클라.ServiceReference1.Data[]> GetDataListAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAiServiceCallback {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAiService/CTv_On", ReplyAction="http://tempuri.org/IAiService/CTv_OnResponse")]
        bool CTv_On(bool power);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAiService/CLight_On", ReplyAction="http://tempuri.org/IAiService/CLight_OnResponse")]
        bool CLight_On(bool power);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAiService/CTv_ChannelUp", ReplyAction="http://tempuri.org/IAiService/CTv_ChannelUpResponse")]
        bool CTv_ChannelUp(int chenl);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAiService/CLight_ChannelUp", ReplyAction="http://tempuri.org/IAiService/CLight_ChannelUpResponse")]
        bool CLight_ChannelUp(int chenl);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAiService/CAiSet", ReplyAction="http://tempuri.org/IAiService/CAiSetResponse")]
        bool CAiSet(string msg, string target, string type);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAiServiceChannel : _20181107마지막_시험_클라.ServiceReference1.IAiService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AiServiceClient : System.ServiceModel.DuplexClientBase<_20181107마지막_시험_클라.ServiceReference1.IAiService>, _20181107마지막_시험_클라.ServiceReference1.IAiService {
        
        public AiServiceClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public AiServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public AiServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public AiServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public AiServiceClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public bool AiSettingMessage(string msg, string target, string type) {
            return base.Channel.AiSettingMessage(msg, target, type);
        }
        
        public System.Threading.Tasks.Task<bool> AiSettingMessageAsync(string msg, string target, string type) {
            return base.Channel.AiSettingMessageAsync(msg, target, type);
        }
        
        public bool Join(bool state, string name, int Channel) {
            return base.Channel.Join(state, name, Channel);
        }
        
        public System.Threading.Tasks.Task<bool> JoinAsync(bool state, string name, int Channel) {
            return base.Channel.JoinAsync(state, name, Channel);
        }
        
        public void Leave(int stunumber) {
            base.Channel.Leave(stunumber);
        }
        
        public System.Threading.Tasks.Task LeaveAsync(int stunumber) {
            return base.Channel.LeaveAsync(stunumber);
        }
        
        public bool SendMessage(string msg) {
            return base.Channel.SendMessage(msg);
        }
        
        public System.Threading.Tasks.Task<bool> SendMessageAsync(string msg) {
            return base.Channel.SendMessageAsync(msg);
        }
        
        public _20181107마지막_시험_클라.ServiceReference1.Data[] GetDataList() {
            return base.Channel.GetDataList();
        }
        
        public System.Threading.Tasks.Task<_20181107마지막_시험_클라.ServiceReference1.Data[]> GetDataListAsync() {
            return base.Channel.GetDataListAsync();
        }
    }
}
