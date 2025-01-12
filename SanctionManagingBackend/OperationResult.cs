namespace SanctionManagingBackend
{
    public class OperationResult
    {
        public bool Success { get; set; }
        public string Error { get; set; }

        public static OperationResult Fail(string error) => new OperationResult { Success = false, Error = error };
        public static OperationResult Ok() => new OperationResult { Success = true };
    }
}
