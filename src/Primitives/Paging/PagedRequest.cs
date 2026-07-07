// <copyright file="PagedRequest.cs" company="Atya">
// Copyright (c) Atya. All rights reserved.
// </copyright>

using Atya.Foundation.Abstractions;
using Atya.Foundation.Guards;

namespace Atya.Foundation.Primitives.Paging;

/// <summary>
/// Represents a one-based paged query request.
/// </summary>
public sealed record PagedRequest : IPagedQuery
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PagedRequest"/> record.
    /// </summary>
    /// <param name="pageNumber">The one-based page number.</param>
    /// <param name="pageSize">The positive page size.</param>
    public PagedRequest(int pageNumber = 1, int pageSize = 20)
    {
        PageNumber = Guard.AgainstZeroOrNegative(pageNumber);
        PageSize = Guard.AgainstZeroOrNegative(pageSize);
    }

    /// <summary>
    /// Gets the one-based page number.
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
    /// Gets the number of items to skip before reading this page.
    /// </summary>
    public int Skip => checked((PageNumber - 1) * PageSize);
}
