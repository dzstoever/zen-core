﻿namespace Zen.Util
{
    public enum FieldNamingConvention
    {
        SameAsDatabase,
        CamelCase,
        Prefixed,
        /// <summary>
        /// Upper camel case.
        /// </summary>
        PascalCase
    }

    public enum FieldGenerationConvention
    {
        Field,
        Property,
        AutoProperty
    }
}