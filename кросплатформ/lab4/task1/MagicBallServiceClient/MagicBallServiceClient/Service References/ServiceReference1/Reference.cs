﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MagicBallServiceClient.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CompositeType", Namespace="http://schemas.datacontract.org/2004/07/MagicBallServiceLib")]
    [System.SerializableAttribute()]
    public partial class CompositeType : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool BoolValueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StringValueField;
        
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
        public bool BoolValue {
            get {
                return this.BoolValueField;
            }
            set {
                if ((this.BoolValueField.Equals(value) != true)) {
                    this.BoolValueField = value;
                    this.RaisePropertyChanged("BoolValue");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StringValue {
            get {
                return this.StringValueField;
            }
            set {
                if ((object.ReferenceEquals(this.StringValueField, value) != true)) {
                    this.StringValueField = value;
                    this.RaisePropertyChanged("StringValue");
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
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://localhost", ConfigurationName="ServiceReference1.IMagicBall")]
    public interface IMagicBall {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/IMagicBall/GetData", ReplyAction="http://localhost/IMagicBall/GetDataResponse")]
        string GetData(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/IMagicBall/GetDataUsingDataContract", ReplyAction="http://localhost/IMagicBall/GetDataUsingDataContractResponse")]
        MagicBallServiceClient.ServiceReference1.CompositeType GetDataUsingDataContract(MagicBallServiceClient.ServiceReference1.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/IMagicBall/ObtainAnswerToQuestion", ReplyAction="http://localhost/IMagicBall/ObtainAnswerToQuestionResponse")]
        string ObtainAnswerToQuestion(string userQuestion);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMagicBallChannel : MagicBallServiceClient.ServiceReference1.IMagicBall, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MagicBallClient : System.ServiceModel.ClientBase<MagicBallServiceClient.ServiceReference1.IMagicBall>, MagicBallServiceClient.ServiceReference1.IMagicBall {
        
        public MagicBallClient() {
        }
        
        public MagicBallClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MagicBallClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MagicBallClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MagicBallClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetData(int value) {
            return base.Channel.GetData(value);
        }
        
        public MagicBallServiceClient.ServiceReference1.CompositeType GetDataUsingDataContract(MagicBallServiceClient.ServiceReference1.CompositeType composite) {
            return base.Channel.GetDataUsingDataContract(composite);
        }
        
        public string ObtainAnswerToQuestion(string userQuestion) {
            return base.Channel.ObtainAnswerToQuestion(userQuestion);
        }
    }
}
