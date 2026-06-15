using System;
using System.Collections;
using System.Collections.Generic;

namespace BeeneticToolkit.Collections.Enums {

    /// <summary>
    /// A set of items drawn from a fixed <see cref="EnumDomain{T}"/> — the smart-enum equivalent of a
    /// <c>[Flags]</c> enum, but without the 64-value limit, the manual power-of-two bookkeeping, or the loss of
    /// type safety. Internally a compact bitmask (one bit per domain item), so membership tests and set algebra
    /// are fast, and the in-place operations allocate nothing.
    /// </summary>
    /// <remarks>
    /// Create sets through a smart enum's static factories (<c>MyEnum.SetOf(...)</c>, <c>EmptySet()</c>,
    /// <c>FullSet()</c>) or a domain's factories. Only sets sharing the <i>same</i> domain instance can be
    /// combined; mixing domains throws. Not thread-safe for concurrent mutation.
    /// </remarks>
    /// <typeparam name="T">The item type.</typeparam>
    public sealed class EnumSet<T> : IReadOnlyCollection<T>, IEquatable<EnumSet<T>> where T : class {

        private readonly EnumDomain<T> _domain;
        private readonly ulong[] _bits;

        internal EnumSet(EnumDomain<T> domain) {
            _domain = domain;
            _bits = new ulong[domain.WordCount];
        }

        private EnumSet(EnumDomain<T> domain, ulong[] bits) {
            _domain = domain;
            _bits = bits;
        }

        /// <summary>Gets the domain this set draws its items from.</summary>
        public EnumDomain<T> Domain => _domain;

        /// <summary>Gets the number of items currently in the set.</summary>
        public int Count {
            get {
                int count = 0;
                for (int i = 0; i < _bits.Length; i++)
                    count += PopCount(_bits[i]);
                return count;
            }
        }

        /// <summary>Gets a value indicating whether the set contains no items.</summary>
        public bool IsEmpty {
            get {
                for (int i = 0; i < _bits.Length; i++)
                    if (_bits[i] != 0)
                        return false;
                return true;
            }
        }

        /// <summary>Determines whether the set contains the given item.</summary>
        public bool Contains(T item) {
            if (item == null || !_domain.TryIndexOf(item, out int index))
                return false;

            return (_bits[index >> 6] & (1UL << (index & 63))) != 0;
        }

        /// <summary>Adds an item to the set.</summary>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="item"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="item"/> does not belong to this set's domain.</exception>
        public void Add(T item) {
            if (item == null)
                throw new ArgumentNullException(nameof(item));
            if (!_domain.TryIndexOf(item, out int index))
                throw new ArgumentException("The item does not belong to this set's domain.", nameof(item));

            _bits[index >> 6] |= 1UL << (index & 63);
        }

        /// <summary>Removes an item from the set.</summary>
        /// <returns><c>true</c> if the item was present and removed; otherwise <c>false</c>.</returns>
        public bool Remove(T item) {
            if (item == null || !_domain.TryIndexOf(item, out int index))
                return false;

            int word = index >> 6;
            ulong mask = 1UL << (index & 63);
            bool had = (_bits[word] & mask) != 0;
            _bits[word] &= ~mask;
            return had;
        }

        /// <summary>Removes every item from the set.</summary>
        public void Clear() => Array.Clear(_bits, 0, _bits.Length);

        /// <summary>Adds every item of <paramref name="other"/> to this set (in place).</summary>
        public void UnionWith(EnumSet<T> other) {
            RequireSameDomain(other);
            for (int i = 0; i < _bits.Length; i++)
                _bits[i] |= other._bits[i];
        }

        /// <summary>Keeps only the items also present in <paramref name="other"/> (in place).</summary>
        public void IntersectWith(EnumSet<T> other) {
            RequireSameDomain(other);
            for (int i = 0; i < _bits.Length; i++)
                _bits[i] &= other._bits[i];
        }

        /// <summary>Removes the items present in <paramref name="other"/> (in place).</summary>
        public void ExceptWith(EnumSet<T> other) {
            RequireSameDomain(other);
            for (int i = 0; i < _bits.Length; i++)
                _bits[i] &= ~other._bits[i];
        }

        /// <summary>Keeps the items present in exactly one of the two sets (in place).</summary>
        public void SymmetricExceptWith(EnumSet<T> other) {
            RequireSameDomain(other);
            for (int i = 0; i < _bits.Length; i++)
                _bits[i] ^= other._bits[i];
        }

        /// <summary>Determines whether every item in this set is also in <paramref name="other"/>.</summary>
        public bool IsSubsetOf(EnumSet<T> other) {
            RequireSameDomain(other);
            for (int i = 0; i < _bits.Length; i++)
                if ((_bits[i] & ~other._bits[i]) != 0)
                    return false;
            return true;
        }

        /// <summary>Determines whether this set contains every item in <paramref name="other"/>.</summary>
        public bool IsSupersetOf(EnumSet<T> other) {
            if (other == null)
                throw new ArgumentNullException(nameof(other));
            return other.IsSubsetOf(this);
        }

        /// <summary>Determines whether the two sets share at least one item.</summary>
        public bool Overlaps(EnumSet<T> other) {
            RequireSameDomain(other);
            for (int i = 0; i < _bits.Length; i++)
                if ((_bits[i] & other._bits[i]) != 0)
                    return true;
            return false;
        }

        /// <summary>Determines whether the two sets contain exactly the same items.</summary>
        public bool SetEquals(EnumSet<T> other) => Equals(other);

        /// <summary>Returns a copy of this set.</summary>
        public EnumSet<T> Clone() => new EnumSet<T>(_domain, (ulong[])_bits.Clone());

        /// <summary>Returns a new set of every domain item not in this set.</summary>
        public EnumSet<T> Complement() {
            var bits = new ulong[_bits.Length];
            for (int i = 0; i < _bits.Length; i++)
                bits[i] = ~_bits[i];

            MaskTail(bits);
            return new EnumSet<T>(_domain, bits);
        }

        /// <summary>Returns a new set containing the items of both sets.</summary>
        public static EnumSet<T> operator |(EnumSet<T> left, EnumSet<T> right) {
            EnumSet<T> result = NotNull(left).Clone();
            result.UnionWith(right);
            return result;
        }

        /// <summary>Returns a new set containing the items present in both sets.</summary>
        public static EnumSet<T> operator &(EnumSet<T> left, EnumSet<T> right) {
            EnumSet<T> result = NotNull(left).Clone();
            result.IntersectWith(right);
            return result;
        }

        /// <summary>Returns a new set containing the items present in exactly one of the two sets.</summary>
        public static EnumSet<T> operator ^(EnumSet<T> left, EnumSet<T> right) {
            EnumSet<T> result = NotNull(left).Clone();
            result.SymmetricExceptWith(right);
            return result;
        }

        /// <summary>Returns a new set containing the items of <paramref name="left"/> not in <paramref name="right"/>.</summary>
        public static EnumSet<T> operator -(EnumSet<T> left, EnumSet<T> right) {
            EnumSet<T> result = NotNull(left).Clone();
            result.ExceptWith(right);
            return result;
        }

        /// <summary>Returns the complement of <paramref name="set"/> relative to its domain.</summary>
        public static EnumSet<T> operator ~(EnumSet<T> set) => NotNull(set).Complement();

        /// <inheritdoc/>
        public IEnumerator<T> GetEnumerator() {
            int count = _domain.Count;
            for (int i = 0; i < count; i++)
                if ((_bits[i >> 6] & (1UL << (i & 63))) != 0)
                    yield return _domain.ItemAt(i);
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <inheritdoc/>
        public bool Equals(EnumSet<T>? other) {
            if (other is null)
                return false;
            if (ReferenceEquals(this, other))
                return true;
            if (!ReferenceEquals(_domain, other._domain) || _bits.Length != other._bits.Length)
                return false;

            for (int i = 0; i < _bits.Length; i++)
                if (_bits[i] != other._bits[i])
                    return false;
            return true;
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj) => Equals(obj as EnumSet<T>);

        /// <inheritdoc/>
        public override int GetHashCode() {
            var hash = new HashCode();
            for (int i = 0; i < _bits.Length; i++)
                hash.Add(_bits[i]);
            return hash.ToHashCode();
        }

        /// <summary>Returns the items in domain order, e.g. <c>{Iron, Gold}</c>.</summary>
        public override string ToString() => "{" + string.Join(", ", this) + "}";

        /// <summary>Sets every valid bit (used to build a full set).</summary>
        internal void SetAll() {
            for (int i = 0; i < _bits.Length; i++)
                _bits[i] = ~0UL;

            MaskTail(_bits);
        }

        /// <summary>Clears the unused high bits of the last word so they never affect Count/equality.</summary>
        private void MaskTail(ulong[] bits) {
            if (bits.Length == 0)
                return;

            int remainder = _domain.Count & 63;
            if (remainder != 0)
                bits[bits.Length - 1] &= (1UL << remainder) - 1UL;
        }

        private void RequireSameDomain(EnumSet<T> other) {
            if (other == null)
                throw new ArgumentNullException(nameof(other));
            if (!ReferenceEquals(_domain, other._domain))
                throw new ArgumentException("The two sets do not share the same domain and cannot be combined.", nameof(other));
        }

        private static EnumSet<T> NotNull(EnumSet<T> set) => set ?? throw new ArgumentNullException(nameof(set));

        /// <summary>Counts the set bits in a 64-bit word (SWAR; no dependency on BitOperations).</summary>
        private static int PopCount(ulong x) {
            x -= (x >> 1) & 0x5555555555555555UL;
            x = (x & 0x3333333333333333UL) + ((x >> 2) & 0x3333333333333333UL);
            x = (x + (x >> 4)) & 0x0f0f0f0f0f0f0f0fUL;
            return (int)((x * 0x0101010101010101UL) >> 56);
        }
    }
}
