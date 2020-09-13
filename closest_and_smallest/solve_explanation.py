import math
from collections import namedtuple
Info = namedtuple('Info', ['weight', 'index', 'number'])

def closest(st):
    if st == "":
        return []

    def info(st):
        """Create requested data for each number of the input"""
        for i, number in enumerate(st.split()):
            yield Info(sum(int(c) for c in number), i, int(number))
    
    # Sort on weight, index, number in that order.
    # So smallest weights first and if they are identical sort on index etc.
    # The data will be sorted on weights (and only if weights are equal will the sorting of index come into play, etc for number)
    # This will allow us to iterate pairwise and do diffs of weight and know that we will be able to find the smallest diff that way.
    data = sorted(info(st))

    for d in data:
        print(d)
    print()
    # The data is now sorted on (weight, index, number) in that order.
    
    # The goal is to find the pair with the smallest:
    # 1. Diff in weight.
    # 2. Total weight.
    # 3. Total indexes.
    
    # Sorting on 1 is easy. 
    # Finding the smallest diff in a list can be done in O(n) if a list is already sorted.
    # For the first element the only sane candidate to check the diff with is the next one. And this holds for any element i in the list.
    
    # Iterating over all neighbour pairs [a, b] in the sorted data will allow us to save the following tuple:
    # (abs(a.weight - b.weight), a.weight + b.weight, a.index + b.index)
    # After sorting this the first item in the list would be the the one is the smallest according to the goalfunction.
    # What shall be returned however is the pair itself. 
    #     Adding the pair to the end of the tuple will make it easy to get the pair
    #     and it wont hur the sorting since the 3 important properties will be sorted on first.
    
    # Sorting the following tuples would therfore suffice to get the wanted pair.
    # (abs(a.weight - b.weight), a.weight + b.weight, a.index + b.index, [a, b])
    
    # Some optimizations are possible however.
    
    # Since the items are sorted on (weight, index, number) we know that a.weight <= b.weight. So the abs can be removed if we reorder.
    # (b.weight - a.weight, a.weight + b.weight, a.index + b.index, [a, b])
    
    # Since we are only interested in the best match we can optimize further.
    # Sorting on the secondary property, total weight is only done for pairs with the same weigh-diff.
    # If two pairs [a,b] and [c, d] have the same weight-diff x then I claim we only need to sort on the smallest weight in each pair!
    # Explanation:
    #     In any pair [a,b] we have that weight_of_b = (weight_of_a + diff). (note that a.weight <= b.weight)
    #     Hence total_wight total_weight([a,b]) = diff + 2 * weight_of_a
    #     Comparing two pairs [a,b] and [c,d] is therfore simply a matter of comparing the first (smallest) weights.
    
    # So sorting on the following tuple will not affect the results and allow us to remove an addition.
    # (b.weight - a.weight, a.weight, a.index + b.index, [a, b])

    # The 3rd property to be compared is the total sum of the indexes.
    # "with the smallest indices (or ranks, numbered from 0) in strng"
    
    # (b.weight - a.weight, a.weight, a.index + b.index, [a, b])
    # (d.weight - c.weight, c.weight, c.index + d.index, [a, b])
    # For the indexes to come into play the first 2 properties must be identical.
    # hence c.weight == a.weight. Replacing c.weight with a.weight above:
        # (b.weight - a.weight, a.weight, a.index + b.index, [a, b])
        # (d.weight - a.weight, a.weight, c.index + d.index, [c, d])
        
        # We know that the first two properties are also the same:
        # b.weight - a.weight == d.weight - a.weight
        # b.weight == d.weight
        
        # Combine these and we know that a,b,c,d weights are all identical. The diff is 0.
    
    # These 4 items in the original data list would be ordered in this way:
    # ... Info's with weight < k
    # Info(weight=k, index=3, ...)
    # Info(weight=k, index=15, ...)
    # Info(weight=k, index=99, ...)
    # Info(weight=k, index=200, ...)
    # ... Info's with weight > k
    
    # A lot of pairings will be made. But only the pairings between items with identical weights will give a case where diff and total weight is identical between 2 or more pairs.
    # Amoung items with the same weight the order is according to their indexes.
    # So the first pair made amoung these will always have the smallest total index sum.
    
    # Calculating the sum of the indexes is not needed since in the case that indexes are relevant we already know that the first pair will be the one with the smallest total.
    # Hence the index part can be removed from our considerations.
    # (b.weight - a.weight, a.weight, [a, b])
    
    # Now note that [a, b] means something like: [Info(weight=8, index=0, number=80), Info(weight=8, index=1, number=71)]
    # The way python will sort something like this is by these in the following order a.weight, a.index, a.number, b.weight, b.index, b.number
    # So it so happens that a.weight is the first comparison. This allows us to remove the explicit a.weight we added above.
    
    # Hence the middle value, a.weight, can be removed.
    # (b.weight - a.weight, [a, b])
    
    # The sorting should not be too inefficent due to comparisons of extra values in the [a,b] since there would never be duplicates of a.index and hence no need to sort on the final values.
    # It is however vastefull to include [a,b] everywhere. A more efficient approach would be:
    
    # (b.weight - a.weight, a.weight, (index_of_a, index_of_b))
    # This way the first 2 will be used to sort and the final tuple is used to fetch the needed data.
    
    
    results = []
    for a, b in zip(data, data[1:]):
        results.append((b.weight - a.weight, [a, b]))
    
    for res in sorted(results):
        print(res[0], list(res[1][0]), list(res[1][1]))
    
    # Sorting to find the smallest diff, weight, indicies (in that order) as requested.
    # Get the smallest pair and transform the namedtuples to lists of its property values.
    return [list(x) for x in sorted(results)[0][-1]]