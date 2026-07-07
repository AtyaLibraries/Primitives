// <copyright file="PagedResult.cs" company="Atya">
// Copyright (c) Atya. All rights reserved.
// </copyright>

using Atya.Foundation.Guards;

namespace Atya.Foundation.Primitives.Paging;

/// <summary>
/// Represents one page of items and the associated pagination metadata.
/// </summary>
/// <typeparam name="T">The item type.</typeparam>
public sealed record PagedResult<T>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PagedResult{T}"/> record.
    /// </summary>
    /// <param name="items">The items in the current page.</param>
    /// <param name="pageNumber">The one-based current page number.</param>
    /// <param name="pageSize">The positive page size.</param>
    /// <param name="totalCount">The total number of available items.</param>
    public PagedResult(
        IReadOnlyCollection<T> items,
        int pageNumber,
        int pageSize,
        int totalCount)
    {
        Items = Guard.AgainstNull(items);
        PageNumber = Guard.AgainstZeroOrNegative(pageNumber);
        PageSize = Guard.AgainstZeroOrNegative(pageSize);
        TotalCount = Guard.AgainstNegative(totalCount);
    }

    /// <summary>
    /// Gets the items in the current page.
    /// </summary>
    public IReadOnlyCollection<T> Items
    {
        get;
        init;
    }

    /// <summary>
    /// Gets the one-based current page number.
    /// </summary>
    public int PageNumber
    {
        get;
        init;
    }

    /// <summary>
    /// Gets the positive page size.
    /// </summary>
    public int PageSize
    {
        get;
        init;
    }

    /// <summary>
    /// Gets the total number of available items.
    /// </summary>
    public int TotalCount
    {
        get;
        init;
    }

    /// <summary>
    /// Gets the total number of pages.
    /// </summary>
    public int TotalPages => TotalCount <= 0
        ? 0
        : (int)Math.Ceiling(TotalCount / (double)PageSize);

    /// <summary>
    /// Gets a value indicating whether a previous page exists.
    /// </summary>
    public bool HasPreviousPage => PageNumber > 1;

    /// <summary>
    /// Gets a value indicating whether a next page exists.
    /// </summary>
    public bool HasNextPage => PageNumber < TotalPages;

    /// <summary>
    /// Creates an empty page result.
    /// </summary>
    /// <param name="pageNumber">The one-based page number.</param>
    /// <param name="pageSize">The positive page size.</param>
    /// <returns>An empty page result.</returns>
    public static PagedResult<T> Empty(int pageNumber, int pageSize)
    {
        return new PagedResult<T>(Array.Empty<T>(), pageNumber, pageSize, 0);
    }
}
