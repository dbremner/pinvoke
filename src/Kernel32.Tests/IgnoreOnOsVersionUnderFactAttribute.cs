﻿// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

using System;
using Xunit;

/// <summary>
///     A variant of XUnit <see cref="FactAttribute" /> that is automatically skiped when the OS version is under a
///     specific treshold.
/// </summary>
internal class IgnoreOnOsVersionUnderFactAttribute : FactAttribute
{
    private static readonly Version OsVersion = Environment.OSVersion.Version;
    private readonly Version minimumVersion;

    /// <summary>Initializes a new instance of the <see cref="IgnoreOnOsVersionUnderFactAttribute" /> class.</summary>
    /// <param name="minimumVersion">
    ///     The minimum version required for this <see cref="FactAttribute" /> in a format usable by
    ///     <see cref="Version.Parse" />.
    /// </param>
    public IgnoreOnOsVersionUnderFactAttribute(string minimumVersion)
    {
        this.minimumVersion = Version.Parse(minimumVersion);
    }

    /// <inheritdoc />
    public override string Skip
    {
        get
        {
            return this.minimumVersion <= OsVersion
                ? base.Skip
                : $"OSVersion ({OsVersion}) < Minimum ({this.minimumVersion})";
        }

        set
        {
            base.Skip = value;
        }
    }
}