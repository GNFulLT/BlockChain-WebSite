namespace Authentication_Service.Request
{
    public interface IReturnable
    {
        string ReturnURL { get; set; }

        string FailedReturnURL { get; set; }
    }
}
