/**
 * @param {number[]} nums
 * @return {number[][]}
 */
var threeSum = function(nums) {
    nums.sort((a , b) => a - b);
    const result = [];
    for(let i = 0; i < nums.length - 2; i++) {
        if(i === 0 || nums[i] !== nums[i - 1]) {    
            let left = i + 1;
            let right = nums.length - 1;
            while(left < right) {
                if(nums[i] + nums[left] + nums[right] === 0) {
                    result.push([nums[i], nums[left], nums[right]]);
                    while(nums[left] === nums[left + 1]) {
                        left++;
                    }
                    while(nums[right] === nums[right - 1]) {
                        right--;
                    }
                    left++;
                    right--;
                }
                else if(nums[i] + nums[left] + nums[right] > 0) {
                    right--;
                } else {
                    left++;
                }
            }
        }
    }
    return result;
};

nums = [-1, -1 ,-1, 1, 1, 0]
console.log(threeSum(nums))