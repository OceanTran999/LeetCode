# Solving this challenge with Binary Search

def findMedianSortedArrays(nums1: list[int], nums2: list[int]) -> float: 
    # Check if length of nums2 > nums1
    mergeArr = nums1 + nums2
    mergeArr.sort()
    #print(mergeArr)
    med = int(len(mergeArr) / 2)
    if(len(mergeArr) % 2 == 0):
        val = float((mergeArr[med] + mergeArr[med-1]) / 2)
    else:
        val = float(mergeArr[med])
    return val
    

# List Comprehension
arr1 = [int(i) for i in input("Enter numbers in array1: ").split()]
arr2 = [int(i) for i in input("Enter numbers in array2: ").split()]

result = findMedianSortedArrays(arr1, arr2)
print(result)