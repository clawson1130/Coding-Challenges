/**
Given two sorted arrays nums1 and nums2 of size m and n respectively, return the median of the two sorted arrays.
 */
var findMedianSortedArrays = function(nums1, nums2) {
    
    //create a new array by combining both the arrays
    var arr = nums1.concat(nums2);

    //get the array length of the combined array
    var arrlen = arr.length;

    //sort in ascending order
    arr.sort(function(a,b){return a - b});

    //determine if the length of the combined array is even
    var even = arrlen % 2 == 0 ? true : false;

    //if even the median position is just divided by 2 , if odd divide the length by 2 and round of to the nearest number 
    var median = even ? arrlen / 2 : Math.ceil(arrlen / 2) ;

    //if even just return the median position of array
    //if odd combine the two median positions and divide it by 2
    var returnAns = !even ? arr[median - 1] : (arr[median]+arr[median - 1]) / 2;

    //return the answer to the function
    return(returnAns);
};