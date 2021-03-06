﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MathConsoleClient.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://myService", ConfigurationName="ServiceReference1.ICalculator")]
    public interface ICalculator {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://myService/ICalculator/Add", ReplyAction="http://myService/ICalculator/AddResponse")]
        double Add(double n1, double n2);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://myService/ICalculator/Add", ReplyAction="http://myService/ICalculator/AddResponse")]
        System.IAsyncResult BeginAdd(double n1, double n2, System.AsyncCallback callback, object asyncState);
        
        double EndAdd(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://myService/ICalculator/Subtract", ReplyAction="http://myService/ICalculator/SubtractResponse")]
        double Subtract(double n1, double n2);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://myService/ICalculator/Subtract", ReplyAction="http://myService/ICalculator/SubtractResponse")]
        System.IAsyncResult BeginSubtract(double n1, double n2, System.AsyncCallback callback, object asyncState);
        
        double EndSubtract(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://myService/ICalculator/Multiply", ReplyAction="http://myService/ICalculator/MultiplyResponse")]
        double Multiply(double n1, double n2);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://myService/ICalculator/Multiply", ReplyAction="http://myService/ICalculator/MultiplyResponse")]
        System.IAsyncResult BeginMultiply(double n1, double n2, System.AsyncCallback callback, object asyncState);
        
        double EndMultiply(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://myService/ICalculator/Divide", ReplyAction="http://myService/ICalculator/DivideResponse")]
        double Divide(double n1, double n2);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://myService/ICalculator/Divide", ReplyAction="http://myService/ICalculator/DivideResponse")]
        System.IAsyncResult BeginDivide(double n1, double n2, System.AsyncCallback callback, object asyncState);
        
        double EndDivide(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://myService/ICalculator/Task", ReplyAction="http://myService/ICalculator/TaskResponse")]
        string Task(int val);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://myService/ICalculator/Task", ReplyAction="http://myService/ICalculator/TaskResponse")]
        System.IAsyncResult BeginTask(int val, System.AsyncCallback callback, object asyncState);
        
        string EndTask(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICalculatorChannel : MathConsoleClient.ServiceReference1.ICalculator, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AddCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public AddCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public double Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((double)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SubtractCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public SubtractCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public double Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((double)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MultiplyCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public MultiplyCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public double Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((double)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DivideCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public DivideCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public double Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((double)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TaskCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public TaskCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public string Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CalculatorClient : System.ServiceModel.ClientBase<MathConsoleClient.ServiceReference1.ICalculator>, MathConsoleClient.ServiceReference1.ICalculator {
        
        private BeginOperationDelegate onBeginAddDelegate;
        
        private EndOperationDelegate onEndAddDelegate;
        
        private System.Threading.SendOrPostCallback onAddCompletedDelegate;
        
        private BeginOperationDelegate onBeginSubtractDelegate;
        
        private EndOperationDelegate onEndSubtractDelegate;
        
        private System.Threading.SendOrPostCallback onSubtractCompletedDelegate;
        
        private BeginOperationDelegate onBeginMultiplyDelegate;
        
        private EndOperationDelegate onEndMultiplyDelegate;
        
        private System.Threading.SendOrPostCallback onMultiplyCompletedDelegate;
        
        private BeginOperationDelegate onBeginDivideDelegate;
        
        private EndOperationDelegate onEndDivideDelegate;
        
        private System.Threading.SendOrPostCallback onDivideCompletedDelegate;
        
        private BeginOperationDelegate onBeginTaskDelegate;
        
        private EndOperationDelegate onEndTaskDelegate;
        
        private System.Threading.SendOrPostCallback onTaskCompletedDelegate;
        
        public CalculatorClient() {
        }
        
        public CalculatorClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CalculatorClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CalculatorClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CalculatorClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public event System.EventHandler<AddCompletedEventArgs> AddCompleted;
        
        public event System.EventHandler<SubtractCompletedEventArgs> SubtractCompleted;
        
        public event System.EventHandler<MultiplyCompletedEventArgs> MultiplyCompleted;
        
        public event System.EventHandler<DivideCompletedEventArgs> DivideCompleted;
        
        public event System.EventHandler<TaskCompletedEventArgs> TaskCompleted;
        
        public double Add(double n1, double n2) {
            return base.Channel.Add(n1, n2);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginAdd(double n1, double n2, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginAdd(n1, n2, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public double EndAdd(System.IAsyncResult result) {
            return base.Channel.EndAdd(result);
        }
        
        private System.IAsyncResult OnBeginAdd(object[] inValues, System.AsyncCallback callback, object asyncState) {
            double n1 = ((double)(inValues[0]));
            double n2 = ((double)(inValues[1]));
            return this.BeginAdd(n1, n2, callback, asyncState);
        }
        
        private object[] OnEndAdd(System.IAsyncResult result) {
            double retVal = this.EndAdd(result);
            return new object[] {
                    retVal};
        }
        
        private void OnAddCompleted(object state) {
            if ((this.AddCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.AddCompleted(this, new AddCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void AddAsync(double n1, double n2) {
            this.AddAsync(n1, n2, null);
        }
        
        public void AddAsync(double n1, double n2, object userState) {
            if ((this.onBeginAddDelegate == null)) {
                this.onBeginAddDelegate = new BeginOperationDelegate(this.OnBeginAdd);
            }
            if ((this.onEndAddDelegate == null)) {
                this.onEndAddDelegate = new EndOperationDelegate(this.OnEndAdd);
            }
            if ((this.onAddCompletedDelegate == null)) {
                this.onAddCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnAddCompleted);
            }
            base.InvokeAsync(this.onBeginAddDelegate, new object[] {
                        n1,
                        n2}, this.onEndAddDelegate, this.onAddCompletedDelegate, userState);
        }
        
        public double Subtract(double n1, double n2) {
            return base.Channel.Subtract(n1, n2);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginSubtract(double n1, double n2, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginSubtract(n1, n2, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public double EndSubtract(System.IAsyncResult result) {
            return base.Channel.EndSubtract(result);
        }
        
        private System.IAsyncResult OnBeginSubtract(object[] inValues, System.AsyncCallback callback, object asyncState) {
            double n1 = ((double)(inValues[0]));
            double n2 = ((double)(inValues[1]));
            return this.BeginSubtract(n1, n2, callback, asyncState);
        }
        
        private object[] OnEndSubtract(System.IAsyncResult result) {
            double retVal = this.EndSubtract(result);
            return new object[] {
                    retVal};
        }
        
        private void OnSubtractCompleted(object state) {
            if ((this.SubtractCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.SubtractCompleted(this, new SubtractCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void SubtractAsync(double n1, double n2) {
            this.SubtractAsync(n1, n2, null);
        }
        
        public void SubtractAsync(double n1, double n2, object userState) {
            if ((this.onBeginSubtractDelegate == null)) {
                this.onBeginSubtractDelegate = new BeginOperationDelegate(this.OnBeginSubtract);
            }
            if ((this.onEndSubtractDelegate == null)) {
                this.onEndSubtractDelegate = new EndOperationDelegate(this.OnEndSubtract);
            }
            if ((this.onSubtractCompletedDelegate == null)) {
                this.onSubtractCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnSubtractCompleted);
            }
            base.InvokeAsync(this.onBeginSubtractDelegate, new object[] {
                        n1,
                        n2}, this.onEndSubtractDelegate, this.onSubtractCompletedDelegate, userState);
        }
        
        public double Multiply(double n1, double n2) {
            return base.Channel.Multiply(n1, n2);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginMultiply(double n1, double n2, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginMultiply(n1, n2, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public double EndMultiply(System.IAsyncResult result) {
            return base.Channel.EndMultiply(result);
        }
        
        private System.IAsyncResult OnBeginMultiply(object[] inValues, System.AsyncCallback callback, object asyncState) {
            double n1 = ((double)(inValues[0]));
            double n2 = ((double)(inValues[1]));
            return this.BeginMultiply(n1, n2, callback, asyncState);
        }
        
        private object[] OnEndMultiply(System.IAsyncResult result) {
            double retVal = this.EndMultiply(result);
            return new object[] {
                    retVal};
        }
        
        private void OnMultiplyCompleted(object state) {
            if ((this.MultiplyCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.MultiplyCompleted(this, new MultiplyCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void MultiplyAsync(double n1, double n2) {
            this.MultiplyAsync(n1, n2, null);
        }
        
        public void MultiplyAsync(double n1, double n2, object userState) {
            if ((this.onBeginMultiplyDelegate == null)) {
                this.onBeginMultiplyDelegate = new BeginOperationDelegate(this.OnBeginMultiply);
            }
            if ((this.onEndMultiplyDelegate == null)) {
                this.onEndMultiplyDelegate = new EndOperationDelegate(this.OnEndMultiply);
            }
            if ((this.onMultiplyCompletedDelegate == null)) {
                this.onMultiplyCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnMultiplyCompleted);
            }
            base.InvokeAsync(this.onBeginMultiplyDelegate, new object[] {
                        n1,
                        n2}, this.onEndMultiplyDelegate, this.onMultiplyCompletedDelegate, userState);
        }
        
        public double Divide(double n1, double n2) {
            return base.Channel.Divide(n1, n2);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginDivide(double n1, double n2, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginDivide(n1, n2, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public double EndDivide(System.IAsyncResult result) {
            return base.Channel.EndDivide(result);
        }
        
        private System.IAsyncResult OnBeginDivide(object[] inValues, System.AsyncCallback callback, object asyncState) {
            double n1 = ((double)(inValues[0]));
            double n2 = ((double)(inValues[1]));
            return this.BeginDivide(n1, n2, callback, asyncState);
        }
        
        private object[] OnEndDivide(System.IAsyncResult result) {
            double retVal = this.EndDivide(result);
            return new object[] {
                    retVal};
        }
        
        private void OnDivideCompleted(object state) {
            if ((this.DivideCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.DivideCompleted(this, new DivideCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void DivideAsync(double n1, double n2) {
            this.DivideAsync(n1, n2, null);
        }
        
        public void DivideAsync(double n1, double n2, object userState) {
            if ((this.onBeginDivideDelegate == null)) {
                this.onBeginDivideDelegate = new BeginOperationDelegate(this.OnBeginDivide);
            }
            if ((this.onEndDivideDelegate == null)) {
                this.onEndDivideDelegate = new EndOperationDelegate(this.OnEndDivide);
            }
            if ((this.onDivideCompletedDelegate == null)) {
                this.onDivideCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnDivideCompleted);
            }
            base.InvokeAsync(this.onBeginDivideDelegate, new object[] {
                        n1,
                        n2}, this.onEndDivideDelegate, this.onDivideCompletedDelegate, userState);
        }
        
        public string Task(int val) {
            return base.Channel.Task(val);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginTask(int val, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginTask(val, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public string EndTask(System.IAsyncResult result) {
            return base.Channel.EndTask(result);
        }
        
        private System.IAsyncResult OnBeginTask(object[] inValues, System.AsyncCallback callback, object asyncState) {
            int val = ((int)(inValues[0]));
            return this.BeginTask(val, callback, asyncState);
        }
        
        private object[] OnEndTask(System.IAsyncResult result) {
            string retVal = this.EndTask(result);
            return new object[] {
                    retVal};
        }
        
        private void OnTaskCompleted(object state) {
            if ((this.TaskCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.TaskCompleted(this, new TaskCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void TaskAsync(int val) {
            this.TaskAsync(val, null);
        }
        
        public void TaskAsync(int val, object userState) {
            if ((this.onBeginTaskDelegate == null)) {
                this.onBeginTaskDelegate = new BeginOperationDelegate(this.OnBeginTask);
            }
            if ((this.onEndTaskDelegate == null)) {
                this.onEndTaskDelegate = new EndOperationDelegate(this.OnEndTask);
            }
            if ((this.onTaskCompletedDelegate == null)) {
                this.onTaskCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnTaskCompleted);
            }
            base.InvokeAsync(this.onBeginTaskDelegate, new object[] {
                        val}, this.onEndTaskDelegate, this.onTaskCompletedDelegate, userState);
        }
    }
}
