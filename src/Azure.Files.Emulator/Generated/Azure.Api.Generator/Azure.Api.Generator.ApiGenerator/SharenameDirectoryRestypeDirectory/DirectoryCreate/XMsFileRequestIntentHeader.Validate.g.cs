﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

#nullable enable

using System.Runtime.CompilerServices;
using System.Text.Json;
using Corvus.Json;

namespace SharenameDirectoryRestypeDirectory.DirectoryCreate;
/// <summary>
/// Generated from JSON Schema.
/// </summary>
public readonly partial struct XMsFileRequestIntentHeader
{
    /// <inheritdoc/>
    public ValidationContext Validate(in ValidationContext validationContext, ValidationLevel level = ValidationLevel.Flag)
    {
        ValidationContext result = validationContext;
        if (level > ValidationLevel.Flag && !result.IsUsingResults)
        {
            result = result.UsingResults();
        }

        if (level > ValidationLevel.Basic)
        {
            if (!result.IsUsingStack)
            {
                result = result.UsingStack();
            }

            result = result.PushSchemaLocation("SharenameDirectoryRestypeDirectory.DirectoryCreate.XMsFileRequestIntentHeader.json");
        }

        JsonValueKind valueKind = this.ValueKind;

        result = CorvusValidation.TypeValidationHandler(valueKind, result, level);

        if (level == ValidationLevel.Flag && !result.IsValid)
        {
            return result;
        }

        result = CorvusValidation.CompositionAnyOfValidationHandler(this, result, level);

        if (level == ValidationLevel.Flag && !result.IsValid)
        {
            return result;
        }

        if (level > ValidationLevel.Basic)
        {
            result = result.PopLocation();
        }

        return result;
    }

    /// <summary>
    /// Constant values for the enum keyword.
    /// </summary>
    public static class EnumValues
    {
        /// <summary>
        /// Gets the string 'backup'
        /// as a <see cref="SharenameDirectoryRestypeDirectory.DirectoryCreate.XMsFileRequestIntentHeader"/>.
        /// </summary>
        public static XMsFileRequestIntentHeader Backup { get; } = CorvusValidation.Enum.As<XMsFileRequestIntentHeader>();

        /// <summary>
        /// Gets the string 'backup'
        /// as a UTF8 byte array.
        /// </summary>
        public static ReadOnlySpan<byte> BackupUtf8 => CorvusValidation.EnumUtf8;
    }

    /// <summary>
    /// Validation constants for the type.
    /// </summary>
    public static partial class CorvusValidation
    {
        /// <summary>
        /// A constant for the <c>enum</c> keyword.
        /// </summary>
        public static readonly JsonString Enum = JsonString.ParseValue("\"backup\"");

        /// <summary>
        /// A constant for the <c>enum</c> keyword.
        /// </summary>
        public static ReadOnlySpan<byte> EnumUtf8 => "\"backup\""u8;

        /// <summary>
        /// Core type validation.
        /// </summary>
        /// <param name="valueKind">The <see cref="JsonValueKind" /> of the value to validate.</param>
        /// <param name="validationContext">The current validation context.</param>
        /// <param name="level">The current validation level.</param>
        /// <returns>The resulting validation context after validation.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ValidationContext TypeValidationHandler(
            JsonValueKind valueKind,
            in ValidationContext validationContext,
            ValidationLevel level = ValidationLevel.Flag)
        {
            return Corvus.Json.ValidateWithoutCoreType.TypeString(valueKind, validationContext, level, "type");
        }

        /// <summary>
        /// Composition validation (any-of).
        /// </summary>
        /// <param name="value">The value to validate.</param>
        /// <param name="validationContext">The current validation context.</param>
        /// <param name="level">The current validation level.</param>
        /// <returns>The resulting validation context after validation.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ValidationContext CompositionAnyOfValidationHandler(
            in XMsFileRequestIntentHeader value,
            in ValidationContext validationContext,
            ValidationLevel level = ValidationLevel.Flag)
        {
            ValidationContext result = validationContext;

            result = ValidateEnum(value, result, level);
            if (!result.IsValid && level == ValidationLevel.Flag)
            {
                return result;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            static ValidationContext ValidateEnum(in XMsFileRequestIntentHeader value, in ValidationContext validationContext, ValidationLevel level)
            {
                ValidationContext result = validationContext;
                bool enumFoundValid = false;

                enumFoundValid = value.Equals(CorvusValidation.Enum);

                if (enumFoundValid)
                {
                    if (level >= ValidationLevel.Verbose)
                    {
                        result = result.WithResult(isValid: true, "Validation enum - validated against the enumeration.", "enum");
                    }
                }
                else
                {
                    if (level == ValidationLevel.Flag)
                    {
                        result = result.WithResult(isValid: false);
                    }
                    else
                    {
                        result = result.WithResult(isValid: false, "Validation enum - did not validate against the enumeration.", "enum");
                    }
                }

                return result;
            }

            return result;
        }
    }
}
