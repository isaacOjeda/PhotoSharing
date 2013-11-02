﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34003
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This code was auto-generated by Microsoft.Silverlight.Phone.ServiceReference, version 3.7.0.0
// 
namespace PhotoSharing.WindowsPhone.UploadService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="UploadService.UploadPhotosSoap")]
    public interface UploadPhotosSoap {
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/Upload", ReplyAction="*")]
        System.IAsyncResult BeginUpload(PhotoSharing.WindowsPhone.UploadService.UploadRequest request, System.AsyncCallback callback, object asyncState);
        
        PhotoSharing.WindowsPhone.UploadService.UploadResponse EndUpload(System.IAsyncResult result);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class UploadRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="Upload", Namespace="http://tempuri.org/", Order=0)]
        public PhotoSharing.WindowsPhone.UploadService.UploadRequestBody Body;
        
        public UploadRequest() {
        }
        
        public UploadRequest(PhotoSharing.WindowsPhone.UploadService.UploadRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class UploadRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string imageBase64;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string qrCode;
        
        public UploadRequestBody() {
        }
        
        public UploadRequestBody(string imageBase64, string qrCode) {
            this.imageBase64 = imageBase64;
            this.qrCode = qrCode;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class UploadResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="UploadResponse", Namespace="http://tempuri.org/", Order=0)]
        public PhotoSharing.WindowsPhone.UploadService.UploadResponseBody Body;
        
        public UploadResponse() {
        }
        
        public UploadResponse(PhotoSharing.WindowsPhone.UploadService.UploadResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class UploadResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public bool UploadResult;
        
        public UploadResponseBody() {
        }
        
        public UploadResponseBody(bool UploadResult) {
            this.UploadResult = UploadResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface UploadPhotosSoapChannel : PhotoSharing.WindowsPhone.UploadService.UploadPhotosSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UploadCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public UploadCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public bool Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UploadPhotosSoapClient : System.ServiceModel.ClientBase<PhotoSharing.WindowsPhone.UploadService.UploadPhotosSoap>, PhotoSharing.WindowsPhone.UploadService.UploadPhotosSoap {
        
        private BeginOperationDelegate onBeginUploadDelegate;
        
        private EndOperationDelegate onEndUploadDelegate;
        
        private System.Threading.SendOrPostCallback onUploadCompletedDelegate;
        
        private BeginOperationDelegate onBeginOpenDelegate;
        
        private EndOperationDelegate onEndOpenDelegate;
        
        private System.Threading.SendOrPostCallback onOpenCompletedDelegate;
        
        private BeginOperationDelegate onBeginCloseDelegate;
        
        private EndOperationDelegate onEndCloseDelegate;
        
        private System.Threading.SendOrPostCallback onCloseCompletedDelegate;
        
        public UploadPhotosSoapClient() {
        }
        
        public UploadPhotosSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UploadPhotosSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UploadPhotosSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UploadPhotosSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Net.CookieContainer CookieContainer {
            get {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    return httpCookieContainerManager.CookieContainer;
                }
                else {
                    return null;
                }
            }
            set {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    httpCookieContainerManager.CookieContainer = value;
                }
                else {
                    throw new System.InvalidOperationException("Unable to set the CookieContainer. Please make sure the binding contains an HttpC" +
                            "ookieContainerBindingElement.");
                }
            }
        }
        
        public event System.EventHandler<UploadCompletedEventArgs> UploadCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> OpenCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> CloseCompleted;
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult PhotoSharing.WindowsPhone.UploadService.UploadPhotosSoap.BeginUpload(PhotoSharing.WindowsPhone.UploadService.UploadRequest request, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginUpload(request, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        private System.IAsyncResult BeginUpload(string imageBase64, string qrCode, System.AsyncCallback callback, object asyncState) {
            PhotoSharing.WindowsPhone.UploadService.UploadRequest inValue = new PhotoSharing.WindowsPhone.UploadService.UploadRequest();
            inValue.Body = new PhotoSharing.WindowsPhone.UploadService.UploadRequestBody();
            inValue.Body.imageBase64 = imageBase64;
            inValue.Body.qrCode = qrCode;
            return ((PhotoSharing.WindowsPhone.UploadService.UploadPhotosSoap)(this)).BeginUpload(inValue, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        PhotoSharing.WindowsPhone.UploadService.UploadResponse PhotoSharing.WindowsPhone.UploadService.UploadPhotosSoap.EndUpload(System.IAsyncResult result) {
            return base.Channel.EndUpload(result);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        private bool EndUpload(System.IAsyncResult result) {
            PhotoSharing.WindowsPhone.UploadService.UploadResponse retVal = ((PhotoSharing.WindowsPhone.UploadService.UploadPhotosSoap)(this)).EndUpload(result);
            return retVal.Body.UploadResult;
        }
        
        private System.IAsyncResult OnBeginUpload(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string imageBase64 = ((string)(inValues[0]));
            string qrCode = ((string)(inValues[1]));
            return this.BeginUpload(imageBase64, qrCode, callback, asyncState);
        }
        
        private object[] OnEndUpload(System.IAsyncResult result) {
            bool retVal = this.EndUpload(result);
            return new object[] {
                    retVal};
        }
        
        private void OnUploadCompleted(object state) {
            if ((this.UploadCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.UploadCompleted(this, new UploadCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void UploadAsync(string imageBase64, string qrCode) {
            this.UploadAsync(imageBase64, qrCode, null);
        }
        
        public void UploadAsync(string imageBase64, string qrCode, object userState) {
            if ((this.onBeginUploadDelegate == null)) {
                this.onBeginUploadDelegate = new BeginOperationDelegate(this.OnBeginUpload);
            }
            if ((this.onEndUploadDelegate == null)) {
                this.onEndUploadDelegate = new EndOperationDelegate(this.OnEndUpload);
            }
            if ((this.onUploadCompletedDelegate == null)) {
                this.onUploadCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnUploadCompleted);
            }
            base.InvokeAsync(this.onBeginUploadDelegate, new object[] {
                        imageBase64,
                        qrCode}, this.onEndUploadDelegate, this.onUploadCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginOpen(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(callback, asyncState);
        }
        
        private object[] OnEndOpen(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndOpen(result);
            return null;
        }
        
        private void OnOpenCompleted(object state) {
            if ((this.OpenCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.OpenCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void OpenAsync() {
            this.OpenAsync(null);
        }
        
        public void OpenAsync(object userState) {
            if ((this.onBeginOpenDelegate == null)) {
                this.onBeginOpenDelegate = new BeginOperationDelegate(this.OnBeginOpen);
            }
            if ((this.onEndOpenDelegate == null)) {
                this.onEndOpenDelegate = new EndOperationDelegate(this.OnEndOpen);
            }
            if ((this.onOpenCompletedDelegate == null)) {
                this.onOpenCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnOpenCompleted);
            }
            base.InvokeAsync(this.onBeginOpenDelegate, null, this.onEndOpenDelegate, this.onOpenCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginClose(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginClose(callback, asyncState);
        }
        
        private object[] OnEndClose(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndClose(result);
            return null;
        }
        
        private void OnCloseCompleted(object state) {
            if ((this.CloseCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.CloseCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void CloseAsync() {
            this.CloseAsync(null);
        }
        
        public void CloseAsync(object userState) {
            if ((this.onBeginCloseDelegate == null)) {
                this.onBeginCloseDelegate = new BeginOperationDelegate(this.OnBeginClose);
            }
            if ((this.onEndCloseDelegate == null)) {
                this.onEndCloseDelegate = new EndOperationDelegate(this.OnEndClose);
            }
            if ((this.onCloseCompletedDelegate == null)) {
                this.onCloseCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnCloseCompleted);
            }
            base.InvokeAsync(this.onBeginCloseDelegate, null, this.onEndCloseDelegate, this.onCloseCompletedDelegate, userState);
        }
        
        protected override PhotoSharing.WindowsPhone.UploadService.UploadPhotosSoap CreateChannel() {
            return new UploadPhotosSoapClientChannel(this);
        }
        
        private class UploadPhotosSoapClientChannel : ChannelBase<PhotoSharing.WindowsPhone.UploadService.UploadPhotosSoap>, PhotoSharing.WindowsPhone.UploadService.UploadPhotosSoap {
            
            public UploadPhotosSoapClientChannel(System.ServiceModel.ClientBase<PhotoSharing.WindowsPhone.UploadService.UploadPhotosSoap> client) : 
                    base(client) {
            }
            
            public System.IAsyncResult BeginUpload(PhotoSharing.WindowsPhone.UploadService.UploadRequest request, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[1];
                _args[0] = request;
                System.IAsyncResult _result = base.BeginInvoke("Upload", _args, callback, asyncState);
                return _result;
            }
            
            public PhotoSharing.WindowsPhone.UploadService.UploadResponse EndUpload(System.IAsyncResult result) {
                object[] _args = new object[0];
                PhotoSharing.WindowsPhone.UploadService.UploadResponse _result = ((PhotoSharing.WindowsPhone.UploadService.UploadResponse)(base.EndInvoke("Upload", _args, result)));
                return _result;
            }
        }
    }
}
