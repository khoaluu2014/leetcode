/**
 * @param {number[]} nums
 * @param {number} target
 * @return {number}
 */
var searchInsert = function (nums, target) {
	var left = 0;
	var right = nums.length - 1;

	while (left <= right) {
		var mid = Math.floor((left + right) / 2);
		if (nums[mid] < target) {
			left = mid + 1;
		} else if (nums[mid] >= target) {
			right = mid - 1;
		}
	}

	return left;
};

// let nums = [1, 3, 5, 6],
// 	target = 5;
// console.log(searchInsert(nums, target));

//3 / 2 = 1.5 = 1
//
nums = [1, 3, 5, 6];
target = 2;
console.log(searchInsert(nums, target));

nums = [1, 3, 5, 6];
target = 7;
console.log(searchInsert(nums, target));
