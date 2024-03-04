﻿using System.Diagnostics.Contracts;

namespace SharedKernel;

public interface IResult
{
}

public readonly struct Result<A> : IResult
{
    internal readonly ResultState State;
    internal readonly A Value;
    internal readonly Exception exception;
    internal Exception Exception => this.exception ?? new Exception("No exception was provided");

    public Result(A value)
    {
        this.State = ResultState.Success;
        this.Value = value;
        this.exception = null;
    }

    public Result(Exception e)
    {
        this.State = ResultState.Faulted;
        this.exception = e;
        this.Value = default;
    }

    public static Result<A> GetFaulted(Exception e)
    {
        return new Result<A>(e);
    }

    [Pure]
    public static implicit operator Result<A>(A value) => new Result<A>(value);

    [Pure]
    public static implicit operator Result<A>(Exception e) => new Result<A>(e);

    [Pure]
    public bool IsFaulted => this.State == ResultState.Faulted;

    [Pure]
    public bool IsSuccess => this.State == ResultState.Success;

    [Pure]
    public A IfFail(A defaultValue) =>
        IsFaulted
            ? defaultValue
            : Value;

    [Pure]
    public A IfFail(Func<Exception, A> f) =>
        IsFaulted
            ? f(Exception)
            : Value;

    [Pure]
    public Exception IfSucces(Func<A, Exception> f) =>
        IsSuccess
            ? f(Value)
            : Exception;


    [Pure]
    public Exception IfSuccess(Exception defaultException) =>
        IsSuccess
            ? defaultException
            : Exception;

    [Pure]
    public void OnSuccess(Action<A> action)
    {
        if (IsFaulted) return;
        action(Value);
    }

    [Pure]
    public void OnFail(Action<Exception> action)
    {
        if (IsSuccess) return;
        action(Exception);
    }

    [Pure]
    public async Task<Result<B>> Map<B>(Func<A, Task<B>> f) => this.IsFaulted ? new Result<B>(this.Exception) : new Result<B>(await f(this.Value));

    [Pure]
    public async Task<Result<B>> MapAsync<B>(Func<A, Task<B>> f)
    {
        Result<B> result;
        if (this.IsFaulted)
            result = new Result<B>(this.Exception);
        else
            result = new Result<B>(await f(this.Value));
        return result;
    }

    [Pure]
    public R Match<R>(Func<A, R> Succ, Func<Exception, R> Fail) =>
        IsFaulted
            ? Fail(Exception)
            : Succ(Value);

    [Pure]
    public override string ToString() =>
        IsFaulted
            ? Exception.Message.ToString()
            : Value.ToString();
}

public enum ResultState : byte
{
    Faulted,
    Success
}