using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Models;

namespace Utility;

public static class DTO
{
    private static object? GetValueFromPropertyName(this object? t, System.Reflection.PropertyInfo prop) => t?.GetType().GetProperty(prop.Name)?.GetValue(t, null);

    public static IQueryable<T> QueryParse<T>(this IQueryable<T> ctx, object obj)
    {
        var objType = obj.GetType();
        var ctxType = ctx.GetType();
        var ctxPropNames = ctxType.GetProperties().Select(prop => prop.Name).ToArray();
        foreach (System.Reflection.PropertyInfo prop in objType.GetProperties())
        {
            if (ctxPropNames.Contains(prop.Name) && objType?.GetProperty(prop.Name)?.GetValue(obj, null) != null)
                ctx = ctx.Where(t => t.GetValueFromPropertyName(prop) == objType.GetValueFromPropertyName(prop));
        }
        return ctx;
    }
}