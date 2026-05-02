// <copyright file="PagedRequest.cs" company="Atya">
// Copyright (c) Atya. All rights reserved.
// </copyright>

using Atya.Foundation.Abstractions;
using Atya.Foundation.Guards;

namespace Atya.Foundation.Primitives.Paging;

public sealed record PagedRequest : IPagedQuery
{
    public PagedRequest(int pageNumber = 1, int pageSize = 20)
    {
        PageNumber = Guard.AgainstZeroOrNegative(pageNumber);
        PageSize = Guard.AgainstZeroOrNegative(pageSize);
    }

    public int PageNumber
    {
        get;
        init;
    }

    public int PageSize
    {
        get;
        init;
    }

    public int Skip => checked((PageNumber - 1) * PageSize);
}
