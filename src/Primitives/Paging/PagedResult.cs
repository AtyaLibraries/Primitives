// <copyright file="PagedResult.cs" company="Atya">
// Copyright (c) Atya. All rights reserved.
// </copyright>

namespace Atya.Foundation.Primitives.Paging;

public sealed record PagedResult<T>
{
    public PagedResult(
        IReadOnlyCollection<T> items,
        int pageNumber,
        int pageSize,
        int totalCount)
    {
        ArgumentNullException.ThrowIfNull(items);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(pageNumber);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(pageSize);
        ArgumentOutOfRangeException.ThrowIfNegative(totalCount);

        Items = items;
        PageNumber = pageNumber;
        PageSize = pageSize;
        TotalCount = totalCount;
    }

    public IReadOnlyCollection<T> Items
    {
        get; init;
    }

    public int PageNumber
    {
        get; init;
    }

    public int PageSize
    {
        get; init;
    }

    public int TotalCount
    {
        get; init;
    }

    public int TotalPages => TotalCount <= 0
        ? 0
        : (int)Math.Ceiling(TotalCount / (double)PageSize);

    public bool HasPreviousPage => PageNumber > 1;

    public bool HasNextPage => PageNumber < TotalPages;

    public static PagedResult<T> Empty(int pageNumber, int pageSize)
    {
        return new PagedResult<T>(Array.Empty<T>(), pageNumber, pageSize, 0);
    }
}
