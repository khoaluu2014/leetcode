class Solution {
  maxSlidingWindow(nums, k) {
    const n = nums.length;
    const ans = [];
    const q = [];
    let l = 0;
    let r = 0;

    while (r < n) {
      while (q.length > 0 && q[q.length - 1] < nums[r]) {
        q.pop();
      }
      q.push(nums[r]);
      if (r + 1 >= k) {
        ans.push(q[0]);
        if (nums[l] === q[0]) {
          q.shift();
        }
        l++;
      }
      r++;
    }
    return ans;
  }
}
