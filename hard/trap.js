class Solution {
  trap(height) {
    let ans = 0;
    let left = 0;
    let right = height.length - 1;
    let leftMax = height[left];
    let rightMax = height[right];

    while (left < right) {
      if (height[left] <= height[right]) {
        if (height[left] < leftMax) {
          ans += leftMax - height[left];
        } else if (leftMax < height[left]) {
          leftMax = height[left];
        }
        left++;
      } else if (height[right] < height[left]) {
        if (height[right] < rightMax) {
          ans += rightMax - height[right];
        } else if (rightMax < height[right]) {
          rightMax = height[right];
        }
        right--;
      }
    }
    return ans;
  }
}

let s = new Solution();

let h = [4, 2, 3];

console.log(s.trap(h));
