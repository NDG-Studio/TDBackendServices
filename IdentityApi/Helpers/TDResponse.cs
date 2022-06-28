namespace IdentityApi.Helpers
{

    public class TDResponse
    {
        public bool HasError { get; set; } = false;
        public string Message { get; set; } = string.Empty;
        public int ErrorId { get; set; } = 0;

        public void SetError(string Message)
        {
            this.HasError = true;
            this.Message = Message;
        }
        public void SetError()
        {
            this.HasError = true;
            this.Message = OperationMessages.GeneralError;
        }

        public void SetSuccess(string Message)
        {
            this.HasError = false;
            this.Message = Message;
        }
        public void SetSuccess()
        {
            this.HasError = false;
            this.Message = OperationMessages.Success;
        }


    }
    public class TDResponse<T> : TDResponse
    {
        public T? Data { get; set; } = default(T);

    }

}