namespace FX850P.Domain.Common;

public class ServiceResult<TType>
{
    private TType _result { get; set; } = default!;
    public TType Result => _result;

    public bool IsValid { get; protected set; }

    public string Error { get; protected set; }

    #region Contructor
    public ServiceResult()
    {
        IsValid = false;
        Error = "Uknown error.";
    }

    public ServiceResult<TType> SuccessIfNotNull(TType result)
    {
        _result = result;
        if (!EqualityComparer<TType>.Default.Equals(_result, default))
        {
            Success();
        }

        return this;
    }

    public static ServiceResult<TType> FailResult(string error)
    {
        var result = new ServiceResult<TType>();
        result.Fail(error);
        return result;
    }
    public static ServiceResult<TType> SuccessResult()
    {
        var result = new ServiceResult<TType>();
        result.Success();
        return result;
    }
    public static ServiceResult<TType> SuccessResultIfNotNull(TType value)
    {
        var result = new ServiceResult<TType>();
        result.SuccessIfNotNull(value);
        return result;
    }
    #endregion

    public virtual ServiceResult<TType> Fail(string error)
    {
        IsValid = false;
        Error = error;
        return this;
    }

    public ServiceResult<TType> Success()
    {
        IsValid = true;
        Error = "";
        return this;
    }

    public async Task ExecuteIfValidAsync<TReturnType, TInnerType>(Func<Task<TReturnType>> method) where TReturnType : ServiceResult<TInnerType>
    {
        if (IsValid)
        {
            TReturnType result = await method();
            if (!result.IsValid)
            {
                Fail(result.Error);
            }
        }
    }
    public async Task ExecuteIfValidAsync(Func<Task<ServiceResult>> method)
    {
        if (IsValid)
        {
            ServiceResult result = await method();
            if (!result.IsValid)
            {
                Fail(result.Error);
            }
        }
    }
}

public class ServiceResult : ServiceResult<object>
{
    public new static ServiceResult SuccessResult()
    {
        var result = new ServiceResult();
        result.Success();
        return result;
    }
    public new static ServiceResult SuccessResultIfNotNull(object obj)
    {
        var result = new ServiceResult();
        result.SuccessIfNotNull(obj);
        return result;
    }
    public new static ServiceResult FailResult(string error)
    {
        var result = new ServiceResult();
        result.Fail(error);
        return result;
    }
}
