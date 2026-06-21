using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace BeeneticToolkit.Collections.Enums {

    /// <summary>
    /// A self-registering variant of <see cref="EnumItem{TKey, TGroup}"/>. Declare your items as
    /// <c>public static readonly</c> fields on the derived type and they are discovered and registered
    /// automatically — no singleton collection class, no <c>Add(this)</c> in the constructor, and no
    /// hand-written static lookup facades. Static access (<see cref="All"/>, <see cref="FromKey"/>, …) is
    /// provided directly on the type.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This is the "curiously recurring" pattern: a type declares itself as its own <typeparamref name="TSelf"/>,
    /// e.g. <c>public sealed class Planet : AutoEnumItem&lt;Planet, string, NoGroup&gt;</c>.
    /// </para>
    /// <para>
    /// Registration is triggered lazily and thread-safely on first static access, and it explicitly runs the
    /// concrete type's static constructor first, so the registry is always fully populated regardless of which
    /// member is touched first — unlike a constructor-self-registration scheme, where touching the collection
    /// before the item type yields an empty collection.
    /// </para>
    /// </remarks>
    /// <typeparam name="TSelf">The concrete item type (must be the type deriving from this base).</typeparam>
    /// <typeparam name="TKey">The key type identifying each item.</typeparam>
    /// <typeparam name="TGroup">The group enum, or <see cref="NoGroup"/> when grouping is not required.</typeparam>
    public abstract class AutoEnumItem<TSelf, TKey, TGroup> : EnumItem<TKey, TGroup>
        where TSelf : AutoEnumItem<TSelf, TKey, TGroup>
        where TKey : notnull
        where TGroup : struct, Enum {

        /// <inheritdoc cref="EnumItem{TKey, TGroup}(TKey, string, string, string, int?, bool?, Nullable{TGroup})"/>
        protected AutoEnumItem(
            TKey key,
            string name,
            string shortName,
            string? description = null,
            int? displayOrder = null,
            bool? isActive = null,
            TGroup? group = null)
            : base(key, name, shortName, description, displayOrder, isActive, group) { }

        /// <summary>Gets every registered item, in declaration order.</summary>
        public static IReadOnlyList<TSelf> All => Backing.Items;

        /// <summary>Gets the number of registered items.</summary>
        public static int Count => Backing.Items.Count;

        /// <summary>Retrieves all items, optionally filtered by active state and sorted.</summary>
        public static IEnumerable<TSelf> GetAll(IComparer<TSelf>? comparer = null, bool? isActive = null)
            => Backing.Collection.GetAll(comparer, isActive);

        /// <summary>Retrieves items in the given group, optionally filtered by active state.</summary>
        public static IEnumerable<TSelf> GetByGroup(TGroup? group = null, bool? isActive = null)
            => Backing.Collection.GetByGroup(group, isActive);

        /// <summary>Searches items whose selected string property contains the search term.</summary>
        public static IEnumerable<TSelf> Search(Func<TSelf, string> selector, string searchTerm, bool caseSensitive = false, bool? isActive = null)
            => Backing.Collection.Search(selector, searchTerm, caseSensitive, isActive);

        /// <summary>Retrieves an item by its key; throws if no item has that key.</summary>
        public static TSelf FromKey(TKey key) => Backing.Collection.FromKey(key);

        /// <summary>Attempts to retrieve an item by its key, without throwing.</summary>
        public static bool TryFromKey(TKey key, [MaybeNullWhen(false)] out TSelf item) => Backing.Collection.TryFromKey(key, out item);

        /// <summary>Retrieves an item by its name; throws if no item has that name.</summary>
        public static TSelf FromName(string name) => Backing.Collection.FromName(name);

        /// <summary>Attempts to retrieve an item by its name, without throwing.</summary>
        public static bool TryFromName(string name, [MaybeNullWhen(false)] out TSelf item) => Backing.Collection.TryFromName(name, out item);

        /// <summary>Retrieves an item by its short name; throws if no item has that short name.</summary>
        public static TSelf FromShortName(string shortName) => Backing.Collection.FromShortName(shortName);

        /// <summary>Attempts to retrieve an item by its short name, without throwing.</summary>
        public static bool TryFromShortName(string shortName, [MaybeNullWhen(false)] out TSelf item) => Backing.Collection.TryFromShortName(shortName, out item);

        /// <summary>Gets the fixed domain of all items, used to build <see cref="EnumSet{T}"/> flag sets.</summary>
        public static EnumDomain<TSelf> Domain => Backing.Domain;

        /// <summary>Creates an empty <see cref="EnumSet{T}"/> over this enum's items.</summary>
        public static EnumSet<TSelf> EmptySet() => Backing.Domain.Empty();

        /// <summary>Creates an <see cref="EnumSet{T}"/> containing every item of this enum.</summary>
        public static EnumSet<TSelf> FullSet() => Backing.Domain.All();

        /// <summary>Creates an <see cref="EnumSet{T}"/> containing the given items of this enum.</summary>
        public static EnumSet<TSelf> SetOf(params TSelf[] items) => Backing.Domain.Of(items);

        /// <summary>
        /// Builds an O(1) secondary index over this enum's items, keyed by an arbitrary property. The item set is
        /// fixed, so the index is built once; hold the result (e.g. in a static field) to query it.
        /// </summary>
        /// <typeparam name="TValue">The type of the property being indexed.</typeparam>
        /// <param name="selector">Selects the value to index each item by.</param>
        /// <returns>The index, ready to query.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="selector"/> is null.</exception>
        public static EnumIndex<TValue, TSelf> IndexBy<TValue>(Func<TSelf, TValue> selector) where TValue : notnull {
            var index = new EnumIndex<TValue, TSelf>(selector);
            ((IEnumCollectionIndex<TSelf>)index).Rebuild(Backing.Items);
            return index;
        }

        /// <summary>
        /// Holds the per-<typeparamref name="TSelf"/> registry. Nested so its static initializer runs lazily on
        /// first access, under the CLR's type-initialization lock (thread-safe by construction).
        /// </summary>
        private static class Backing {

            public static readonly EnumCollection<TSelf, TKey, TGroup> Collection = Build();
            public static readonly IReadOnlyList<TSelf> Items = Collection.GetAll().ToList();
            public static readonly EnumDomain<TSelf> Domain = new EnumDomain<TSelf>(Items);

            private static EnumCollection<TSelf, TKey, TGroup> Build() {
                // Force the concrete type's static fields to construct BEFORE we read them. This is what makes
                // registration order-independent: it does not matter whether the first touch is All, FromKey, or
                // a direct field reference — the items always exist by the time we reflect over them.
                RuntimeHelpers.RunClassConstructor(typeof(TSelf).TypeHandle);

                var collection = new Registry();

                // MetadataToken ordering tracks declaration order within the type, giving a stable, intuitive All.
                IEnumerable<FieldInfo> fields = typeof(TSelf)
                    .GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static)
                    .Where(f => f.IsInitOnly && typeof(TSelf).IsAssignableFrom(f.FieldType))
                    .OrderBy(f => f.MetadataToken);

                foreach (FieldInfo field in fields) {
                    if (field.GetValue(null) is TSelf item)
                        collection.Add(item);
                }

                return collection;
            }

            /// <summary>A concrete, private collection to back the static lookups for this item type.</summary>
            private sealed class Registry : EnumCollection<TSelf, TKey, TGroup> { }
        }
    }
}
