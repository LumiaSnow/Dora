﻿using Dora.Interception;

namespace App
{
public class FoobarInterceptorAttribute : InterceptorAttribute
{
    public ValueTask InvokeAsync(InvocationContext invocationContext)
    {
        var method = invocationContext.MethodInfo;
        Console.WriteLine($"{method.DeclaringType!.Name}.{method.Name} is intercepted.");
        return invocationContext.ProceedAsync();
    }
}
}
