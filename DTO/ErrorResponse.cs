namespace Todo.DTO
{
    public class ErrorResponse<T>
    {
        public ErrorResponse(T data, List<string> errors)
        {
            Data = data;
            Errors = errors;
        }

        public ErrorResponse(T data)
        {
            Data = data;
        }

        public ErrorResponse(List<string> errors)
        {
            Errors = errors;
        }

        public ErrorResponse(string error)
        {
            Errors.Add(error);
        }

        public T Data { get; private set; }
        public List<string> Errors { get; private set; } = new();
    }
}

