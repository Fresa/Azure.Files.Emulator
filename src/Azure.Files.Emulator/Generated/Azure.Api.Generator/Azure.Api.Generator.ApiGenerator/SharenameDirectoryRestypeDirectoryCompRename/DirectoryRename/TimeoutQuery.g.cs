﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

#nullable enable

using System.Buffers;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Corvus.Json;
using Corvus.Json.Internal;

namespace SharenameDirectoryRestypeDirectoryCompRename.DirectoryRename;
/// <summary>
/// Generated from JSON Schema.
/// </summary>
[System.Text.Json.Serialization.JsonConverter(typeof(Corvus.Json.Internal.JsonValueConverter<TimeoutQuery>))]
public readonly partial struct TimeoutQuery

{
    private readonly Backing backing;
    private readonly JsonElement jsonElementBacking;
    private readonly BinaryJsonNumber numberBacking;

    /// <summary>
    /// Initializes a new instance of the <see cref="TimeoutQuery"/> struct.
    /// </summary>
    public TimeoutQuery()
    {
        this.jsonElementBacking = default;
        this.backing = Backing.JsonElement;
        this.numberBacking = default;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="TimeoutQuery"/> struct.
    /// </summary>
    /// <param name="value">The value from which to construct the instance.</param>
    public TimeoutQuery(in JsonElement value)
    {
        this.jsonElementBacking = value;
        this.backing = Backing.JsonElement;
        this.numberBacking = default;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="TimeoutQuery"/> struct.
    /// </summary>
    /// <param name="value">The value from which to construct the instance.</param>
    public TimeoutQuery(BinaryJsonNumber value)
    {
        this.backing = Backing.Number;
        this.jsonElementBacking = default;
        this.numberBacking = value;
    }

    /// <summary>
    /// Gets the schema location from which this type was generated.
    /// </summary>
    public static string SchemaLocation { get; } = "SharenameDirectoryRestypeDirectoryCompRename.DirectoryRename.TimeoutQuery.json";

    /// <summary>
    /// Gets a Null instance.
    /// </summary>
    public static TimeoutQuery Null { get; } = new(JsonValueHelpers.NullElement);

    /// <summary>
    /// Gets an Undefined instance.
    /// </summary>
    public static TimeoutQuery Undefined { get; }

    /// <summary>
    /// Gets the default instance.
    /// </summary>
    public static TimeoutQuery DefaultInstance { get; }

    /// <inheritdoc/>
    public JsonAny AsAny
    {
        get
        {
            if ((this.backing & Backing.JsonElement) != 0)
            {
                return new(this.jsonElementBacking);
            }

            if ((this.backing & Backing.Number) != 0)
            {
                return new(this.numberBacking);
            }

            if ((this.backing & Backing.Null) != 0)
            {
                return JsonAny.Null;
            }

            return JsonAny.Undefined;
        }
    }

    /// <inheritdoc/>
    public JsonElement AsJsonElement
    {
        get
        {
            if ((this.backing & Backing.JsonElement) != 0)
            {
                return this.jsonElementBacking;
            }

            if ((this.backing & Backing.Number) != 0)
            {
                return JsonValueHelpers.NumberToJsonElement(this.numberBacking);
            }

            if ((this.backing & Backing.Null) != 0)
            {
                return JsonValueHelpers.NullElement;
            }

            return default;
        }
    }

    /// <inheritdoc/>
    JsonString IJsonValue.AsString
    {
        get
        {
            if ((this.backing & Backing.JsonElement) != 0)
            {
                return new(this.jsonElementBacking);
            }

            throw new InvalidOperationException();
        }
    }

    /// <inheritdoc/>
    JsonBoolean IJsonValue.AsBoolean
    {
        get
        {
            if ((this.backing & Backing.JsonElement) != 0)
            {
                return new(this.jsonElementBacking);
            }

            throw new InvalidOperationException();
        }
    }

    /// <inheritdoc/>
    public JsonNumber AsNumber
    {
        get
        {
            if ((this.backing & Backing.JsonElement) != 0)
            {
                return new(this.jsonElementBacking);
            }

            if ((this.backing & Backing.Number) != 0)
            {
                return new(this.numberBacking);
            }

            throw new InvalidOperationException();
        }
    }

    /// <inheritdoc/>
    JsonObject IJsonValue.AsObject
    {
        get
        {
            if ((this.backing & Backing.JsonElement) != 0)
            {
                return new(this.jsonElementBacking);
            }

            throw new InvalidOperationException();
        }
    }

    /// <inheritdoc/>
    JsonArray IJsonValue.AsArray
    {
        get
        {
            if ((this.backing & Backing.JsonElement) != 0)
            {
                return new(this.jsonElementBacking);
            }

            throw new InvalidOperationException();
        }
    }

    /// <inheritdoc/>
    public bool HasJsonElementBacking
    {
        get
        {
            return (this.backing & Backing.JsonElement) != 0;
        }
    }

    /// <inheritdoc/>
    public bool HasDotnetBacking
    {
        get
        {
            return (this.backing & Backing.Dotnet) != 0;
        }
    }

    /// <inheritdoc/>
    public JsonValueKind ValueKind
    {
        get
        {
            if ((this.backing & Backing.JsonElement) != 0)
            {
                return this.jsonElementBacking.ValueKind;
            }

            if ((this.backing & Backing.Number) != 0)
            {
                return JsonValueKind.Number;
            }

            return JsonValueKind.Undefined;
        }
    }

    /// <summary>
    /// Conversion from JsonAny.
    /// </summary>
    /// <param name="value">The value from which to convert.</param>
    public static implicit operator TimeoutQuery(JsonAny value)
    {
        return value.As<TimeoutQuery>();
    }

    /// <summary>
    /// Conversion to JsonAny.
    /// </summary>
    /// <param name="value">The value from which to convert.</param>
    public static implicit operator JsonAny(TimeoutQuery value)
    {
        return value.AsAny;
    }

    /// <summary>
    /// Operator ==.
    /// </summary>
    /// <param name="left">The lhs of the operator.</param>
    /// <param name="right">The rhs of the operator.</param>
    /// <returns>
    /// <c>True</c> if the values are equal.
    /// </returns>
    public static bool operator ==(in TimeoutQuery left, in TimeoutQuery right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// Operator !=.
    /// </summary>
    /// <param name="left">The lhs of the operator.</param>
    /// <param name="right">The rhs of the operator.</param>
    /// <returns>
    /// <c>True</c> if the values are not equal.
    /// </returns>
    public static bool operator !=(in TimeoutQuery left, in TimeoutQuery right)
    {
        return !left.Equals(right);
    }

    /// <summary>
    /// Gets an instance of the JSON value from a <see cref="JsonElement"/> value.
    /// </summary>
    /// <param name="value">The <see cref="JsonElement"/> value from which to instantiate the instance.</param>
    /// <returns>An instance of this type, initialized from the <see cref="JsonElement"/>.</returns>
    /// <remarks>The returned value will have a <see cref = "IJsonValue.ValueKind"/> of <see cref = "JsonValueKind.Undefined"/> if the
    /// value cannot be constructed from the given instance (e.g. because they have an incompatible .NET backing type).
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TimeoutQuery FromJson(in JsonElement value)
    {
        return new(value);
    }

    /// <summary>
    /// Gets an instance of the JSON value from a <see cref="JsonAny"/> value.
    /// </summary>
    /// <param name="value">The <see cref="JsonAny"/> value from which to instantiate the instance.</param>
    /// <returns>An instance of this type, initialized from the <see cref="JsonAny"/> value.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TimeoutQuery FromAny(in JsonAny value)
    {
        if (value.HasJsonElementBacking)
        {
            return new(value.AsJsonElement);
        }

        return value.ValueKind switch
        {
            JsonValueKind.Number => new(value.AsNumber.AsBinaryJsonNumber),
            JsonValueKind.Null => Null,
            _ => Undefined,
        };
    }

#if NET8_0_OR_GREATER
    /// <summary>
    /// Gets an instance of the JSON value from the provided value.
    /// </summary>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    /// <param name="value">The value from which to instantiate the instance.</param>
    /// <returns>An instance of this type, initialized from the provided value.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static TimeoutQuery IJsonValue<TimeoutQuery>.FromBoolean<TValue>(in TValue value)
    {
        if (value.HasJsonElementBacking)
        {
            return new(value.AsJsonElement);
        }

        return Undefined;
    }
#endif

#if NET8_0_OR_GREATER
    /// <summary>
    /// Gets an instance of the JSON value from the provided value.
    /// </summary>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    /// <param name="value">The value from which to instantiate the instance.</param>
    /// <returns>An instance of this type, initialized from the provided value.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static TimeoutQuery IJsonValue<TimeoutQuery>.FromString<TValue>(in TValue value)
    {
        if (value.HasJsonElementBacking)
        {
            return new(value.AsJsonElement);
        }

        return Undefined;
    }
#endif

    /// <summary>
    /// Gets an instance of the JSON value from the provided value.
    /// </summary>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    /// <param name="value">The value from which to instantiate the instance.</param>
    /// <returns>An instance of this type, initialized from the provided value.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TimeoutQuery FromNumber<TValue>(in TValue value)
        where TValue : struct, IJsonNumber<TValue>
    {
        if (value.HasJsonElementBacking)
        {
            return new(value.AsJsonElement);
        }

        return value.ValueKind switch
        {
            JsonValueKind.Number => new(value.AsBinaryJsonNumber),
            JsonValueKind.Null => Null,
            _ => Undefined,
        };
    }

#if NET8_0_OR_GREATER
    /// <summary>
    /// Gets an instance of the JSON value from the provided value.
    /// </summary>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    /// <param name="value">The value from which to instantiate the instance.</param>
    /// <returns>An instance of this type, initialized from the provided value.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static TimeoutQuery IJsonValue<TimeoutQuery>.FromObject<TValue>(in TValue value)
    {
        if (value.HasJsonElementBacking)
        {
            return new(value.AsJsonElement);
        }

        return Undefined;
    }
#endif

#if NET8_0_OR_GREATER
    /// <summary>
    /// Gets an instance of the JSON value from the provided value.
    /// </summary>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    /// <param name="value">The value from which to instantiate the instance.</param>
    /// <returns>An instance of this type, initialized from the provided value.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static TimeoutQuery IJsonValue<TimeoutQuery>.FromArray<TValue>(in TValue value)
    {
        if (value.HasJsonElementBacking)
        {
            return new(value.AsJsonElement);
        }

        return Undefined;
    }
#endif

    /// <summary>
    /// Parses the TimeoutQuery.
    /// </summary>
    /// <param name="source">The source of the JSON string to parse.</param>
    /// <param name="options">The (optional) JsonDocumentOptions.</param>
    public static TimeoutQuery Parse(string source, JsonDocumentOptions options = default)
    {
        using var jsonDocument = JsonDocument.Parse(source, options);
        return new(jsonDocument.RootElement.Clone());
    }

    /// <summary>
    /// Parses the TimeoutQuery.
    /// </summary>
    /// <param name="source">The source of the JSON string to parse.</param>
    /// <param name="options">The (optional) JsonDocumentOptions.</param>
    public static TimeoutQuery Parse(Stream source, JsonDocumentOptions options = default)
    {
        using var jsonDocument = JsonDocument.Parse(source, options);
        return new(jsonDocument.RootElement.Clone());
    }

    /// <summary>
    /// Parses the TimeoutQuery.
    /// </summary>
    /// <param name="source">The source of the JSON string to parse.</param>
    /// <param name="options">The (optional) JsonDocumentOptions.</param>
    public static TimeoutQuery Parse(ReadOnlyMemory<byte> source, JsonDocumentOptions options = default)
    {
        using var jsonDocument = JsonDocument.Parse(source, options);
        return new(jsonDocument.RootElement.Clone());
    }

    /// <summary>
    /// Parses the TimeoutQuery.
    /// </summary>
    /// <param name="source">The source of the JSON string to parse.</param>
    /// <param name="options">The (optional) JsonDocumentOptions.</param>
    public static TimeoutQuery Parse(ReadOnlyMemory<char> source, JsonDocumentOptions options = default)
    {
        using var jsonDocument = JsonDocument.Parse(source, options);
        return new(jsonDocument.RootElement.Clone());
    }

    /// <summary>
    /// Parses the TimeoutQuery.
    /// </summary>
    /// <param name="source">The source of the JSON string to parse.</param>
    /// <param name="options">The (optional) JsonDocumentOptions.</param>
    public static TimeoutQuery Parse(ReadOnlySequence<byte> source, JsonDocumentOptions options = default)
    {
        using var jsonDocument = JsonDocument.Parse(source, options);
        return new(jsonDocument.RootElement.Clone());
    }

    /// <summary>
    /// Parses the TimeoutQuery.
    /// </summary>
    /// <param name="source">The source of the JSON string to parse.</param>
    public static TimeoutQuery ParseValue(string source)
    {
#if NET8_0_OR_GREATER
        return IJsonValue<TimeoutQuery>.ParseValue(source);
#else
        return JsonValueHelpers.ParseValue<TimeoutQuery>(source.AsSpan());
#endif
    }

    /// <summary>
    /// Parses the TimeoutQuery.
    /// </summary>
    /// <param name="source">The source of the JSON string to parse.</param>
    public static TimeoutQuery ParseValue(ReadOnlySpan<char> source)
    {
#if NET8_0_OR_GREATER
        return IJsonValue<TimeoutQuery>.ParseValue(source);
#else
        return JsonValueHelpers.ParseValue<TimeoutQuery>(source);
#endif
    }

    /// <summary>
    /// Parses the TimeoutQuery.
    /// </summary>
    /// <param name="source">The source of the JSON string to parse.</param>
    public static TimeoutQuery ParseValue(ReadOnlySpan<byte> source)
    {
#if NET8_0_OR_GREATER
        return IJsonValue<TimeoutQuery>.ParseValue(source);
#else
        return JsonValueHelpers.ParseValue<TimeoutQuery>(source);
#endif
    }

    /// <summary>
    /// Parses the TimeoutQuery.
    /// </summary>
    /// <param name="source">The source of the JSON string to parse.</param>
    public static TimeoutQuery ParseValue(ref Utf8JsonReader source)
    {
#if NET8_0_OR_GREATER
        return IJsonValue<TimeoutQuery>.ParseValue(ref source);
#else
        return JsonValueHelpers.ParseValue<TimeoutQuery>(ref source);
#endif
    }

    /// <summary>
    /// Gets the value as an instance of the target value.
    /// </summary>
    /// <typeparam name="TTarget">The type of the target.</typeparam>
    /// <returns>An instance of the target type.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public TTarget As<TTarget>()
        where TTarget : struct, IJsonValue<TTarget>
    {
#if NET8_0_OR_GREATER
        if ((this.backing & Backing.JsonElement) != 0)
        {
            return TTarget.FromJson(this.jsonElementBacking);
        }

        if ((this.backing & Backing.Number) != 0)
        {
            return TTarget.FromNumber(this);
        }

        if ((this.backing & Backing.Null) != 0)
        {
            return TTarget.Null;
        }

        return TTarget.Undefined;
#else
        return this.As<TimeoutQuery, TTarget>();
#endif
    }

    /// <inheritdoc/>
    public override bool Equals(object? obj)
    {
        return
            (obj is IJsonValue jv && this.Equals(jv.As<TimeoutQuery>())) ||
            (obj is null && this.IsNull());
    }

    /// <inheritdoc/>
    public bool Equals<T>(in T other)
        where T : struct, IJsonValue<T>
    {
        return this.Equals(other.As<TimeoutQuery>());
    }

    /// <summary>
    /// Equality comparison.
    /// </summary>
    /// <param name="other">The other item with which to compare.</param>
    /// <returns><see langword="true"/> if the values were equal.</returns>
    public bool Equals(in TimeoutQuery other)
    {
        JsonValueKind thisKind = this.ValueKind;
        JsonValueKind otherKind = other.ValueKind;
        if (thisKind != otherKind)
        {
            return false;
        }

        if (thisKind == JsonValueKind.Null || thisKind == JsonValueKind.Undefined)
        {
            return true;
        }

        if (thisKind == JsonValueKind.Number)
        {
            if (this.backing == Backing.Number && other.backing == Backing.Number)
            {
                return BinaryJsonNumber.Equals(this.numberBacking, other.numberBacking);
            }

            if (this.backing == Backing.Number && other.backing == Backing.JsonElement)
            {
                return BinaryJsonNumber.Equals(this.numberBacking, other.jsonElementBacking);
            }

            if (this.backing == Backing.JsonElement && other.backing == Backing.Number)
            {
                return BinaryJsonNumber.Equals(this.jsonElementBacking, other.numberBacking);
            }

            if (this.jsonElementBacking.TryGetDouble(out double lDouble))
            {
                if (other.jsonElementBacking.TryGetDouble(out double rDouble))
                {
                    return lDouble.Equals(rDouble);
                }
            }

            if (this.jsonElementBacking.TryGetDecimal(out decimal lDecimal))
            {
                if (other.jsonElementBacking.TryGetDecimal(out decimal rDecimal))
                {
                    return lDecimal.Equals(rDecimal);
                }
            }
        }

        return false;
    }

    /// <inheritdoc/>
    public void WriteTo(Utf8JsonWriter writer)
    {
        if ((this.backing & Backing.JsonElement) != 0)
        {
            if (this.jsonElementBacking.ValueKind != JsonValueKind.Undefined)
            {
                this.jsonElementBacking.WriteTo(writer);
            }

            return;
        }

        if ((this.backing & Backing.Number) != 0)
        {
            this.numberBacking.WriteTo(writer);

            return;
        }

        if ((this.backing & Backing.Null) != 0)
        {
            writer.WriteNullValue();

            return;
        }
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        return this.ValueKind switch
        {
            JsonValueKind.Array => JsonValueHelpers.GetArrayHashCode(((IJsonValue)this).AsArray),
            JsonValueKind.Object => JsonValueHelpers.GetObjectHashCode(((IJsonValue)this).AsObject),
            JsonValueKind.Number => JsonValueHelpers.GetHashCodeForNumber(this),
            JsonValueKind.String => JsonValueHelpers.GetHashCodeForString(((IJsonValue)this).AsString),
            JsonValueKind.True => true.GetHashCode(),
            JsonValueKind.False => false.GetHashCode(),
            JsonValueKind.Null => JsonValueHelpers.NullHashCode,
            _ => JsonValueHelpers.UndefinedHashCode,
        };
    }

    /// <inheritdoc/>
    public override string ToString()
    {
        return this.Serialize();
    }
}
