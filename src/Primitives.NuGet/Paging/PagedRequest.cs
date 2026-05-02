// <copyright file="PagedRequest.cs" company="Atya">
// Copyright (c) Atya. All rights reserved.
// </copyright>

using Atya.Foundation.Abstractions;

namespace Atya.Foundation.Primitives.Paging;

public sealed record PagedRequest : IPagedQuery
{
    public PagedRequest(int pageNumber = 1, int pageSize = 20)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(pageNumber);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(pageSize);

        this.PageNumber = pageNumber;
        this.PageSize = pageSize;
    }

    public int PageNumber
    {
        get; init;
    }

    public int PageSize
    {
        get; init;
    }

    public int Skip => checked((this.PageNumber - 1) * this.PageSize);
}
