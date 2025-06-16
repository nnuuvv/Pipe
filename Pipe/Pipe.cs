using System;
using System.Threading.Tasks;

namespace nuv.Pipe;

/// <summary>
/// Provides functions to chain different operations.
/// </summary>
/// <example>
/// <code>
/// "someString".Into(x => x.Length).Into(Console.WriteLine);
/// </code>
/// </example>
public static class Pipe
{
    /// <summary>
    /// Invokes the given function using the given value
    /// </summary>
    /// <param name="value"></param>
    /// <param name="func"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TR"></typeparam>
    /// <returns></returns>
    public static TR Into<T, TR>(this T value, Func<T, TR> func)
    {
        return func(value);
    }

    /// <summary>
    /// Awaits the given task and then calls the given function on it.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="func"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TR"></typeparam>
    /// <returns></returns>
    public static async Task<TR> AwaitInto<T, TR>(this Task<T> value, Func<T, TR> func)
    {
        return func(await value);
    }

    /// <summary>
    /// Invokes the given action using the given value.
    /// Returns the original value to allow continued chaining.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="func"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T Into<T>(this T value, Action<T> func)
    {
        func(value);
        return value;
    }

    /// <summary>
    /// Awaits the given task and then calls the given action on it.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="func"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static async Task<T> AwaitInto<T>(this Task<T> value, Action<T> func) 
    {
        func(await value);
        return value.Result;
    }
}